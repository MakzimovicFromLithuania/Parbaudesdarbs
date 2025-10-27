using System;
using System.Windows.Forms;

namespace NM_KontaktGramata
{
    public partial class ContactForm : Form
    {
        public Contact Value { get; private set; }

        public ContactForm(Contact existing = null)
        {
            InitializeComponent();
            Value = existing != null
                ? new Contact { Id = existing.Id, Name = existing.Name, Phone = existing.Phone, Email = existing.Email }
                : new Contact();

            txtName.Text = Value.Name;
            txtPhone.Text = Value.Phone;
            txtEmail.Text = Value.Email;

            btnOk.Click += (_, __) => Save();
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
        }

        private void Save()
        {
            Value.Name = txtName.Text.Trim();
            Value.Phone = txtPhone.Text.Trim();
            Value.Email = txtEmail.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
