using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelV4.aclass;
using HotelV4.bclass;
using System.Globalization;

namespace HotelV4
{
    
    public partial class frmRoomType : Form
    {
        private DataTable _tableRoomType;
        public DataTable TableRoomType
        {
            get => _tableRoomType;
            private set
            {
                _tableRoomType = value;
                BindingSource source = new BindingSource();
                ChangePrice(_tableRoomType);
                source.DataSource = _tableRoomType;
                DGV.DataSource = source;
                bindingRoomType.BindingSource = source;
                cbid.DataSource = source;
            }
        }
        public frmRoomType()
        {
            InitializeComponent();
            
        }
        public frmRoomType(DataTable table)
        {
            InitializeComponent();
            TableRoomType = table;
            cbid.DisplayMember = "id";
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void LoadFullRoomType(DataTable table)
        {
            this.TableRoomType = table;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); Close();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            cbid.Text = "Automatic";
            txtName.Text = string.Empty;
            txtPrice.Text = "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update this room type?", "Notifications", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoomType();
            cbid.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();
            if (txtSearch.Text != string.Empty)
            {
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullRoomType(GetFullRoomType());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private RoomType GetRoomTypeNow()
        {
            RoomType roomType = new RoomType();
            if (cbid.Text == string.Empty)
                roomType.Id = 0;
            else
                roomType.Id = int.Parse(cbid.Text);

            roomType.Name = txtName.Text;
            roomType.Price = int.Parse(StringToInt(txtPrice.Text));
            roomType.LimitPerson = int.Parse(txtMaxPeople.Text);
            return roomType;
        }
        private DataTable GetSearchRoomType()
        {
            if (int.TryParse(txtSearch.Text, out int id))
                return RoomTypeDAO.Instance.Search(txtSearch.Text, id);
            else
                return RoomTypeDAO.Instance.Search(txtSearch.Text, 0);
        }
        private void UpdateRoomType()
        {
            if (cbid.Text == string.Empty)
            {
                MessageBox.Show("This room type does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            if (!fCustomer.CheckFillInText(new Control[] { txtName, txtPrice }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RoomType roomTypePre = groupRoomType.Tag as RoomType;
                try
                {
                    RoomType roomTypeNow = GetRoomTypeNow();
                    if (roomTypeNow.Equals(roomTypePre))
                        MessageBox.Show("You have not changed the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        bool check = RoomTypeDAO.Instance.UpdateRoomType(roomTypeNow, roomTypePre);
                        if (check)
                        {
                            MessageBox.Show("Update Successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoomType.Tag = roomTypeNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = DGV.SelectedRows[0].Index;
                                LoadFullRoomType(GetFullRoomType());
                                cbid.SelectedIndex = index;
                            }
                            else
                                btnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show("This room type does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {

                    MessageBox.Show("Data Entry Error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtName.Text = string.Empty;
                txtPrice.Text = "0";
                txtMaxPeople.Text = "0";
            }
            else
            {
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtPrice.Text = (string)row.Cells["colPrice"].Value;
                txtMaxPeople.Text = row.Cells["colLimitPerson"].Value.ToString();
                RoomType roomType = new RoomType(((DataRowView)row.DataBoundItem).Row);
                groupRoomType.Tag = roomType;
            }
        }
        private void Search()
        {
            LoadFullRoomType(GetSearchRoomType());
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV.SelectedRows.Count > 0)
            {
                DataGridViewRow row = DGV.SelectedRows[0];
                ChangeText(row);
            }
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
        }

        private string StringToInt(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "0";

            try
            {
                string[] vs = text.Split(new char[] { '.', ',', ' ', '₭' }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder textNow = new StringBuilder();
                foreach (var part in vs)
                {
                    textNow.Append(part);
                }
                return textNow.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in StringToInt: {ex.Message}\nInput text: {text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private string IntToString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));

            try
            {
                int parsedInt = int.Parse(StringToInt(text)); // Use StringToInt to ensure proper format
                return parsedInt.ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Price format error in IntToString: {ex.Message}\nInput text: {text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
               if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void frmRoomType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == string.Empty)
                txtName.Text = txtName.Tag as String;
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (txtPrice.Text == string.Empty)
            {
                txtPrice.Text = (string)txtPrice.Tag;
            }
            else
                txtPrice.Text = IntToString(txtPrice.Text);
        }

        private void txtMaxPeople_Leave(object sender, EventArgs e)
        {
            if (txtMaxPeople.Text == string.Empty)
                txtMaxPeople.Text = txtMaxPeople.Tag as String;
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.Tag = txtPrice.Text;
            txtPrice.Text = StringToInt(txtPrice.Text);
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            txtName.Tag = txtName.Text;
        }

        private void txtMaxPeople_Enter(object sender, EventArgs e)
        {
            txtMaxPeople.Tag = txtMaxPeople.Text;
        }

        private void frmRoomType_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click(sender, null);
        }
    }
}
