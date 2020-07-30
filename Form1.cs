
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
using System.Diagnostics;
using System.Globalization;

namespace CSVReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        List<List<string>> listA;
        DataSet ds;
        DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            List<List<string>> listA = new List<List<string>>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("CsvFile");


            if (textBox1.Text != ""&&textBox2.Text!="")
            {
                string path = textBox1.Text;
                string spliter = textBox2.Text;
                char[] split = spliter.ToCharArray();
                using (var reader = new StreamReader(path))
                {
                    
                    int wiersze = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(split[0]);
                        listA.Add(new List<string>());
                        for (int x = 0; x < values.Length; x++)
                        {
                            listA[wiersze].Add(values[x]);
                        }

                        if (wiersze == 0)
                        {
                            for (int x = 0; x < values.Length; x++)
                            {
                                dt.Columns.Add(new DataColumn(listA[wiersze][x], typeof(string)));
                            }
                        }
                        else
                        {
                            DataRow dr = dt.NewRow();
                            for (int x = 0; x < values.Length; x++)
                            {
                                dr[listA[0][x]] = listA[wiersze][x];

                            }
                            dt.Rows.Add(dr);

                        }
                        wiersze++;



                    }
                    ds.Tables.Add(dt);
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = ds; // dataset
                    dataGridView1.DataMember = "CsvFile";

                    wiersze = 0;

                    Console.WriteLine(ds);


                }
            }
            else { textBox1.Text = ""; textBox2.Text = ""; MessageBox.Show("Set path/delimiter!"); }
               

           
           

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            string FilePath = AppDomain.CurrentDomain.BaseDirectory;
            
            string argument = "/select, \"" + FilePath + "\"";
            //Process.Start("explorer.exe", argument);

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = FilePath;
            this.openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<List<string>> listA = new List<List<string>>();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("CsvFile");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds; // dataset
    
            dataGridView1.Update();
            dataGridView1.Refresh();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
