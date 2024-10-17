using Lab4;
using MySql.Data.MySqlClient;
using System.Data;

namespace Exercise3
{
    public partial class frmThanhToan : Form
    {
        int CodeNo;
        public frmThanhToan()
        {
            InitializeComponent();
            LoadRoomCombobox();
        }

        public void LoadRoomCombobox()
        {
            try
            {
                ClassConnection.Open();
                string query = "Select * from Phong";
                MySqlCommand mySqlCommand = new MySqlCommand(query, ClassConnection.mySqlConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                cboRoom.DataSource = dataTable;
                cboRoom.DisplayMember = "MaPhong";
                cboRoom.ValueMember = "MaPhong";
                cboRoom.SelectedIndex = -1;
                ClassConnection.Close();
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
            try
            {
                ClassConnection.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("Select Max(SoHD) from KhachHang", ClassConnection.mySqlConnection);
                CodeNo = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                ClassConnection.Close();
            }
            catch (Exception)
            {
                CodeNo = 0;
            }
            CodeNo++;
            ResetFields(true);
            txtNo.Text = CodeNo.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strInsert = "insert into KhachHang values(@SoHD, @Hoten, @CMND, @Price, @Date, @Room)";
            ClassConnection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand(strInsert, ClassConnection.mySqlConnection);
            mySqlCommand.Parameters.AddWithValue("@SoHd", CodeNo);
            mySqlCommand.Parameters.AddWithValue("@Hoten", txtHoTen.Text);
            mySqlCommand.Parameters.AddWithValue("@CMND", txtCMND.Text);
            mySqlCommand.Parameters.AddWithValue("@Price", txtPrice.Text);
            mySqlCommand.Parameters.AddWithValue("@Room", cboRoom.SelectedValue);
            mySqlCommand.Parameters.AddWithValue("@Date", timePicker.Value.ToString("yyyy/MM/dd HH:mm:ss"));
            MessageBox.Show("Insert successfully");
            mySqlCommand.ExecuteNonQuery();
            ClassConnection.Close();
            ResetFields(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
