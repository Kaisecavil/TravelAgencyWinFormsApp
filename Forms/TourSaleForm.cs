using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;
using TravelAgencyRepository.Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class TourSaleForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public TourSaleForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Tour tour = (Tour)comboBox1.SelectedItem;
            Client client = (Client)comboBox2.SelectedItem;
            Employee employee = (Employee)comboBox3.SelectedItem;
            TransportKind transportKind = (TransportKind)comboBox4.SelectedItem;

            DateTime saleDate = dateTimePicker1.Value.Date;
            int toursQuantity = (int)numericUpDown1.Value;
            DateTime tourDate = dateTimePicker2.Value.Date;
            
            int clientId = client.Id;
            int employeeId = employee.Id ;
            int tourId = tour.Id;
            int transportKindId = transportKind.Id;
            try
            {
                if(textBox1.Text.Trim().Length > 0) 
                {
                    decimal tourPricePerPerson = Convert.ToDecimal(textBox1.Text);
                    if (idForUpdate != -1)
                    {
                        RepositoryFactory.TourSaleRepo.UpdateEntitybyId(idForUpdate, new TourSale(-1, saleDate, tourDate, toursQuantity, tourPricePerPerson, clientId, employeeId, tourId, transportKindId));
                    }
                    else
                    {
                        RepositoryFactory.TourSaleRepo.Create(new TourSale(-1, saleDate, tourDate, toursQuantity, tourPricePerPerson, clientId, employeeId, tourId, transportKindId));
                    }
                    mainForm.UpdateDataViewDataSource();
                    Close();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Пустая строка в поле ввода", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    return;
                }
                
            }
            catch(FormatException ex)
            {
                DialogResult result = MessageBox.Show($"Ошибка преобразования {textBox1.Text} к типу decimal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
        }

        private void TourSaleForm_Load(object sender, EventArgs e)
        {
            var tourlist = RepositoryFactory.TourRepo.GetEntities();
            var clientlist = RepositoryFactory.ClientRepo.GetEntities();
            var employeelist = RepositoryFactory.EmployeeRepo.GetEntities();
            var transportKindlist = RepositoryFactory.TransportKindRepo.GetEntities();
            comboBox1.DataSource = tourlist;
            comboBox2.DataSource = clientlist;
            comboBox3.DataSource = employeelist;
            comboBox4.DataSource = transportKindlist;

            if (idForUpdate != -1)
            {
                TourSale tourSale = RepositoryFactory.TourSaleRepo.GetEntitybyId(idForUpdate);
                dateTimePicker1.Value = tourSale.SaleDate;
                dateTimePicker2.Value = tourSale.TourDate;
                numericUpDown1.Value = tourSale.ToursQuantity;
                textBox1.Text = tourSale.TourPricePerPerson.ToString();
                comboBox1.SelectedIndex = tourlist.IndexOf(RepositoryFactory.TourRepo.GetEntitybyId(tourSale.TourId)); 
                comboBox2.SelectedIndex = clientlist.IndexOf(RepositoryFactory.ClientRepo.GetEntitybyId(tourSale.ClientId));
                comboBox3.SelectedIndex = employeelist.IndexOf(RepositoryFactory.EmployeeRepo.GetEntitybyId(tourSale.EmployeeId));
                comboBox4.SelectedIndex = transportKindlist.IndexOf(RepositoryFactory.TransportKindRepo.GetEntitybyId(tourSale.TransportKindId));
            }
            else
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
