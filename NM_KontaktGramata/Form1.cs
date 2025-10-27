using System;
using System.Windows.Forms;

namespace NM_KontaktGramata
{
    public partial class Form1 : Form
    {
        private readonly ContactRepository _repo;

        public Form1()
        {
            InitializeComponent();
            _repo = new ContactRepository("contacts.json");
            LoadGrid();

            btnAdd.Click += (_, __) => AddContact();
            btnEdit.Click += (_, __) => EditSelected();
            btnDelete.Click += (_, __) => DeleteSelected();
            txtSearch.TextChanged += (_, __) => LoadGrid();
        }

        private void LoadGrid()
        {
            dataGridView1.DataSource = _repo.Search(txtSearch.Text);
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void AddContact()
        {
            var form = new ContactForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _repo.Add(form.Value);
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditSelected()
        {
            if (dataGridView1.CurrentRow == null) return;
            var contact = (Contact)dataGridView1.CurrentRow.DataBoundItem;

            var form = new ContactForm(contact);
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _repo.Update(form.Value);
                    LoadGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteSelected()
        {
            if (dataGridView1.CurrentRow == null) return;
            var contact = (Contact)dataGridView1.CurrentRow.DataBoundItem;
            if (MessageBox.Show("Dzēst kontaktu?", "Apstiprinājums", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _repo.Delete(contact.Id);
                LoadGrid();
            }
        }
    }
}
