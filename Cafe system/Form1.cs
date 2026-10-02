using System;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Cafe_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox2.Click += (s, e) => SəbətəƏlavəEt("Burger-5.55");
            pictureBox3.Click += (s, e) => SəbətəƏlavəEt("Cake-3.10");
            pictureBox4.Click += (s, e) => SəbətəƏlavəEt("Fruit juice-1.40");
            pictureBox5.Click += (s, e) => SəbətəƏlavəEt("Cupcake-4.0");
            pictureBox6.Click += (s, e) => SəbətəƏlavəEt("Pizza-6.10");
            pictureBox7.Click += (s, e) => SəbətəƏlavəEt("Cookie-2.70");
            pictureBox8.Click += (s, e) => SəbətəƏlavəEt("Hot-dog-3.30");
            pictureBox9.Click += (s, e) => SəbətəƏlavəEt("Sandwich-5.50");
            pictureBox10.Click += (s, e) => SəbətəƏlavəEt("Cola-2.30");
        }

        private void SəbətəƏlavəEt(string yemekVəQiymət)
        {
            listBox1.Items.Add(yemekVəQiymət);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string silinenYemek = listBox1.SelectedItem.ToString();
                if (silinenYemek.Contains("-"))
                {
                    silinenYemek = silinenYemek.Split('-')[0];
                }
                listBox1.Items.Remove(listBox1.SelectedItem);
                MessageBox.Show($"{silinenYemek} səbətdən silindi", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Zehmet olmasa, silmək üçün səbətdən bir yemək seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show("Xanalar sıfırlansınmı?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                listBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Səbətdə yemək yoxdur!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Text = "";
            }
            else
            {
                decimal toplam = 0;

                foreach (var item in listBox1.Items)
                {
                    string metn = item.ToString();

                    if (metn.Contains("-"))
                    {
                        string[] hisseler = metn.Split('-');
                        if (hisseler.Length > 1 && decimal.TryParse(hisseler[1], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal qiymet))
                        {
                            toplam += qiymet;
                        }
                    }
                }

                textBox4.Text = toplam.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Əvvəlcə Yekun hesabı hesablayın!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal daxilEdilenMablag))
            {
                MessageBox.Show("Zəhmət olmasa, 'Məbləğ' xanasına düzgün rəqəm daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(textBox4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal hesabMablagi);

            if (daxilEdilenMablag < hesabMablagi)
            {
                MessageBox.Show("Daxil edilən məbləğ hesabdan azdır", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Clear();
            }
            else
            {
                decimal qaliq = daxilEdilenMablag - hesabMablagi;
                textBox3.Text = qaliq.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}