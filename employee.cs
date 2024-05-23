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

namespace HotelV4
{
    public partial class employee : Form
    {

        public employee()
        {
            InitializeComponent();
            FormMover.Moveform(this);
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
            btnSearch.Text = "Cancel";
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
            btnSearch.Text = "Search";
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
            addstaff frm = new addstaff();
            frm.Show();

        }
        
    }
}
