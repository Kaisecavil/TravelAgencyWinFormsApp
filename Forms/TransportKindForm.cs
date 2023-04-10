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
    public partial class TransportKindForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public TransportKindForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string kind = textBox1.Text.Trim();
            if (idForUpdate != -1)
            {
                RepositoryFactory.TransportKindRepo.UpdateEntitybyId(idForUpdate, new TransportKind(-1, kind));
            }
            else
            {
                RepositoryFactory.TransportKindRepo.Create(new TransportKind(-1, kind));
            }
            mainForm.UpdateDataViewDataSource();
            Close();
        }

        private void TransportKindForm_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                TransportKind tourKind = RepositoryFactory.TransportKindRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = tourKind.Kind;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
