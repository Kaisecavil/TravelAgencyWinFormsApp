using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class CityForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public CityForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Resort resort = (Resort)comboBox1.SelectedItem;
            Country country = (Country)comboBox2.SelectedItem;

            int resortId = resort.Id;
            int countryId = country.Id;
            string name = textBox1.Text;
            if (textBox1.Text.Trim().Length > 0)
            {
                if (idForUpdate != -1)
                {
                    RepositoryFactory.CityRepo.UpdateEntitybyId(idForUpdate, new City(-1, name, countryId, resortId));
                }
                else
                {
                    RepositoryFactory.CityRepo.Create(new City(-1, name, countryId, resortId));
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CityForm_Load(object sender, EventArgs e)
        {
            var resortList = RepositoryFactory.ResortRepo.GetEntities();
            var countryList = RepositoryFactory.CountryRepo.GetEntities();
            comboBox1.DataSource = resortList;
            comboBox2.DataSource = countryList;

            if (idForUpdate != -1)
            {
                City city = RepositoryFactory.CityRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = city.Name;
                comboBox1.SelectedIndex = resortList.IndexOf(RepositoryFactory.ResortRepo.GetEntitybyId(city.ResortId));
                comboBox2.SelectedIndex = countryList.IndexOf(RepositoryFactory.CountryRepo.GetEntitybyId(city.CountryId));

            }
            else
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
            }

        }
    }
}
