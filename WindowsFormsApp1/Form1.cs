using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] jsonVerileri, bugunkiKoronaCozumle; //2 adet dizi oluşturduk

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://raw.githubusercontent.com/ozanerturk/covid19-turkey-api/master/dataset/timeline.json");
                //güncel verileri tutan json belgesini var değişkene aktardık
                jsonVerileri = json.ToString().Split('{');
                //{ işareti ile ayırarak bir diziye aktardık
            }
            bugunkiKoronaCozumle = jsonVerileri[jsonVerileri.Length - 1].Split('"');
            //json verisi günlük güncellendi için ve her defasında son sıradaki veride işlem yaptımız için
            //güncel veriyi verecektir.
            //son günün verisini " işareti ayırarak başka bi diziye aktardık

            label6.Text = bugunkiKoronaCozumle[3];
            label7.Text = bugunkiKoronaCozumle[31];
            //dizideki sıraya göre ölüm sayısı , vaka sayısı gibi sayıları bulup gerekli sıraya koyduk
            label8.Text = bugunkiKoronaCozumle[35];
            label9.Text = bugunkiKoronaCozumle[51];
            label10.Text = bugunkiKoronaCozumle[55];
        }
    }
}
