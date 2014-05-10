using System;
//Created by Bartosz Chrominski aka Marvetick
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLADDER2003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string wynik;
        public string attr = "";
        private void button2_Click(object sender, EventArgs e)
        {
            string hw;
            string hextodec = Convert.ToInt32(textBox1.Text).ToString("X");
            if (int.Parse(textBox1.Text) < 10) { hw = "0" + hextodec; } else { hw = hextodec; }
            int n = comboBox1.SelectedIndex;
            string[] atrybuty = { "0", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0a", "0b", "0c", "0d", "0e", "0f","10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1a", "1b", "1c", "1d", "1e", "1f",
                                    "20","21","22","23","24","25","26","27","28","30","31","32","33","34","35","36","39","43","44","45","48"};
            attr = attr + atrybuty[n] + hw + "00";
            wynik = "INSERT INTO [RohanGame].[dbo].[TEventItem] (type, attr, char_id) VALUES (" + tbItemId.Text + ",0x" + attr + "," + textBox2.Text + ")";

            tbWynik.Text = wynik;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //button1.Text = "Connected";
                string server = @"";
                string userid = "sa";
                string password = "";
                string connection = "Data Source=" + server
                                    + ";User ID=" + userid + ";Password=" + password;
                SqlConnection conn = new SqlConnection(connection);

                SqlCommand sql = new SqlCommand(wynik, conn);
                sql.Connection = conn;
                conn.Open();
                sql.ExecuteNonQuery();

                MessageBox.Show("Item has been added to the database");
                try { conn.Close(); }
                catch { MessageBox.Show("Error disconnecting from DB"); }
            }
            catch { MessageBox.Show("Another SQL Error"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wynik = "";
            attr = "";
            tbWynik.Text = wynik;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
