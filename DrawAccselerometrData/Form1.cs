using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;
using AcselerometrData;

namespace DrawAccselerometrData
{
    public partial class Form1 : Form
    {
        private string pointMode = "X";
        private int colorNam = 0;
        private string seriesName = "Series Acs ";
        private XmlSerializer serializer = new XmlSerializer(typeof(List<AcselerometrData.StructAccselerometrData>));
        private bool dir = false;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            chartFrame.ChartAreas.Add(new ChartArea("mychart"));
            this.btn_average.Enabled = this.dir;
           // this.btn_furieAmplitude.Enabled = false;
            //this.btn_furiePhase.Enabled = false;
        }
        /*
         * 
         * функция рисования графика
         * 
         */
        private void draw(List<double> acsData, List<long> time, string nameFile)
        {
            seriesName += nameFile;
            int listPoints = acsData.Count;

            chartFrame.Bounds = new Rectangle(0, 0, chartFrame.Width, chartFrame.Height);
            chartFrame.Series.Add(new Series(seriesName));
            chartFrame.Series[seriesName].ChartArea = "mychart";

            chartFrame.Series[seriesName].ChartType = SeriesChartType.FastLine;
            chartFrame.Series[seriesName].BorderWidth = 1;

            chartFrame.ChartAreas[0].Position.Y = 0;
            chartFrame.ChartAreas[0].Position.Height = 100;
            chartFrame.ChartAreas[0].Position.X = 0;
            chartFrame.ChartAreas[0].Position.Width = 100;

            for (int i = 0; i < listPoints; ++i)
            {
                chartFrame.Series[seriesName].Points.AddXY(time[i], acsData[i]);
            }
        }
 
