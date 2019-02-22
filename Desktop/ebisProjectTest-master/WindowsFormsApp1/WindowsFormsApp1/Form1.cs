using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class msme : Form
    {
        public msme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ViewClientForm();
        }
        public void ViewClientForm()
        {
            try
            {
                
                GetDataC dataToGet = new GetDataC();
                foreach (DataRow r in dataToGet.ViewClient().Rows)
                {
                    dataGridView1.Rows.Add(r["business_name"].ToString(), r["status"].ToString(), r["clients_name"].ToString(), r["barangay_name"].ToString(), r["municipal_name"].ToString(), r["region_name"].ToString(), r["province_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            GetDataC gdataC = new GetDataC();
            if(textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("Please choose a specific destination");
            }
            else
            {
                try
                {
                    gdataC.writeCSV(dataGridView1, textBox1.Text + "\\result.csv");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Converted successfully to *.csv format in " + textBox1.Text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseFolder();

        }
        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                GetDataC getDataC = new GetDataC();
                getDataC.Destination = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
