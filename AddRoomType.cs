using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using HotelV4.aclass;
using HotelV4.bclass;

namespace HotelV4
{
    public partial class AddRoomType : Form
    {
        private add_room _addRoomForm;
        public AddRoomType(add_room addRoomForm)
        {
            _addRoomForm = addRoomForm;
            InitializeComponent();
            txtPrice.Text = IntToString("100000");

        }

        private void InsertService()
        {
            if (!fCustomer.CheckFillInText(new Control[] { txtname, txtLimitperson, txtPrice }))
            {
                MessageBox.Show("Cannot be blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                RoomType roomTypeNow = GetRoomTypeNow();
                if (roomTypeNow == null)
                {
                    return; // Return early if roomTypeNow is null due to validation errors
                }

                bool isInserted = RoomTypeDAO.Instance.InsertRoomType(roomTypeNow);

                if (isInserted)
                {
                    MessageBox.Show("Success", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Text = string.Empty;
                    txtPrice.Text = IntToString("100000");
                    txtLimitperson.Text = string.Empty;

                    // Reload room types in the main form
                    _addRoomForm.LoadFullRoomType();
                }
                else
                {
                    if (RoomTypeDAO.Instance.CheckRoomTypeExists(roomTypeNow.Name))
                    {
                        MessageBox.Show("Service already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert service", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private RoomType GetRoomTypeNow()
        {
            RoomType roomtype = new RoomType();
            roomtype.Name = txtname.Text.Trim();

            // Parsing and handling limit person
            if (int.TryParse(txtLimitperson.Text.Trim(), out int limitPerson))
            {
                roomtype.LimitPerson = limitPerson;
            }
            else
            {
                // Show error message for invalid input
                MessageBox.Show("Invalid input. Please enter a valid integer value for limit person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // You might choose to return null or throw an exception here
                return null;
            }

            // Parsing and handling price
            try
            {
                roomtype.Price = int.Parse(StringToInt(txtPrice.Text.Trim()));
            }
            catch (FormatException ex)
            {
                // Show error message for price format error
                MessageBox.Show($"Price format error: {ex.Message}\nPrice text: {txtPrice.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // You might choose to return null or throw an exception here
                return null;
            }

            return roomtype;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to add a new service?", "Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                InsertService();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
