using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class employee : Form
    {
        private string username;
        public employee(string username)
        {
            InitializeComponent();
            FormMover.Moveform(this);
        }
        //cdb cdb = new cdb();

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

        }
       


        private void employee_Load(object sender, EventArgs e)
        {


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {


        }

        private void lbExit_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            
            menu frm = new menu(username); ;
            frm.Show();
            this.Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addstaff frm = new addstaff(username);
            frm.Show();

        }
        public static bool CheckFillInText(Control[] controls)
        {
            foreach (var control in controls)
            {
                if (control.Text == string.Empty)
                    return false;
            }
            return true;
        }
        private Accout GetStaffNow()
        {
            Accout account = new Accout();

            account.UserName = txtusername.Text.ToLower();
            int index = cbemptype.SelectedIndex;
            account.IdStaffType = (int)((DataTable)cbemptype.DataSource).Rows[index]["id"];
            account.DisplayName = txtname.Text;
            account.IdCard = txtidnumber.Text;
            account.Sex = cbbsex.Text;
            account.DateOfBirth = dob.Value;
            account.PhoneNumber = int.Parse(txtphonenumber.Text);
            account.Address = txtaddress.Text;
            account.StartDay = dos.Value;
            return account;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            bool isFill = employee.CheckFillInText(new Control[] { txtusername, cbemptype, txtname ,
                                                            txtidnumber , cbbsex , txtphonenumber, txtaddress});
            if (!isFill)
            {
                MessageBox.Show("No data", "Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Accout accountPre = groupstaff.Tag as Accout;
                try
                {
                    Accout accountnow = GetStaffNow();
                    if (accountnow.Equals(accountPre))
                    {
                        MessageBox.Show("Bạn chưa thay đổi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = AccountB.Instance.UpdateAccount(accountnow);
                        if (check)
                        {
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupstaff.Tag = accountnow;
                            if (btnCancel.Visible == false)
                            {
                                int index = DGV.SelectedRows[0].Index;
                                LoadFullStaff(GetFullStaff());
                                DGV.SelectedRows[0].Selected = false;
                                DGV.Rows[index].Selected = true;
                            }
                            else
                                btnCancel_Click(null, null);
                        }
                        else
                        {
                            if (accountnow.UserName == accountPre.UserName)
                                MessageBox.Show("Không thể cập nhật(Trùng số chứng minh nhân dân)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                                MessageBox.Show("Không thể cập nhật(Tài khoản chưa tồn tại)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi không xác định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private DataTable GetFullStaff()
        {
            return AccountB.Instance.LoadFullStaff();
        }
        private DataTable GetFullStaffType()
        {
            return AccountTypeb.Instance.LoadFullStaffType();
        }
        private void LoadFullStaffType()
        {
            cbbsex.SelectedIndex = 0;
            DataTable table = GetFullStaffType();
            cbemptype.DataSource = table;
            cbemptype.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbemptype.SelectedIndex = 0;
        }
        private void LoadFullStaff(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            DGV.DataSource = source;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
