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
    public partial class add_room : Form
    {
        private frmRoomType _fRoomtType;
        public add_room()
        {
            InitializeComponent();
            FormMover.Moveform(this);
            LoadFullRoomType();
            LoadFullStatusRoom();
            LoadFullRoom(GetFullRoom());
            DGV.SelectionChanged +=DGV_SelectionChanged;
            cbRoomId.DisplayMember = "id";
            DGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddRoom().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullRoom(GetFullRoom());
            else btnCancel_Click(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadFullRoom(GetFullRoom());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnEditRoomType_Click(object sender, EventArgs e)
        {
            this.Hide();
            _fRoomtType.ShowDialog();
            LoadFullRoom(GetFullRoom());
            cbRoomType.DataSource = _fRoomtType.TableRoomType;
            txtRoomRate.DataBindings.Clear();
            txtMaxPeople.DataBindings.Clear();
            txtRoomRate.DataBindings.Add(new Binding("Text", cbRoomType.DataSource, "price_new"));
            txtMaxPeople.DataBindings.Add(new Binding("Text", cbRoomType.DataSource, "limitPerson"));
            this.Show();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            txtRoomName.Text = string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to update the room?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateRoom();
            cbRoomId.Focus();
        }
        private void LoadFullRoom(DataTable table)
        {
            BindingSource source = new BindingSource();
            ChangePrice(table);
            source.DataSource = table;
            DGV.DataSource = source;
            bindingRoom.BindingSource = source;
            cbRoomId.DataSource = source;
        }
        private void LoadFullStatusRoom()
        {
            DataTable table = GetFullStatusRoom();
            cbStatus.DataSource = table;
            cbStatus.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbStatus.SelectedIndex = 0;
        }
        private void LoadFullRoomType()
        {
            DataTable table = GetFullRoomType();
            cbRoomType.DataSource = table;
            cbRoomType.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbRoomType.SelectedIndex = 0;
            _fRoomtType = new frmRoomType(table);
            txtMaxPeople.DataBindings.Add(new Binding("Text", cbRoomType.DataSource, "limitPerson"));
        }
        private void UpdateRoom()
        {
            if (cbRoomId.Text == string.Empty)
            {
                MessageBox.Show("This room does not exist\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            if (!fCustomer.CheckFillInText(new Control[] { txtRoomName, cbStatus, cbRoomType }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Room roomPre = groupRoom.Tag as Room;
                try
                {
                    Room roomNow = GetRoomNow();
                    if (roomNow.Equals(roomPre))
                    {
                        MessageBox.Show("You have not changed the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        bool check = RoomDAO.Instance.UpdateCustomer(roomNow);
                        if (check)
                        {
                            MessageBox.Show("Update Successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            groupRoom.Tag = roomNow;
                            if (btnCancel.Visible == false)
                            {
                                int index = DGV.SelectedRows[0].Index;
                                LoadFullRoom(GetFullRoom());
                                cbRoomId.SelectedIndex = index;
                            }
                            else btnCancel_Click(null, null);
                        }
                        else
                            MessageBox.Show("This room does not exist\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                catch
                {
                    MessageBox.Show("Error updating this room", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                txtRoomName.Text = string.Empty;
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
            }
            else
            {
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
                txtRoomName.Text = row.Cells["colName"].Value.ToString();
                cbRoomType.SelectedIndex = (int)row.Cells["colIdRoomType"].Value - 1;
                cbStatus.SelectedIndex = (int)row.Cells["colIdStatus"].Value - 1;
                Room room = new Room(((DataRowView)row.DataBoundItem).Row);
                groupRoom.Tag = room;
            }
        }
        private void Search()
        {
            LoadFullRoom(GetSearchRoom());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.Trim();
            if (txtSearch.Text != string.Empty)
            {
                txtRoomName.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                Search();
            }
        }
        private DataTable GetFullRoom()
        {
            return RoomDAO.Instance.LoadFullRoom();
        }
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private DataTable GetFullStatusRoom()
        {
            return StatusRoomDAO.Instance.LoadFullStatusRoom();
        }
        private Room GetRoomNow()
        {
            Room room = new Room();
            if (cbRoomId.Text == string.Empty)
                room.Id = 0;
            else
                room.Id = int.Parse(cbRoomId.Text);
            employee.Trim(new TextBox[] { txtRoomName });
            room.Name = txtRoomName.Text;
            int index = cbRoomType.SelectedIndex;
            room.IdRoomType = (int)((DataTable)cbRoomType.DataSource).Rows[index]["id"];
            index = cbStatus.SelectedIndex;
            room.IdStatusRoom = (int)((DataTable)cbStatus.DataSource).Rows[index]["id"];
            return room;
        }
        private DataTable GetSearchRoom()
        {
            if (int.TryParse(txtSearch.Text, out int id))
                return RoomDAO.Instance.Search(txtSearch.Text, id);
            else
                return RoomDAO.Instance.Search(txtSearch.Text, 0);
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
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
            table.Columns.Remove("price");
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbRoomType.SelectedIndex;

            if (((DataTable)cbRoomType.DataSource).Rows[index]["Price"].ToString().Contains("."))
                return;
            txtRoomRate.Text = ((int)((DataTable)cbRoomType.DataSource).Rows[index]["Price"]).ToString("C0", CultureInfo.CreateSpecificCulture("vi-VN"));
        }

        private void txtRoomName_Enter(object sender, EventArgs e)
        {
            txtRoomName.Tag = txtRoomName.Text;
        }

        private void txtRoomName_Leave(object sender, EventArgs e)
        {
            if (txtRoomName.Text == string.Empty)
                txtRoomName.Text = txtRoomName.Tag as string;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void add_room_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27 && btnCancel.Visible == true)
                btnCancel_Click(sender, null);
        }

        private void add_room_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnCancel_Click(sender, null);
        }
    }
}
