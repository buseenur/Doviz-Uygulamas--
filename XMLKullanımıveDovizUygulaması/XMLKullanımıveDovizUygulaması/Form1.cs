using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLKullanımıveDovizUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya=new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolrAls.Text = dolaralıs;

            string dolarsatıs=xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml.ToString();
            LblDolrSts.Text = dolarsatıs;

            string euroalıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAls.Text = euroalıs;

            string eurosatıs = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSats.Text = eurosatıs;
        }

        private void BtnDlrAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolrAls.Text;
        }

        private void BtnDlarSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text=LblDolrSts.Text;
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroAls.Text;
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroSats.Text;
        }

        private void BtnIslem1_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar=Convert.ToDouble(TxtMiktar.Text);
            tutar = kur * miktar;
            TxtTutar.Text = tutar.ToString();
        }

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");
        }

        private void BtnIslem2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(TxtKur.Text);
            int miktar=Convert.ToInt32(TxtMiktar.Text);
            int tutar =Convert.ToInt32( miktar / kur);
            TxtTutar.Text=tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            TxtKalan.Text =kalan.ToString();

        }
    }
}
