using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class CountryForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public CountryForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void CountryForm_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                Country country = RepositoryFactory.CountryRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = country.Name;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (idForUpdate != -1)
            {
                RepositoryFactory.CountryRepo.UpdateEntitybyId(idForUpdate, new Country(-1, name));
            }
            else
            {
                RepositoryFactory.CountryRepo.Create(new Country(-1, name));
            }
            mainForm.UpdateDataViewDataSource();
            Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
