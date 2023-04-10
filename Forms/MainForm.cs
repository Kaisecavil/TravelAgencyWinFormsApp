using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using TravelAgencyRepository.DataBase;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Interfaces;
using TravelAgencyRepository.Models;
using TravelAgencyWinFormsApp.Forms;

namespace TravelAgencyWinFormsApp
{
    public partial class MainForm : Form
    {
        private EnumTables currentTable = EnumTables.None;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ÔÓ‰‡Ê‡“Û‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TourSale;
            UpdateDataViewDataSource();
        }

        private void ÍÎËÂÌÚToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Client;
            UpdateDataViewDataSource();
        }

        private void ‚Ë‰“‡ÌÒÔÓÚ‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TransportKind;
            UpdateDataViewDataSource();
        }

        private void ‚Ë‰“Û‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TourKind;
            UpdateDataViewDataSource();
        }

        private void ÒÓÚÛ‰ÌËÍToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Employee;
            UpdateDataViewDataSource();
        }

        private void ÍÛÓÚToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Resort;
            UpdateDataViewDataSource();
        }

        private void ÒÚ‡Ì‡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Country;
            UpdateDataViewDataSource();
        }

        private void ‰ÓÎÊÌÓÒÚ¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Post;
            UpdateDataViewDataSource();
        }

        private void ÚÛToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Tour;
            UpdateDataViewDataSource();
        }

        private void ÓÚÂÎ¸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Hotel;
            UpdateDataViewDataSource();
        }

        private void „ÓÓ‰ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.City;
            UpdateDataViewDataSource();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            CreateBtn.Enabled = true;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            Form form = this;
            switch (currentTable)
            {
                case EnumTables.Client:
                    form = new ClientForm(this);                  
                    break;

                case EnumTables.TourSale:
                    form = new TourSaleForm(this);                 
                    break;

                case EnumTables.Post:
                    form = new PostForm(this);                   
                    break;

                case EnumTables.Tour:
                    form = new TourForm(this);                   
                    break;

                case EnumTables.TransportKind:
                    form = new TransportKindForm(this);                   
                    break;

                case EnumTables.Hotel:
                    form = new HotelForm(this);
                    break;

                case EnumTables.TourKind:
                    form = new TourKindForm(this);
                    break;

                case EnumTables.City:
                    form = new CityForm(this);
                    break;

                case EnumTables.Resort:
                    form = new ResortForm(this);
                    break;

                case EnumTables.Country:
                    form = new CountryForm(this);
                    break;

                case EnumTables.Employee:
                    form = new EmployeeForm(this);
                    break;



            }
            form.Show();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            List<int> idList = null;
            switch (currentTable)
            {
                case EnumTables.Client:
                    idList = TravelAgencyConverter.DataGridViewSelctedRowsToClientList(dataGridView1.SelectedRows).Select(i => i.Id).ToList();
                    DeleteEntityes(idList, RepositoryFactory.ClientRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Hotel:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.HotelRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Employee:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.EmployeeRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Resort:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.ResortRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Country:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.CountryRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.TourKind:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.TourKindRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Tour:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.TourRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.TourSale:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.TourSaleRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.Post:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.PostRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.TransportKind:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.TransportKindRepo);
                    UpdateDataViewDataSource();
                    break;

                case EnumTables.City:
                    idList = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows);
                    DeleteEntityes(idList, RepositoryFactory.CityRepo);
                    UpdateDataViewDataSource();
                    break;

            }
        }

        private void DeleteEntityes<T>(List<int> idList, IGenericRepository<T> repository)
        {

            foreach (var id in idList)
            {
                T entity = repository.GetEntitybyId(id);
                if (entity != null)
                {
                    DialogResult result = MessageBox.Show($"”‰‡ÎˇÂÏ Á‡ÔËÒ¸ [{entity}]?", "",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        repository.Delete(id);
                    }
                }

            }
           
        }

        

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //var id = TravelAgencyConverter.DataGridViewSelctedRowsToClientList(dataGridView1.SelectedRows).Select(i => i.Id).First();
            int id = TravelAgencyConverter.DataGridToId(dataGridView1.SelectedRows).First();
            Form form = new Form();
            switch (currentTable)
            {
                case EnumTables.Client:
                    form = new ClientForm(this,id);
                    break;

                case EnumTables.TourSale:
                    form = new TourSaleForm(this,id);
                    break;

                case EnumTables.Post:
                    form = new PostForm(this,id);                  
                    break;

                case EnumTables.Tour:
                    form = new TourForm(this,id);                   
                    break;

                case EnumTables.TransportKind:
                    form = new TransportKindForm(this, id);                   
                    break;

                case EnumTables.Hotel:
                    form = new HotelForm(this, id);                  
                    break;

                case EnumTables.TourKind:
                    form = new TourKindForm(this, id);
                    break;

                case EnumTables.City:
                    form = new CityForm(this, id);
                    break;

                case EnumTables.Resort:
                    form = new ResortForm(this, id);
                    break;

                case EnumTables.Country:
                    form = new CountryForm(this, id);
                    break;

                case EnumTables.Employee:
                    form = new EmployeeForm(this, id);
                    break;

            }
            form.Show();
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                DeleteBtn.Enabled = false;
                UpdateBtn.Enabled = false;
                CreateBtn.Enabled = false;
            }

            else if (dataGridView1.SelectedRows.Count == 1)
            {
                DeleteBtn.Enabled = true;
                UpdateBtn.Enabled = true;
                CreateBtn.Enabled = true;
            }

            else if (dataGridView1.SelectedRows.Count > 1)
            {
                DeleteBtn.Enabled = true;
                UpdateBtn.Enabled = false;
                CreateBtn.Enabled = false;
            }
        }

        public void UpdateDataViewDataSource()
        {
            DataTable dataTable= new DataTable();
            switch (currentTable)
            {
                case EnumTables.Client:
                    dataGridView1.DataSource = RepositoryFactory.ClientRepo.GetDataTableView();
                    //dataTable = RepositoryFactory.ClientRepo.GetDataTableView();
                    //button1.Text = dataTable.TableName;
                    //dataGridView1.DataSource = RepositoryFactory.ClientRepo.GetDataTableView();
                    //List<string> strings = new List<string>();
                    //foreach (DataColumn col in dataTable.Columns)
                    //{
                    //    strings.Add(col.ColumnName);
                    //}
                    //DataTable t = (DataTable)dataGridView1.DataSource;
                    //comboBox1.DataSource = strings.Skip(1).ToList();
                    break;
                case EnumTables.TourSale:
                    dataGridView1.DataSource = RepositoryFactory.TourSaleRepo.GetDataTableView();
                    break;
                case EnumTables.TransportKind:
                    dataGridView1.DataSource = RepositoryFactory.TransportKindRepo.GetDataTableView();
                    break;
                case EnumTables.TourKind:
                    dataGridView1.DataSource = RepositoryFactory.TourKindRepo.GetDataTableView();
                    break;
                case EnumTables.Country:
                    dataGridView1.DataSource = RepositoryFactory.CountryRepo.GetDataTableView();
                    break;
                case EnumTables.Employee:
                    dataGridView1.DataSource = RepositoryFactory.EmployeeRepo.GetDataTableView();
                    break;
                case EnumTables.Post:
                    dataGridView1.DataSource = RepositoryFactory.PostRepo.GetDataTableView();
                    break;
                case EnumTables.Resort:
                    dataGridView1.DataSource = RepositoryFactory.ResortRepo.GetDataTableView();
                    break;
                case EnumTables.Tour:
                    dataGridView1.DataSource = RepositoryFactory.TourRepo.GetDataTableView();
                    break;
                case EnumTables.Hotel:
                    dataGridView1.DataSource = RepositoryFactory.HotelRepo.GetDataTableView();
                    break;
                case EnumTables.City:
                    dataGridView1.DataSource = RepositoryFactory.CityRepo.GetDataTableView();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = RepositoryFactory.CityRepo.GetDataTableFilteredByName("¿ÎÛÔÍ‡");
        }
    }
}