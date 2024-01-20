using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Değişkenler tanımlanıyor
        double s1, s2;// İşlem için kullanılacak sayıları saklamak için çift türde değişkenler
        string isaret;// Hangi matematiksel işlemi gerçekleştireceğimizi tutmak için bir dize değişkeni
        private object textBoxScreen;

        public object btn { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Rakamlar(object sender, EventArgs e)
        {
            // Butonun metnine göre sayıları ekrana yazma işlemi
            Button btn = (Button)sender;
            if (textBox1.Text != "0")
            {
                textBox1.Text += btn.Text;
            }
            else
            {
                textBox1.Clear();
                textBox1.Text += btn.Text;
            }
        }

        //private void buttn45_Click(object sender, EventArgs e)

        //İşlemler butonlarına tıklama olayı
        private void İslemler(object sender, EventArgs e)
        {


            //Butonun metine gö re matematiksel işlemleri gerçekleştirme işlemleri
            Button btn = (Button)sender;
            //Toplama işlemi
            if (btn.Text == "+")
            {
                if (s1 != 0)
                {
                    double sayi;
                    double.TryParse(textBox1.Text, out sayi);
                    textBox1.Text = (s1 + sayi).ToString();
                }
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = s1 + " " + isaret;
                textBox1.Text = "0";
            }
            //Çıkarma işlemi
            else if (btn.Text == "-")
            {
                if (s1 != 0)
                {
                    double sayi;
                    double.TryParse(textBox1.Text, out sayi);
                    textBox1.Text = (s1 - sayi).ToString();
                }
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = s1 + " " + isaret;
                textBox1.Text = "0";
            }
            //Bölme işlemi
            else if (btn.Text == "/")
            {
                if (s1 != 0)
                {
                    double sayi;
                    double.TryParse(textBox1.Text, out sayi);
                    if (sayi == 0) label1.Text = "Hata"; else textBox1.Text = (s1 / sayi).ToString();
                }
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = s1 + " " + isaret;
                textBox1.Text = "0";
            }
            //Çarpma işlemi
            else if (btn.Text == "*")
            {
                if (s1 != 0)
                {
                    double sayi;
                    double.TryParse(textBox1.Text, out sayi);
                    textBox1.Text = (s1 * sayi).ToString();
                }
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = s1 + " " + isaret;
                textBox1.Text = "0";
            }
            //Mod alma işlemi (yüzdelik)
            else if (btn.Text == "%")
            {
                double sayi;
                double.TryParse(textBox1.Text, out sayi);

                if (s1 != 0 && sayi != 0)
                {
                    textBox1.Text = (s1 * (sayi / 100)).ToString();
                }
                else
                {
                    label1.Text = "Hata: İşlem yapılamaz!";
                }

                s1 = double.Parse(textBox1.Text);
                isaret = btn.Text;
                label1.Text = s1 + " " + isaret;
                textBox1.Text = "0";
            }
            //Faktöriyel alma işlemi
            else if (btn.Text == "n!")
            {
                double sayi;
                double fakt = 1;
                double.TryParse(textBox1.Text, out sayi);
                try
                {
                    for (int i = 1; i <= sayi; i++)
                    {
                        fakt = fakt * i;
                    }
                    if (fakt.ToString() == "Infinity")
                    {
                        label1.Text = "Hata"; textBox1.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = fakt.ToString();
                        label1.Text = sayi + "!";
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = ex.Message;
                    textBox1.Text = "0";
                }
            }
            //Karekök alma işlemi
            else if (btn.Text == "√")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Sqrt(s1).ToString();
                label1.Text = "√" + s1;
            }
            //Küpkök alma işlemi
            else if (btn.Text == "³√")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Pow(s1, (double)1.0 / 3.0).ToString();//Math.Pow(s1, 0.333333333333333).ToString();//0.333333333333333 sayısı 1/3 ün sonucudur...
                label1.Text = "³√" + s1;
            }
            //Pi değeri
            else if (btn.Text == "PI")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.PI.ToString();
                label1.Text = "PI";
            }
            // Sinüs alma işlemi (radyan cinsinden)
            else if (btn.Text == "Sin")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Sin(Math.PI * s1 / 180).ToString();
                label1.Text = "Sin " + s1;
            }
            // Kosinüs alma işlemi (radyan cinsinden)
            else if (btn.Text == "Cos")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Cos(Math.PI * s1 / 180).ToString();
                label1.Text = "Cos " + s1;
            }
            // Tanjant alma işlemi (radyan cinsinden)
            else if (btn.Text == "Tan")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Tan(Math.PI * s1 / 180).ToString();
                label1.Text = "Tan " + s1;
            }
            //Kare alma işlemi
            else if (btn.Text == "x²")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = (s1 * s1).ToString();
                label1.Text = s1 + "²";
            }
            //Küp alma işlemi
            else if (btn.Text == "x³")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = (s1 * s1 * s1).ToString();
                label1.Text = s1 + "³";
            }
            // Üs alma işlemi için s1 ve işaret değişkenleri atanıyor
            else if (btn.Text == "Üs")
            {
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = s1 + "^";
                textBox1.Text = "0";
            }
            // Doğal logaritma alma işlemi
            else if (btn.Text == "ln")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Log(s1).ToString();
                label1.Text = "ln " + s1;
            }
            // 10 tabanında logaritma alma işlemi
            else if (btn.Text == "Log10")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.Log10(s1).ToString();
                label1.Text = "Log10 " + s1;
            }
            // Belirli bir tabanda logaritma alma işlemi için s1 ve işaret değişkenleri atanıyor
            else if (btn.Text == "Log(sy,tbn)")
            {
                double.TryParse(textBox1.Text, out s1);
                isaret = btn.Text;
                label1.Text = "Log(" + s1 + ",taban)";
                textBox1.Text = "0";
            }
            // Tersi alma işlemi
            else if (btn.Text == "1/x")
            {
                double.TryParse(textBox1.Text, out s1);
                label1.Text = "1/" + s1;
                if (s1 != 0) textBox1.Text = (1 / s1).ToString(); else label1.Text = "Hata";
            }
            // Euler sayısı (e)
            else if (btn.Text == "e")
            {
                double.TryParse(textBox1.Text, out s1);
                textBox1.Text = Math.E.ToString();
            }
            //Temizleme işlemi
            else if (btn.Text == "C")
            {
                s1 = 0;
                s2 = 0;
                isaret = "";
                textBox1.Text = "0";
                label1.Text = "";
            }
            // En son karakteri silme işlemi
            else if (btn.Text == "<-")
            {
                try
                {
                    if (textBox1.Text.Length != 0)
                    {
                        textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                        if (textBox1.Text.Length == 0)
                        {
                            textBox1.Text = "0";
                        }
                    }
                }
                catch
                { }
            }
            // Eşittir işlemi
            if (btn.Text == "=")
            {
                label1.Text = "";
                double.TryParse(textBox1.Text, out s2);
                if (isaret == "+") textBox1.Text = (s1 + s2).ToString();
                if (isaret == "-") textBox1.Text = (s1 - s2).ToString();
                if (isaret == "*") textBox1.Text = (s1 * s2).ToString();
                if (isaret == "/") if (s2 == 0) label1.Text = "Hata"; else textBox1.Text = (s1 / s2).ToString();
                if (isaret == "%") if (s2 == 0) label1.Text = "Hata"; else textBox1.Text = (s1 % s2).ToString();
                if (isaret == "Üs") textBox1.Text = Math.Pow(s1, s2).ToString();
                if (isaret == "Log(sy,tbn)") textBox1.Text = Math.Log(s1, s2).ToString();
            }
        }

        // Virgül butonuna tıklama olayı
        private void Virgul(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(",")) return;
            textBox1.Text += ",";

        }
    }
}


