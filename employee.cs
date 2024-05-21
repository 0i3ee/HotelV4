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

namespace HotelV4
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        ClassconnectDB cdb = new ClassconnectDB();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter search text.");
                return;
            }

            cdb.cmd = new SqlCommand("SELECT dbo.Staff.UserName, dbo.Staff.DisplayName, dbo.StaffType.Name AS StaffTypeName, dbo.Staff.IDCard, dbo.Staff.PhoneNumber, dbo.Staff.Address FROM dbo.Staff INNER JOIN dbo.StaffType ON dbo.Staff.IDStaffType = dbo.StaffType.ID WHERE UserName LIKE @searchText OR IDCard LIKE @searchText OR PhoneNumber LIKE @searchText", cdb.conn);
            cdb.cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

            try
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(cdb.cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the result to your UI, e.g., a DataGridView
                DGV.DataSource = dataTable;

                // Set header text for columns
                DGV.Columns["UserName"].HeaderText = "UserName";
                DGV.Columns["DisplayName"].HeaderText = "Name";
                DGV.Columns["StaffTypeName"].HeaderText = "STypeName";
                DGV.Columns["IDCard"].HeaderText = "IDCard";
                DGV.Columns["PhoneNumber"].HeaderText = "PhoneNumber";
                DGV.Columns["Address"].HeaderText = "Address";

                DGV.Columns["StaffTypeName"].Width = 110;
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("ບໍ່ພົບຂໍ້ມູນ","ຜົນການກວດສອບ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


        }
        private void ShowStaffType()
        {
            SqlDataAdapter daS = new SqlDataAdapter("Select * from StaffType", cdb.conn);
            DataSet dsS = new DataSet();
            daS.Fill(dsS, "StaffType");
            cbbemptype.DataSource = dsS.Tables[0];
            cbbemptype.DisplayMember = "Name";
            cbbemptype.ValueMember = "ID";
        }
        void showdata()
        {
            try
            {
                cdb.da = new SqlDataAdapter("SELECT dbo.Staff.UserName, dbo.Staff.DisplayName, dbo.StaffType.Name AS StaffTypeName, dbo.Staff.IDCard, dbo.Staff.PhoneNumber, dbo.Staff.Address FROM dbo.Staff INNER JOIN dbo.StaffType ON dbo.Staff.IDStaffType = dbo.StaffType.ID", cdb.conn);

                cdb.da.Fill(cdb.ds, "employee");
                cdb.ds.Tables[0].Clear();
                cdb.da.Fill(cdb.ds, "employee");
                DGV.DataSource = cdb.ds.Tables[0];
                DGV.Refresh();



                // Set header text for columns
                DGV.Columns["UserName"].HeaderText = "UserName";
                DGV.Columns["DisplayName"].HeaderText = "Name";
                DGV.Columns["StaffTypeName"].HeaderText = "SaffType";
                DGV.Columns["IDCard"].HeaderText = "IDCard";
                DGV.Columns["PhoneNumber"].HeaderText = "PhoneNumber";
                DGV.Columns["Address"].HeaderText = "Address";

                DGV.Columns["StaffTypeName"].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void employee_Load(object sender, EventArgs e)
        {
            cdb.connectDatabase();
            showdata();
            ShowStaffType();
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = "dd-MM-yyyy";
            startdate.Format = DateTimePickerFormat.Custom;
            startdate.CustomFormat = "dd-MM-yyyy";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            showdata();
        }

        private void lbExit_ClientSizeChanged(object sender, EventArgs e)
        {

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            menu frm = new menu();
            frm.Show();
            this.Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime dobs = dob.Value;
            DateTime sDate = startdate.Value;
            string formattedDate = dobs.ToString("yyyy-MM-dd");
            string formattedsDate = sDate.ToString("yyyy-MM-dd");
            try
            {
                
                if (txtusername.Text == "")
                {
                    MessageBox.Show("Please enter Username ");
                    txtusername.Focus();
                }
                else if (txtname.Text == "")
                {
                    MessageBox.Show("Please enter Name");
                    txtname.Focus();
                }

                else if (txtidnumber.Text == "")
                {
                    MessageBox.Show("Please enter ID Number");
                    txtidnumber.Focus();
                }
                else if (txtphonenumber.Text == "")
                {
                    MessageBox.Show("Please enter Phone Number");
                    txtphonenumber.Focus();
                }
                else if (txtaddress.Text == "")
                {
                    MessageBox.Show("Please enter address");
                    txtaddress.Focus();
                }
                else
                {
                    if (MessageBox.Show("ເຈົ້າຕ້ອງການບັນທຶກຂໍ້ມູນຫຼືບໍ່", "ຄຳຢືນຢັນ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        

                        cdb.cmd = new SqlCommand("insert into Staff values(@UserName,@DisplayName,@PassWord,@IDStaffType,@IDCard,@DateOfBirth,@Sex,@Address,@PhoneNumber,@StartDay)", cdb.conn);
                        cdb.cmd.Parameters.AddWithValue("@UserName", txtusername.Text);
                        cdb.cmd.Parameters.AddWithValue("@DisplayName", txtname.Text);
                        cdb.cmd.Parameters.AddWithValue("@PassWord", "123456");
                        cdb.cmd.Parameters.AddWithValue("@IDStaffType", cbbemptype.SelectedValue);
                        cdb.cmd.Parameters.AddWithValue("@IDCard", txtidnumber.Text);
                        cdb.cmd.Parameters.AddWithValue("@DateOfBirth",formattedDate);
                        cdb.cmd.Parameters.AddWithValue("@Sex", cbbsex.Text);
                        cdb.cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cdb.cmd.Parameters.AddWithValue("@PhoneNumber", txtphonenumber.Text);
                        cdb.cmd.Parameters.AddWithValue("@StartDay", formattedsDate);
                        cdb.cmd.ExecuteNonQuery();
                        showdata();


                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("errorr"+ex);
            }
        }
    }
}
