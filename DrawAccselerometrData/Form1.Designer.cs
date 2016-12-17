namespace DrawAccselerometrData
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartFrame = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_draw_file = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.btn_average = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_drawX = new System.Windows.Forms.Button();
            this.btn_drawY = new System.Windows.Forms.Button();
            this.btn_drawZ = new System.Windows.Forms.Button();
            this.btn_drawXYZ = new System.Windows.Forms.Button();
            this.btn_vectorXYZ = new System.Windows.Forms.Button();
            this.btn_furieAmplitude = new System.Windows.Forms.Button();
            this.btn_furiePhase = new System.Windows.Forms.Button();
            this.btn_dir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFrame
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFrame.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartFrame.Legends.Add(legend1);
            this.chartFrame.Location = new System.Drawing.Point(0, 1);
            this.chartFrame.Name = "chartFrame";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartFrame.Series.Add(series1);
            this.chartFrame.Size = new System.Drawing.Size(1621, 938);
            this.chartFrame.TabIndex = 0;
            this.chartFrame.Text = "drawFrame";
            // 
            // btn_draw_file
            // 
            this.btn_draw_file.Location = new System.Drawing.Point(1627, 1);
            this.btn_draw_file.Name = "btn_draw_file";
            this.btn_draw_file.Size = new System.Drawing.Size(273, 74);
            this.btn_draw_file.TabIndex = 1;
            this.btn_draw_file.Text = "draw file";
            this.btn_draw_file.UseVisualStyleBackColor = true;
            this.btn_draw_file.Click += new System.EventHandler(this.btn_draw_file_Click);
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(1628, 81);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(273, 78);
            this.btn_color.TabIndex = 3;
            this.btn_color.Text = "Red";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // btn_average
            // 
            this.btn_average.Location = new System.Drawing.Point(1627, 165);
            this.btn_average.Name = "btn_average";
            this.btn_average.Size = new System.Drawing.Size(273, 75);
            this.btn_average.TabIndex = 4;
            this.btn_average.Text = "Average";
            this.btn_average.UseVisualStyleBackColor = true;
            this.btn_average.Click += new System.EventHandler(this.btn_average_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1627, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 74);
            this.button1.TabIndex = 5;
            this.button1.Text = "clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_clear);
            // 
            // btn_drawX
            // 
            this.btn_drawX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_drawX.Location = new System.Drawing.Point(1627, 326);
            this.btn_drawX.Name = "btn_drawX";
            this.btn_drawX.Size = new System.Drawing.Size(75, 57);
            this.btn_drawX.TabIndex = 6;
            this.btn_drawX.Text = "X";
            this.btn_drawX.UseVisualStyleBackColor = true;
            this.btn_drawX.Click += new System.EventHandler(this.btn_drawX_Click);
            // 
            // btn_drawY
            // 
            this.btn_drawY.Location = new System.Drawing.Point(1726, 326);
            this.btn_drawY.Name = "btn_drawY";
            this.btn_drawY.Size = new System.Drawing.Size(75, 57);
            this.btn_drawY.TabIndex = 7;
            this.btn_drawY.Text = "Y";
            this.btn_drawY.UseVisualStyleBackColor = true;
            this.btn_drawY.Click += new System.EventHandler(this.btn_drawY_Click);
            // 
            // btn_drawZ
            // 
            this.btn_drawZ.Location = new System.Drawing.Point(1825, 326);
            this.btn_drawZ.Name = "btn_drawZ";
            this.btn_drawZ.Size = new System.Drawing.Size(75, 57);
            this.btn_drawZ.TabIndex = 8;
            this.btn_drawZ.Text = "Z";
            this.btn_drawZ.UseVisualStyleBackColor = true;
            this.btn_drawZ.Click += new System.EventHandler(this.btn_drawZ_Click);
            // 
            // btn_drawXYZ
            // 
            this.btn_drawXYZ.Location = new System.Drawing.Point(1628, 389);
            this.btn_drawXYZ.Name = "btn_drawXYZ";
            this.btn_drawXYZ.Size = new System.Drawing.Size(76, 54);
            this.btn_drawXYZ.TabIndex = 9;
            this.btn_drawXYZ.Text = "ALL";
            this.btn_drawXYZ.UseVisualStyleBackColor = true;
            this.btn_drawXYZ.Click += new System.EventHandler(this.btn_drawXYZ_Click);
            // 
            // btn_vectorXYZ
            // 
            this.btn_vectorXYZ.Location = new System.Drawing.Point(1826, 389);
            this.btn_vectorXYZ.Name = "btn_vectorXYZ";
            this.btn_vectorXYZ.Size = new System.Drawing.Size(75, 54);
            this.btn_vectorXYZ.TabIndex = 11;
            this.btn_vectorXYZ.Text = "Vector XYZ";
            this.btn_vectorXYZ.UseVisualStyleBackColor = true;
            this.btn_vectorXYZ.Click += new System.EventHandler(this.btn_vectorXYZ_Click);
            // 
            // btn_furieAmplitude
            // 
            this.btn_furieAmplitude.Location = new System.Drawing.Point(1635, 448);
            this.btn_furieAmplitude.Name = "btn_furieAmplitude";
            this.btn_furieAmplitude.Size = new System.Drawing.Size(122, 72);
            this.btn_furieAmplitude.TabIndex = 12;
            this.btn_furieAmplitude.Text = "Amplitude";
            this.btn_furieAmplitude.UseVisualStyleBackColor = true;
            this.btn_furieAmplitude.Click += new System.EventHandler(this.btn_furieAmplitude_Click);
            // 
            // btn_furiePhase
            // 
            this.btn_furiePhase.Location = new System.Drawing.Point(1772, 449);
            this.btn_furiePhase.Name = "btn_furiePhase";
            this.btn_furiePhase.Size = new System.Drawing.Size(128, 71);
            this.btn_furiePhase.TabIndex = 13;
            this.btn_furiePhase.Text = "Phase";
            this.btn_furiePhase.UseVisualStyleBackColor = true;
            this.btn_furiePhase.Click += new System.EventHandler(this.btn_furiePhase_Click);
            // 
            // btn_dir
            // 
            this.btn_dir.Location = new System.Drawing.Point(1726, 389);
            this.btn_dir.Name = "btn_dir";
            this.btn_dir.Size = new System.Drawing.Size(75, 54);
            this.btn_dir.TabIndex = 14;
            this.btn_dir.Text = "Dir";
            this.btn_dir.UseVisualStyleBackColor = true;
            this.btn_dir.Click += new System.EventHandler(this.btn_dir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1912, 951);
            this.Controls.Add(this.btn_dir);
            this.Controls.Add(this.btn_furiePhase);
            this.Controls.Add(this.btn_furieAmplitude);
            this.Controls.Add(this.btn_vectorXYZ);
            this.Controls.Add(this.btn_drawXYZ);
            this.Controls.Add(this.btn_drawZ);
            this.Controls.Add(this.btn_drawY);
            this.Controls.Add(this.btn_drawX);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_average);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_draw_file);
            this.Controls.Add(this.chartFrame);
            this.Name = "Form1";
            this.Text = "Red-X, Blue-Y, Green-Z";
            ((System.ComponentModel.ISupportInitialize)(this.chartFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFrame;
        private System.Windows.Forms.Button btn_draw_file;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_average;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_drawX;
        private System.Windows.Forms.Button btn_drawY;
        private System.Windows.Forms.Button btn_drawZ;
        private System.Windows.Forms.Button btn_drawXYZ;
        private System.Windows.Forms.Button btn_vectorXYZ;
        private System.Windows.Forms.Button btn_furieAmplitude;
        private System.Windows.Forms.Button btn_furiePhase;
        private System.Windows.Forms.Button btn_dir;
    }
}

