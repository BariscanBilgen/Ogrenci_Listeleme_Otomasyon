using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ders6_Listeleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = kayit_sayisi().ToString();
        }
        public int kayit_sayisi()
        {
            return listView1.Items.Count;
        }

        private void ekle(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", yas = "", mezuniyet = "", cinsiyet = "", telefon = "";
            tc = textBox1.Text;
            adsoyad = textBox2.Text;
            mezuniyet = comboBox1.Text;
            yas = textBox3.Text;
            telefon = textBox5.Text;
            if (radioButton1.Checked)
            {
                cinsiyet = radioButton1.Text;
            }
            else cinsiyet = radioButton2.Text;

            string[] bilgiler= {tc, adsoyad, yas, mezuniyet,cinsiyet, telefon};

            bool kayitvarmi = false;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == tc)
                {
                    kayitvarmi = true;
                    MessageBox.Show("Bu Tc zaten kayıtlıdır!");
                }
            }

            if (kayitvarmi!=true)
            {
                ListViewItem list = new ListViewItem(bilgiler);
                if (tc != "" && adsoyad != "" && yas != "" && mezuniyet != "" && cinsiyet != "" && telefon != "")
                {
                    listView1.Items.Add(list);
                    label6.Text = kayit_sayisi().ToString();

                }
                else
                    MessageBox.Show("Formda boş alanlar bırakmayınız");
                
            }

        }

        private void sil(object sender, EventArgs e)
        {
            var sayi=listView1.SelectedItems.Count;
            if (sayi!=0)
            {
                var secilen = listView1.SelectedItems[0];
                listView1.Items.Remove(secilen);
                label6.Text = kayit_sayisi().ToString();
            }
            else
                MessageBox.Show("Silmek için bir satır seçmelisiniz!");
        }

        private void tumunusil(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.Items)
            {
                item.Remove();
            }
            label6.Text = kayit_sayisi().ToString();
        }

        
    }
}
