using Exercise3.Models;
using Exercise3.Repository;
using MySql.Data.MySqlClient;
using System.Data;

namespace Exercise3
{
    public partial class frmThanhToan : Form
    {
        int SoHD;
        ThanhToanContext _context;
        ITTRepository _ttRepository;
        public frmThanhToan(ITTRepository ttRepository, ThanhToanContext context)
        {
            InitializeComponent();
            _ttRepository = ttRepository;
            _context = context;
            LoadRoomComboBox();
        }
        public void LoadRoomComboBox()
        {
            try
            {
                var RoomList = _context.Phongs.ToList();
                cboRoom.DataSource = RoomList;
                cboRoom.DisplayMember = "MaPhong";
                cboRoom.ValueMember = "MaPhong";
                cboRoom.SelectedIndex = -1;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
        public void ResetFields(bool status)
        {
            txtNo.Clear();
            txtHoTen.Clear();
            txtCMND.Clear();
            txtPrice.Clear();
            cboRoom.SelectedIndex = -1;
            btnSave.Enabled = status;
            btnAdd.Enabled = !status;
            txtHoTen.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SoHD = _ttRepository.GetNextSoHD();
            ResetFields(true);
            txtNo.Text = SoHD.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var newKH = new Khachhang
                {
                    SoHd = SoHD,
                    TenKh = txtHoTen.Text,
                    SoCmnd = txtCMND.Text,
                    SoTien = decimal.Parse(txtPrice.Text),
                    NgayTt = timePicker.Value
                };
                _ttRepository.AddKH(newKH);
                MessageBox.Show("Insert successfully");
                ResetFields(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
