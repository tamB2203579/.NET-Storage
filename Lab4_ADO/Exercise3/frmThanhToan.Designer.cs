namespace Exercise3
{
    partial class frmThanhToan
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnSave = new Button();
            btnExit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtNo = new TextBox();
            txtHoTen = new TextBox();
            txtCMND = new TextBox();
            txtPrice = new TextBox();
            cboRoom = new ComboBox();
            timePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(245, 348);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 54);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(449, 348);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 54);
            btnSave.TabIndex = 1;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(654, 348);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(129, 54);
            btnExit.TabIndex = 2;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 64);
            label1.Name = "label1";
            label1.Size = new Size(64, 25);
            label1.TabIndex = 3;
            label1.Text = "Số HĐ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(88, 125);
            label2.Name = "label2";
            label2.Size = new Size(66, 25);
            label2.TabIndex = 4;
            label2.Text = "Họ tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 199);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 5;
            label3.Text = "Số CMND";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(88, 262);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 6;
            label4.Text = "Số tiền TT";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(553, 199);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 7;
            label5.Text = "Số phòng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(553, 262);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 8;
            label6.Text = "Ngày TT";
            // 
            // txtNo
            // 
            txtNo.BorderStyle = BorderStyle.FixedSingle;
            txtNo.Enabled = false;
            txtNo.Location = new Point(206, 64);
            txtNo.Name = "txtNo";
            txtNo.Size = new Size(261, 31);
            txtNo.TabIndex = 9;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Location = new Point(206, 125);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(767, 31);
            txtHoTen.TabIndex = 10;
            // 
            // txtCMND
            // 
            txtCMND.BorderStyle = BorderStyle.FixedSingle;
            txtCMND.Location = new Point(206, 196);
            txtCMND.Name = "txtCMND";
            txtCMND.Size = new Size(261, 31);
            txtCMND.TabIndex = 11;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Location = new Point(206, 259);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(261, 31);
            txtPrice.TabIndex = 12;
            // 
            // cboRoom
            // 
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new Point(666, 199);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new Size(307, 33);
            cboRoom.TabIndex = 15;
            // 
            // timePicker
            // 
            timePicker.CustomFormat = "";
            timePicker.Location = new Point(666, 262);
            timePicker.Name = "timePicker";
            timePicker.Size = new Size(307, 31);
            timePicker.TabIndex = 16;
            timePicker.Value = new DateTime(2024, 9, 19, 19, 50, 20, 0);
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 436);
            Controls.Add(timePicker);
            Controls.Add(cboRoom);
            Controls.Add(txtPrice);
            Controls.Add(txtCMND);
            Controls.Add(txtHoTen);
            Controls.Add(txtNo);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnSave);
            Controls.Add(btnAdd);
            Name = "frmThanhToan";
            Text = "Thanh Toán";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnSave;
        private Button btnExit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtNo;
        private TextBox txtHoTen;
        private TextBox txtCMND;
        private TextBox txtPrice;
        private ComboBox cboRoom;
        private DateTimePicker timePicker;
    }
}
