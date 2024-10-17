using Exercise2.Models;
using Exercise2.Repository;
using MySql.Data.MySqlClient;
using System.Data;

namespace Exercise2
{
    public partial class frmCanBo : Form
    {
        int MaCB;

        QlcbContext _context;
        ICanBoRepository _canBoRepository;
        public frmCanBo(ICanBoRepository canBoRepository, QlcbContext context)
        {
            InitializeComponent();
            _canBoRepository = canBoRepository;
            _context = context;
            LoadChucVuCombobox();
        }

        public void LoadChucVuCombobox()
        {
            try
            {
                var chucVuList = _context.Chucvus.ToList();
                cboChucVu.DataSource = chucVuList;
                cboChucVu.DisplayMember = "TenCV";
                cboChucVu.ValueMember = "MaCV";
                cboChucVu.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        public void ResetFeilds(bool status)
        {
            txtMaSo.Clear();
            txtHoTen.Clear();
            cboChucVu.SelectedIndex = -1;
            txtSoGio.Clear();
            txtDonGia.Clear();
            btnSave.Enabled = status;
            btnAdd.Enabled = !status;
            txtHoTen.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MaCB = _canBoRepository.GetNextMaCB();
            ResetFeilds(true);
            txtMaSo.Text = MaCB.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newCanBo = new Canbo
                {
                    MaCb = MaCB,
                    TenCb = txtHoTen.Text,
                    ChucVuCb = (int?)cboChucVu.SelectedValue,
                    SoGioGiang = int.Parse(txtSoGio.Text),
                    DonGia = decimal.Parse(txtDonGia.Text),
                };

                _canBoRepository.AddCanBo(newCanBo);
                MessageBox.Show("Insert successfully");
                ResetFeilds(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
 