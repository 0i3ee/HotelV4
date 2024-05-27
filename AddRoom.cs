using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
            LoadFullRoomType();
        }
        private void LoadFullRoomType()
        {
            DataTable table = GetFullRoomType();
            ChangePrice(table);
            cbTyperoom.DataSource = table;
            cbTyperoom.DisplayMember = "Name";
            if (table.Rows.Count > 0)
                cbTyperoom.SelectedIndex = 0;
            txtPrice.DataBindings.Add("Text", cbTyperoom.DataSource, "price_New");
            txtMaxPeople.DataBindings.Add(new Binding("Text", cbTyperoom.DataSource, "limitPerson"));
        }
        private DataTable GetFullRoomType()
        {
            return RoomTypeDAO.Instance.LoadFullRoomType();
        }
        private Room GetRoomNow()
        {
            Room room = new Room();
            employee.Trim(new TextBox[] { txtName });
            room.Name = txtName.Text;
            int index = cbTyperoom.SelectedIndex;
            room.IdStatusRoom = 1;
            room.IdRoomType = (int)((DataTable)cbTyperoom.DataSource).Rows[index]["id"];
            return room;
        }
        private void InsertRoom()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txtName, cbTyperoom }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Room roomNow = GetRoomNow();
                if (RoomDAO.Instance.InsertRoom(roomNow))
                {
                    txtName.Text = string.Empty;
                    MessageBox.Show("Success", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("This room already exists (Duplicate room number)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("Error unable to add this room", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new room?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertRoom();
        }
        private void ChangePrice(DataTable table)
        {
            table.Columns.Add("price_New", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                table.Rows[i]["price_New"] = ((int)table.Rows[i]["price"]).ToString("C0", CultureInfo.CreateSpecificCulture("lo-LA"));
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
