using System;
using System.Windows.Forms;
using Exercise1.Models;
using Exercise1.Repository;

namespace Lab4
{
    public partial class frmDVDCatalog : Form
    {
        int CodeNo;

        IDVDRepository _dvdRepository;

        public frmDVDCatalog(IDVDRepository dvdRepository)
        {
            InitializeComponent();
            _dvdRepository = dvdRepository;
        }

        public void ResetFields(bool status)
        {
            txtNo.Clear();
            txtTitle.Clear();
            cboLang.SelectedIndex = -1;
            updPrice.Value = updPrice.Minimum;
            radYes.Checked = true;
            radNo.Checked = false;
            btnSave.Enabled = status;
            btnCancel.Enabled = status;
            btnAdd.Enabled = !status;
            txtTitle.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CodeNo = _dvdRepository.GetNextDVDCodeNo();
            ResetFields(true);
            txtNo.Text = CodeNo.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newDvd = new Dvd
                {
                    DvdcodeNo = CodeNo,
                    Dvdtitle = txtTitle.Text,
                    Language = cboLang.Text,
                    SubTitle = radYes.Checked,
                    Price = updPrice.Value,
                };
                _dvdRepository.AddDVD(newDvd);
                MessageBox.Show("Insert successfully!!!");
                ResetFields(false);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields(false);
        }
    }
}
