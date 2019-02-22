using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    class GetDataC : Connection
    {
        private MySqlCommand com;
        public DataTable dt;
        public MySqlDataAdapter adp;
        public string Destination { get; set; }
        public DataTable ViewClient()
        {
            base.GetConnection().Open();
            com = base.GetConnection().CreateCommand();
            com.CommandText = "SELECT msme.business_name, msme.status, msme_contacts.`name` AS clients_name,barangay.`name` AS barangay_name, city_municipal.`name` AS municipal_name, msme.`region` AS region_name, province.`name` AS province_name FROM ((((msme_contacts INNER JOIN msme ON msme.ur_id = msme_contacts.ur_id) INNER JOIN barangay ON barangay.`idbarangay` = msme.`barangay`) INNER JOIN city_municipal ON city_municipal.`idcity_municipal` = msme.`municipality_city`) INNER JOIN province ON province.`idprovince` = msme.`province`); ";
     
            adp = new MySqlDataAdapter(com);
            dt = new DataTable();
            adp.Fill(dt);
            base.GetConnection().Close();
            return dt;
        }
        public void writeCSV(DataGridView gridIn, string outputFile)
        {
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                string str = null;
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(outputFile);

                //write header rows to csv
                for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridIn.Columns[i].HeaderText);
                }

                swOut.WriteLine();

                //write DataGridView rows to csv
                for (int j = 0; j <= gridIn.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridIn.Rows[j];

                    for (int i = 0; i <= gridIn.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }
                        if(dr.Cells[i].Value == null)
                        {
                            str = "null";
                        }
                        else
                        {
                            str = dr.Cells[i].Value.ToString();
                        }
                        //replace comma's with spaces
                        str = str.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        str = str.Replace(Environment.NewLine, " ");

                        swOut.Write(str);
                    }
                }
                swOut.Close();
            }
        }
    }
}
