using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ПространствоПотоковогоШифровщика;

namespace ТестированиеПотоковогоШифровщикаББШ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ПотоковыйШифровщикББШ ББШ1 = new ПотоковыйШифровщикББШ(3+1, 9);
            byte x1 = ББШ1.ПолучитьБайтББШ();
            ПотоковыйШифровщикББШ ББШ2 = new ПотоковыйШифровщикББШ(3, 9);
            byte x0_2 = ББШ2.ПолучитьБайтББШ();
            byte x1_2 = ББШ2.ПолучитьБайтББШ();

            txt.AppendText(x1.ToString()+"\n");
            txt.AppendText("---" + "\n");
            txt.AppendText(x0_2.ToString() + "\n");
            txt.AppendText(x1_2.ToString() + "\n");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ПотоковыйШифровщикББШ ББШ1 = new ПотоковыйШифровщикББШ(482605545662635574, 9);
            byte x1 = ББШ1.ПолучитьБайтББШ();
            ПотоковыйШифровщикББШ ББШ2 = new ПотоковыйШифровщикББШ(482605545662635574-1, 9);
            byte x0_2 = ББШ2.ПолучитьБайтББШ();
            byte x1_2 = ББШ2.ПолучитьБайтББШ();
            ПотоковыйШифровщикББШ ББШ3 = new ПотоковыйШифровщикББШ(0, 9);
            byte x1_3 = ББШ3.ПолучитьБайтББШ();
            byte x2_3 = ББШ3.ПолучитьБайтББШ();

            txt.AppendText(x1.ToString() + "\n");
            txt.AppendText("---" + "\n");
            txt.AppendText(x0_2.ToString() + "\n");
            txt.AppendText(x1_2.ToString() + "\n");
            txt.AppendText("---" + "\n");
            txt.AppendText(x1_3.ToString() + "\n");
            txt.AppendText(x2_3.ToString() + "\n");
            

        }

        public double МаксимумВМассиве(UInt64[] a)
        {
            UInt64 tmp = UInt64.MinValue; // 0 :)
            for (int i = 0; i < a.Length; i++)
                if (a[i] > tmp) tmp = a[i];
            return (double)tmp;
        }
        public double МинимумВМассиве(UInt64[] a)
        {
            UInt64 tmp = UInt64.MaxValue;
            for (int i = 0; i < a.Length; i++)
                if (a[i] < tmp) tmp = a[i];
            return (double)tmp;
        }

        ПотоковыйШифровщикББШ ББШ1 = new ПотоковыйШифровщикББШ(0, 9);
        private void button3_Click(object sender, EventArgs e)
        {


            txt.AppendText("ГистограммаНеравномерностиСтатистикиБайт" + "\n"); 
            {
                string ЗаголовокТаблицы = "";
                for (int i = 0; i < 256; i++)
                {
                    ЗаголовокТаблицы = ЗаголовокТаблицы + i.ToString("000") + " ";
                }
                ЗаголовокТаблицы = ЗаголовокТаблицы + ";";
                txt.AppendText(ЗаголовокТаблицы + "\n");
            }


            UInt64 ВсегоБайтСформировано = 0;
            UInt64 СуммаВсехБайт = 0;
            for (UInt64 ШагТестирования = 0; ШагТестирования < 10; ШагТестирования++)
            {
                UInt64[] гистограмма = new UInt64[256];
                for (int ИтерацийНаШаг = 0; ИтерацийНаШаг < 1000000; ИтерацийНаШаг++)
                {
                    byte x1 = ББШ1.ПолучитьБайтББШ();
                    гистограмма[x1]++;
                    СуммаВсехБайт += x1;
                    ВсегоБайтСформировано++;
                    if (ИтерацийНаШаг % 1000 == 0)
                    {
                        Application.DoEvents();                        
                    }
                }

                string ГистограммаНеравномерностиСтатистикиБайт = "";
                double ming = МинимумВМассиве(гистограмма);
                double maxg = МаксимумВМассиве(гистограмма);
                for (int i = 0;i<256;i++)
                {
                    ГистограммаНеравномерностиСтатистикиБайт = ГистограммаНеравномерностиСтатистикиБайт + ((int)(((double)гистограмма[i]- ming) * 100.0 / (maxg-ming))).ToString("000") + " ";
                }
                ГистограммаНеравномерностиСтатистикиБайт = ГистограммаНеравномерностиСтатистикиБайт + ";";
                if (txt.IsDisposed)
                    return;
                txt.AppendText(ГистограммаНеравномерностиСтатистикиБайт + "\n");

                //ББШ1.ТелепортерНаНомерВПоследовательности((ШагТестирования+1) * 6626355);
                Application.DoEvents();
                Application.DoEvents();
                Application.DoEvents();
            }
            txt.AppendText("Готово" + "\n");
            double СреднееПоВсемСформированнымБайтам = (double)СуммаВсехБайт / (double)ВсегоБайтСформировано;
            txt.AppendText("ВсегоБайтСформировано " + ВсегоБайтСформировано.ToString("### ### ###") + "\n");            
            txt.AppendText("СреднееПоВсемСформированнымБайтам " + СреднееПоВсемСформированнымБайтам.ToString("###.#######") + "\n");


        }
    }
}
