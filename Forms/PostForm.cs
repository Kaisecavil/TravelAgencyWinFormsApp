using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgencyEFRepository.Factory;
using TravelAgencyRepository.Factory;
using TravelAgencyRepository.Models;

namespace TravelAgencyWinFormsApp.Forms
{
    public partial class PostForm : Form
    {
        private MainForm mainForm;
        private int idForUpdate;
        public PostForm(MainForm form, int idForUpdate = -1)
        {
            mainForm = form;
            this.idForUpdate = idForUpdate;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string post = textBox1.Text.Trim();
            if (post.Length < 1)
            {
                DialogResult result = MessageBox.Show("Пустая строка в поле ввода", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            try
            {
                if (textBox2.Text.Trim().Length > 0)
                {
                    decimal salary = Convert.ToDecimal(textBox2.Text.Trim());
                    if (idForUpdate != -1)
                    {
                        EFRepositoryFactory.PostRepo.UpdateEntitybyId(idForUpdate, new TravelAgencyEFRepository.Models.Post { Title = post, Salary = salary });
                    }
                    else
                    {
                        EFRepositoryFactory.PostRepo.Create(new TravelAgencyEFRepository.Models.Post { Title = post, Salary = salary });
                    }
                    mainForm.UpdateDataViewDataSource();
                    Close();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Пустая строка в поле ввода", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                    return;
                }

            }
            catch (FormatException ex)
            {
                DialogResult result = MessageBox.Show($"Ошибка преобразования {textBox2.Text} к типу decimal", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            if (idForUpdate != -1)
            {
                Post post = RepositoryFactory.PostRepo.GetEntitybyId(idForUpdate);
                textBox1.Text = post.Title;
                textBox2.Text = post.Salary.ToString();
            }
        }
    }
}
