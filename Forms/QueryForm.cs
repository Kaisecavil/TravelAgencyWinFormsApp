//using Microsoft.Office.Interop.Word;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyEFRepository.Factory;
using TravelAgencyEFRepository.Models;
using TravelAgencyRepository.DataBase;
using TravelAgencyRepository.Models;
using Application = Microsoft.Office.Interop.Word.Application;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            //dataGridView1.Columns[0].Visible = false;

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
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
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
                dataGridView1.Columns[0].Visible = false;
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
                dataGridView1.Columns[0].Visible = false;
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
                    dataGridView1.Columns[0].Visible = false;
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Error", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DateTime.Now.ToString("d");
            var dt = (DataTable)dataGridView1.DataSource;
            dt.TableName = "Query";
            MainForm.WordDocxTable(dt);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                SqlCommand cmd = new SqlCommand("GpoupQuery", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = true;
            }
        }

        private void QueryForm_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e) { }

        private void button8_Click(object sender, EventArgs e)
        {
            string title = textBox2.Text;
            //Работники с заданной должностью
            try
            {
                int postId = EFRepositoryFactory.PostRepo.GetEntities().Where(p => p.Title == title).FirstOrDefault().Id;
                if (postId != 0)
                {
                    var result = EFRepositoryFactory.EmployeeRepo.GetEntities().Where(e => e.PostId == postId);
                    dataGridView1.DataSource = result.ToList();
                    //dataGridView1.Columns[0].Visible = true;
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Not found", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show($"не найдено должности  - {title}", "",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            decimal minSalary = 1400;
            try
            {
                minSalary = Convert.ToDecimal(textBox2.Text);
            }
            catch(Exception ex)
            {
                DialogResult result = MessageBox.Show($"{ex.Message}", "",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var postIdList = EFRepositoryFactory.PostRepo.GetEntities().Where(p => p.Salary > minSalary).Select(p => p.Id).ToList();
            var employeeList = EFRepositoryFactory.EmployeeRepo.GetEntities().Where(e => postIdList.Contains(e.PostId)).ToList();
            if (!employeeList.IsNullOrEmpty())
            {
                dataGridView1.DataSource = employeeList;
                //dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                DialogResult result = MessageBox.Show($"Not Found", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            var employeeList = EFRepositoryFactory.EmployeeRepo.GetEntities().Where(e => e.FirstName == name).ToList();
            if (!employeeList.IsNullOrEmpty())
            {
                dataGridView1.DataSource = employeeList;
                //dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                DialogResult result = MessageBox.Show($"Not Found", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

