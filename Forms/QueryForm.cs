using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyRepository.DataBase;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            dataGridView1.Columns[0].Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("CurrentAndPreviousYearTourSales", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@XmlStr", Xm);
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                dataGridView1.DataSource= dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("MVEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@quantityOfSales", numericUpDown1.Value);
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("TourDuration", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@duration", numericUpDown2.Value);
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("ClientTours", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pass", textBox1.Text);
                DataTable dataTable = new DataTable();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dataTable.Load(sqlDataReader);
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Error", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }
    }
}
