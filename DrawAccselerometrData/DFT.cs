using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawAccselerometrData
{
    class DFT
    {
        /*
         * 
         * Возращает связный список комплексных чисел(результат преобразования Фурье)
         * На вход получает связный список значений акселерометра
         * 
         */
        public static List<Complex> dft(List<double> al)
        {
            int k;
            int n;
            int size = al.Count();
            double buf;
            Complex com = new Complex(0, 0);
            List<Complex> ou = new List<Complex>();

            for (k = 0; k < size; ++k)
            {
                for (n = 0; n < size; ++n)
                {
                    buf = (-1) * 2 * Math.PI * k * n / size;
                    com.sum(new Complex(al[n] * Math.Cos(buf),
                            al[n] * Math.Sin(buf)));
                }
                ou.Add(com);
                com = new Complex(0, 0);
            }
            return ou;
        }

        public static List<double> getArgument(List<Complex> com)
        {
            List<double> ret = new List<double>();
            for (int i = 0; i < com.Count; ++i)
            {
                ret.Add(com[i].arg());
            }
            return ret;
        }

        public static List<double> getModule(List<Complex> com)
        {
            List<double> ret = new List<double>();
            for (int i = 0; i < com.Count; ++i)
            {
                ret.Add(com[i].mod());
            }
            return ret;
        }

        public static List<double> getFrec(List<long> time)
        {
            List<double> frec = new List<double>();
            for(int i = 0; i < time.Count; ++i)
            {
                frec.Add(1 / time[i]);
            }
            return frec;
        }
    }
}
