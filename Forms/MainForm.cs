using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using TravelAgencyRepository.DataBase;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Interfaces;
using TravelAgencyRepository.Models;
using TravelAgencyWinFormsApp.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Application = Microsoft.Office.Interop.Word.Application;

namespace TravelAgencyWinFormsApp
{
    public partial class MainForm : Form
    {
        private EnumTables currentTable = EnumTables.None;
        public MainForm()
        {
            InitializeComponent();
        }

        private void продажаТураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TourSale;
            UpdateDataViewDataSource();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Client;
            UpdateDataViewDataSource();
        }

        private void видТранспортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TransportKind;
            UpdateDataViewDataSource();
        }

        private void видТураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.TourKind;
            UpdateDataViewDataSource();
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Employee;
            UpdateDataViewDataSource();
        }

        private void курортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Resort;
            UpdateDataViewDataSource();
        }

        private void странаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Country;
            UpdateDataViewDataSource();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Post;
            UpdateDataViewDataSource();
        }

        private void турToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Tour;
            UpdateDataViewDataSource();
        }

        private void отельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = EnumTables.Hotel;
            UpdateDataViewDataSource();
        }

        private void городToolStripMenuItem_Click(object sender, EventArgs e)
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
                    DialogResult result = MessageBox.Show($"Удаляем запись [{entity}]?", "",
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
                    form = new ClientForm(this, id);
                    break;

                case EnumTables.TourSale:
                    form = new TourSaleForm(this, id);
                    break;

                case EnumTables.Post:
                    form = new PostForm(this, id);
                    break;

                case EnumTables.Tour:
                    form = new TourForm(this, id);
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
            System.Data.DataTable dataTable = new System.Data.DataTable();
            switch (currentTable)
            {
                case EnumTables.Client:
                    dataTable = RepositoryFactory.ClientRepo.GetDataTableView();
                    break;
                case EnumTables.TourSale:
                    dataTable = RepositoryFactory.TourSaleRepo.GetDataTableView();
                    dataTable.TableName = "TourSaleView";
                    break;
                case EnumTables.TransportKind:
                    dataTable = RepositoryFactory.TransportKindRepo.GetDataTableView();
                    break;
                case EnumTables.TourKind:
                    dataTable = RepositoryFactory.TourKindRepo.GetDataTableView();
                    break;
                case EnumTables.Country:
                    dataTable = RepositoryFactory.CountryRepo.GetDataTableView();
                    break;
                case EnumTables.Employee:
                    dataTable = RepositoryFactory.EmployeeRepo.GetDataTableView();
                    dataTable.TableName = "EmployeeView";
                    break;
                case EnumTables.Post:
                    dataTable = RepositoryFactory.PostRepo.GetDataTableView();
                    break;
                case EnumTables.Resort:
                    dataTable = RepositoryFactory.ResortRepo.GetDataTableView();
                    break;
                case EnumTables.Tour:
                    dataTable = RepositoryFactory.TourRepo.GetDataTableView();
                    dataTable.TableName = "TourView";
                    break;
                case EnumTables.Hotel:
                    dataTable = RepositoryFactory.HotelRepo.GetDataTableView();
                    dataTable.TableName = "HotelView";
                    break;
                case EnumTables.City:
                    dataTable = RepositoryFactory.CityRepo.GetDataTableView();
                    dataTable.TableName = "CityView";
                    break;
            }
            dataGridView1.DataSource = dataTable;
            button1.Text = dataTable.TableName;
            UpdateFilterComboBoxDataSource(dataTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = Filter((System.Data.DataTable)dataGridView1.DataSource, FilterComboBox.Text, textBox1.Text);
            }
            catch (DataException ex)
            {
                DialogResult result = MessageBox.Show($"{ex.Message}", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private System.Data.DataTable Filter(System.Data.DataTable dataTable, string field, string value)
        {
            using (SqlConnection connection = new DBContext().GetDatabaseConnection())
            {
                string sqlExpression = $"SELECT * FROM [{dataTable.TableName}] Where [{field}] = @fieldValue";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                //SqlParameter tableNameParametr = new SqlParameter("@tableName", RepositoryFactory.CityRepo.GetDataTableView().TableName);
                //SqlParameter fieldNameParametr = new SqlParameter("@fieldName", FilterComboBox.SelectedValue.ToString());
                SqlParameter fieldlValueParametr = new SqlParameter("@fieldValue", value);
                //command.Parameters.Add(tableNameParametr);
                //command.Parameters.Add(fieldNameParametr);
                command.Parameters.Add(fieldlValueParametr);
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo);
                if (!reader.HasRows)
                {
                    throw new DataException($"Нет записей с значением {value} в поле {field}");
                }

                System.Data.DataTable resDataTable = new System.Data.DataTable();
                resDataTable.Load(reader);
                resDataTable.TableName = dataTable.TableName;
                return resDataTable;

            }
        }

        private void UpdateFilterComboBoxDataSource(System.Data.DataTable dataTable)
        {
            List<string> columnNames = new List<string>();
            foreach (DataColumn col in dataTable.Columns)
            {
                columnNames.Add(col.ColumnName);
            }
            FilterComboBox.DataSource = columnNames.Skip(1).ToList();
        }

        private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryForm queryForm = new QueryForm();
            queryForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void отчётыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание нового документа Word
            Application wordApp = new Application();
            Document doc = wordApp.Documents.Add();

            // Создание таблицы
            Table table = doc.Tables.Add(doc.Range(), 1, 5); // 1 - количество строк, 5 - количество столбцов
            table.Borders.Enable = 1; // Включение границ таблицы

            // Добавление заголовков столбцов
            table.Cell(1, 1).Range.Text = "Код";
            table.Cell(1, 2).Range.Text = "Имя";
            table.Cell(1, 3).Range.Text = "Фамилия";
            table.Cell(1, 4).Range.Text = "Отчество";
            table.Cell(1, 5).Range.Text = "Паспорт";

            // Заполнение данных из таблицы "Клиент"
            // Здесь нужно использовать ваш механизм доступа к данным, например, ADO.NET, для получения данных из таблицы "Клиент"
            // и заполнения таблицы в документе Word соответствующими значениями

            // Пример заполнения данных из таблицы "Клиент" в Word
            // Здесь данные заполняются случайными значениями в качестве примера
            Random random = new Random();
            for (int i = 2; i <= 6; i++) // i - номер строки, с которой начинается заполнение данных
            {
                table.Cell(i, 1).Range.Text = random.Next(100).ToString(); // Пример значения для столбца "Код"
                table.Cell(i, 2).Range.Text = "Имя " + i.ToString(); // Пример значения для столбца "Имя"
                table.Cell(i, 3).Range.Text = "Фамилия " + i.ToString(); // Пример значения для столбца "Фамилия"
                table.Cell(i, 4).Range.Text = "Отчество " + i.ToString(); // Пример значения для столбца "Отчество"
                table.Cell(i, 5).Range.Text = "Паспорт " + i.ToString(); // Пример значения для столбца "Паспорт"
            }

            // Сохранение документа и закрытие приложения Word
            doc.SaveAs2("Отчет_Клиенты.docx"); // Указываете путь и имя файла для сохранения отчета
            doc.Close();
            Marshal.ReleaseComObject(doc);
            wordApp.Quit();
            Marshal.ReleaseComObject(wordApp);
        }
    }
}



