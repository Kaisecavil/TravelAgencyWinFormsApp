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
    public partial class HotelForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public HotelForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            City city = (City)comboBox1.SelectedItem;
            string name = textBox1.Text;
            int cityId = city.Id;
            int starQuantity = (int)numericUpDown1.Value;
            try
            {
                if (textBox2.Text.Trim().Length > 0)
                {
                    decimal pricePerDay = Convert.ToDecimal(textBox2.Text);
                    if (idForUpdate != -1)
                    {
                        RepositoryFactory.HotelRepo.UpdateEntitybyId(idForUpdate, new Hotel(-1,name, pricePerDay, starQuantity, cityId));
                    }
                    else
                    {
                        RepositoryFactory.HotelRepo.Create(new Hotel(-1, name, pricePerDay, starQuantity, cityId));
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
            catch (FormatException ex)
            {
                DialogResult result = MessageBox.Show($"Ошибка преобразования {textBox1.Text} к типу decimal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HotelForm_Load(object sender, EventArgs e)
        {
            var citylList = RepositoryFactory.CityRepo.GetEntities();
            comboBox1.DataSource = citylList;

            if (idForUpdate != -1)
            {
                Hotel hotel = RepositoryFactory.HotelRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = hotel.Name;
                numericUpDown1.Value = hotel.StarQuantity;
                textBox2.Text = hotel.PricePerDay.ToString();
                comboBox1.SelectedIndex = citylList.IndexOf(RepositoryFactory.CityRepo.GetEntitybyId(hotel.CityId));
            }
            else
            {
                comboBox1.SelectedIndex = -1;
            }
        }
    }
}
