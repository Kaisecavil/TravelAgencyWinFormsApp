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
    public partial class ResortForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public ResortForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void ResortForm_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                Resort resort = RepositoryFactory.ResortRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = resort.Name;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (idForUpdate != -1)
            {
                RepositoryFactory.ResortRepo.UpdateEntitybyId(idForUpdate, new Resort(-1, name));
            }
            else
            {
                RepositoryFactory.ResortRepo.Create(new Resort(-1, name));
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