        /*
         * 
         * Преобразует структуру long time
         *                       double x
         *                       double y
         *                       double z
         *                       
         *             в массив листов по x, y, z
         * 
         */
        private List<double>[] getXYZ(List<AcselerometrData.StructAccselerometrData> acsdata)
        {
            List<double>[] listXYZ = new List<double>[3];
            listXYZ[0] = new List<double>();
            listXYZ[1] = new List<double>();
            listXYZ[2] = new List<double>();
            for (int i = 0; i < acsdata.Count; ++i)
            {
                listXYZ[0].Add(acsdata[i].x);
                listXYZ[1].Add(acsdata[i].y);
                listXYZ[2].Add(acsdata[i].z);
            }
            return listXYZ;
        }
        /*
         * 
         * Преобразует структуру long time
         *                       double x
         *                       double y
         *                       double z
         *                       
         *             в лист по time
         * 
         */
        private List<long> getTime(List<AcselerometrData.StructAccselerometrData> acsdata)
        {
            long timeBuf = acsdata[0].time;
            List<long> listData = new List<long>();
            for (int i = 0; i < acsdata.Count; ++i)
            {
                listData.Add(acsdata[i].time - acsdata[0].time);
                listData[i] = listData[i] / TimeSpan.TicksPerMillisecond;
                //      Console.WriteLine(listData[i]);
            }
            return listData;
        }
        /*
         * 
         * средние значения по дирректории
         * Находит минимальную длинну массива данных
         * вызывает обработчик
         * 
         */
        private void btn_average_Click(object sender, EventArgs e)
        {
            List<AcselerometrData.StructAccselerometrData>[] listAcsData;

            string nameDir;
            int namberFiles = 0;
            int i, minFileCount = 0;
            string fileName = "AccselerometrData";

            try
            {
                nameDir = this.openDialogDir();
            }
            catch (DirectoryNotFoundException err)
            {
                return;
            }

            namberFiles = new DirectoryInfo(nameDir).GetFiles().Length;
            listAcsData = new List<AcselerometrData.StructAccselerometrData>[namberFiles];

            for (i = 0; i < namberFiles; ++i)
            {
                listAcsData[i] = this.getDataFromFile(nameDir + "\\" + fileName + i.ToString() + ".xml");
                if (i == 0)
                {
                    minFileCount = listAcsData[i].Count;
                }
                else
                {
                    if (minFileCount > listAcsData[i].Count)
                    {
                        minFileCount = listAcsData[i].Count;
                    }
                }
            }
            this.average(listAcsData, minFileCount);
        }
        /*
         * 
         * считает среднее арифметическое, вызывает рисоание
         * 
         */
        private void average(List<StructAccselerometrData>[] listAcsData, int minFileCount)
        {
            int j = 0, i;
            int acsDataLength = 0;

            List<double>[] averageXYZ;
            List<double>[] bufXYZ;
            List<long> averageTime;
            List<long> bufTime;

            acsDataLength = listAcsData.Length;

            averageXYZ = getXYZ(listAcsData[j]);
            averageTime = getTime(listAcsData[j]);

            for (i = 0; i < minFileCount; ++i)
            {
                for (j = 1; j < acsDataLength; ++j)
                {
                    bufXYZ = this.getXYZ(listAcsData[j]);
                    bufTime = this.getTime(listAcsData[j]);
                    averageXYZ[0][i] += bufXYZ[0][i];
                    averageXYZ[1][i] += bufXYZ[1][i];
                    averageXYZ[2][i] += bufXYZ[2][i];
                    averageTime[i] += bufTime[i];
                }
                averageTime[i] /= acsDataLength;
                averageXYZ[0][i] /= acsDataLength;
                averageXYZ[1][i] /= acsDataLength;
                averageXYZ[2][i] /= acsDataLength;
            }
            this.drawMode(averageXYZ, averageTime, "average");
        }
        /*
         * меняет цвет red -> blue -> green
         */
        private void btn_color_Click(object sender, EventArgs e)
        {
            colorNam = (colorNam + 1) % 3;
            try
            {
                switch (colorNam)
                {
                    case 0:
                        chartFrame.Series[seriesName].Color = Color.Red;
                        btn_color.Text = "Red";
                        break;
                    case 1:
                        chartFrame.Series[seriesName].Color = Color.Blue;
                        btn_color.Text = "Blue";
                        break;
                    case 2:
                        chartFrame.Series[seriesName].Color = Color.Green;
                        btn_color.Text = "Green";
                        break;
                }
            }
            catch (System.ArgumentException)
            {
                switch (colorNam)
                {
                    case 0:
                        btn_color.Text = "Red";
                        break;
                    case 1:
                        btn_color.Text = "Blue";
                        break;
                    case 2:
                        btn_color.Text = "Green";
                        break;
                }
            }

        }
        /*
         * 
         * Выводит все графики из дирректории
         * 
         */
         //эти два надо как то переписать 
        private void drawDataDir(string nameDir)
        {
            string fileName = "AccselerometrData";

            for (int i = 0; i < new DirectoryInfo(nameDir).GetFiles().Length; ++i)
            {
                this.drawDataFile(nameDir + "\\" + fileName + i.ToString() + ".xml");

            }
        }

        private void drawDataFile(string nameFile)
        {
            List<AcselerometrData.StructAccselerometrData> listAcsData;
            List<double>[] acsXYZ = new List<double>[3];
            List<long> timeList;

            listAcsData = this.getDataFromFile(nameFile);

            acsXYZ = this.getXYZ(listAcsData);
            timeList = this.getTime(listAcsData);

            this.drawMode(acsXYZ, timeList, nameFile);
        }
        /*
         * 
         * Получает данный из файла, десериализует их
         * 
         */
        private List<AcselerometrData.StructAccselerometrData> getDataFromFile(string nameFile)
        {
            List<AcselerometrData.StructAccselerometrData> listAcsData = new List<AcselerometrData.StructAccselerometrData>();
            FileStream fileStream;
            StreamReader streamReader;

            fileStream = File.Open(nameFile, FileMode.Open);
            streamReader = new StreamReader(fileStream);
            listAcsData = (List<AcselerometrData.StructAccselerometrData>)serializer.Deserialize(streamReader);
            streamReader.Close();
            fileStream.Close();

            return listAcsData;
        }
        /*
         * 
         * Выводит график одного конкретного файла
         * 
         */
        private void btn_draw_file_Click(object sender, EventArgs e)
        {
            string namefiles;
            if (dir)
            {
                try
                {
                    namefiles = this.openDialogDir();
                    this.drawDataDir(namefiles);
                }
                catch (DirectoryNotFoundException err)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    namefiles = this.openDialogFile();
                    this.drawDataFile(namefiles);
                }
                catch (FileNotFoundException err)
                {
                    return;
                }
            }
        }
        /*
         * 
         * Выбирает режим вывода файла, вызывает метод рисования graw
         * выводит по координате по Х, У, Z или по всем вместе
         * 
         */
        private void drawMode(List<double>[] dataList, List<long> timeList, string nameSeries)
        {
            switch (pointMode)
            {
                case "X":
                    this.draw(dataList[0], timeList, nameSeries);
                    break;
                case "Y":
                    this.draw(dataList[1], timeList, nameSeries);
                    break;
                case "Z":
                    this.draw(dataList[2], timeList, nameSeries);
                    break;
                case "XYZ":
                    this.draw(dataList[0], timeList, this.btn_draw_file.Text);
                    this.btn_color_Click(null, new EventArgs());
                    this.draw(dataList[1], timeList, this.btn_draw_file.Text);
                    this.btn_color_Click(null, new EventArgs());
                    this.draw(dataList[2], timeList, this.btn_draw_file.Text);
                    this.btn_color_Click(null, new EventArgs());
                    break;
                case "VEC":
                    for (int i = 0; i < dataList[0].Count; ++i)
                    {
                        dataList[0][i] = Math.Sqrt(Math.Pow(dataList[0][i], 2) +
                            Math.Pow(dataList[1][i], 2) + Math.Pow(dataList[2][i], 2));
                    }
                    this.draw(dataList[0], timeList, "vectorXYZ");
                    break;
                case "AVER":
                    break;
            }
        }

        /*
         * 
         * Очищает окно
         * 
         */
        private void btn_clear(object sender, EventArgs e)
        {
            chartFrame.Series.Clear();
        }
        /*
         * 
         * Устанавливает режим отображения графика по координате Х
         * 
         */
        private void btn_drawX_Click(object sender, EventArgs e)
        {
            this.pointMode = "X";
        }
        /*
         * 
         * Устанавливает режим отображения графика по координате У
         * 
         */
        private void btn_drawY_Click(object sender, EventArgs e)
        {
            this.pointMode = "Y";
        }
        /*
         * 
         * Устанавливает режим отображения графика по координате Z
         * 
         */
        private void btn_drawZ_Click(object sender, EventArgs e)
        {
            this.pointMode = "Z";
        }
        /*
         * 
         * Устанавливает режим отображения графика по всем координатам в отдельности
         * 
         */
        private void btn_drawXYZ_Click(object sender, EventArgs e)
        {
            this.pointMode = "XYZ";
        }

        private void btn_vectorXYZ_Click(object sender, EventArgs e)
        {
            this.pointMode = "VEC";
        }

        private string openDialogFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            throw new FileNotFoundException();
        }

        private string openDialogDir()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                return folder.SelectedPath;
            }
            throw new DirectoryNotFoundException();
        }
        //разбить на функции
        private void btn_furiePhase_Click(object sender, EventArgs e)
        {
            List<double>[] listXYZ;
            List<long> listTime;
            List<Complex> listComplex;
            string namefiles;
            if (dir)
            {
                try
                {
                    int namDirectory;
                    namefiles = this.openDialogDir();
                    namDirectory = new DirectoryInfo(namefiles).GetFiles().Length;
                    List<AcselerometrData.StructAccselerometrData> listAcsData;
                    for(int i = 0; i < namDirectory; ++i)
                    {
                        listAcsData = this.getDataFromFile(namefiles + "\\AccselerometrData" + i.ToString() +  ".xml");
                        listXYZ = this.getXYZ(listAcsData);
                        listTime = this.getTime(listAcsData);

                        listComplex = DFT.dft(listXYZ[0]);
                        listXYZ[0] = DFT.getArgument(listComplex);
                        listComplex = DFT.dft(listXYZ[1]);
                        listXYZ[1] = DFT.getArgument(listComplex);
                        listComplex = DFT.dft(listXYZ[2]);
                        listXYZ[2] = DFT.getArgument(listComplex);

                        this.drawMode(listXYZ, listTime, "phase" + i.ToString());
                    }
                }
                catch (DirectoryNotFoundException err)
                {
                    return;
                }
            }else
            {
                try
                {
                    
                    namefiles = this.openDialogFile();
                    List<AcselerometrData.StructAccselerometrData> listAcsData = this.getDataFromFile(namefiles);
                    listXYZ = this.getXYZ(listAcsData);
                    listTime = this.getTime(listAcsData);

                    listComplex = DFT.dft(listXYZ[0]);
                    listXYZ[0] = DFT.getArgument(listComplex);
                    listComplex = DFT.dft(listXYZ[1]);
                    listXYZ[1] = DFT.getArgument(listComplex);
                    listComplex = DFT.dft(listXYZ[2]);
                    listXYZ[2] = DFT.getArgument(listComplex);

                    this.drawMode(listXYZ, listTime, "phase");
                }
                catch (FileNotFoundException err)
                {
                    return;
                }
            }
        }
        //разбить на функции
        private void btn_furieAmplitude_Click(object sender, EventArgs e)
        {
            List<double>[] listXYZ;
            List<long> listTime;
            List<Complex> listComplex;
            string namefiles;
            if (dir)
            {
                try
                {
                    int namDirectory;
                    namefiles = this.openDialogDir();
                    namDirectory = new DirectoryInfo(namefiles).GetFiles().Length;
                    List<AcselerometrData.StructAccselerometrData> listAcsData;
                    for (int i = 0; i < namDirectory; ++i)
                    {
                        listAcsData = this.getDataFromFile(namefiles + "\\AccselerometrData" + i.ToString() + ".xml");
                        listXYZ = this.getXYZ(listAcsData);
                        listTime = this.getTime(listAcsData);

                        listComplex = DFT.dft(listXYZ[0]);
                        listXYZ[0] = DFT.getModule(listComplex);
                        listComplex = DFT.dft(listXYZ[1]);
                        listXYZ[1] = DFT.getModule(listComplex);
                        listComplex = DFT.dft(listXYZ[2]);
                        listXYZ[2] = DFT.getModule(listComplex);

                        this.drawMode(listXYZ, listTime, "phase" + i.ToString());
                    }
                }
                catch (DirectoryNotFoundException err)
                {
                    return;
                }
            }
            else
            {
                try
                {
                    namefiles = this.openDialogFile();
                    List<AcselerometrData.StructAccselerometrData> listAcsData = this.getDataFromFile(namefiles);
                    listXYZ = this.getXYZ(listAcsData);
                    listTime = this.getTime(listAcsData);

                    listComplex = DFT.dft(listXYZ[0]);
                    listXYZ[0] = DFT.getModule(listComplex);
                    listComplex = DFT.dft(listXYZ[1]);
                    listXYZ[1] = DFT.getModule(listComplex);
                    listComplex = DFT.dft(listXYZ[2]);
                    listXYZ[2] = DFT.getModule(listComplex);

                    this.drawMode(listXYZ, listTime, "phase");
                }
                catch (FileNotFoundException err)
                {
                    return;
                }
            }
        }

        private void btn_dir_Click(object sender, EventArgs e)
        {
            this.dir = !this.dir;
            this.btn_average.Enabled = this.dir;
        }

    }
}
