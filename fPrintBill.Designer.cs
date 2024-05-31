
namespace HotelV4
{
    partial class fPrintBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.listViewUseService = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblIDBill = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lblDateCheckIn = new System.Windows.Forms.Label();
            this.lblRoomPrice_ = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.lblDateCreate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblRoomPrice = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblStaffSetUp = new System.Windows.Forms.Label();
            this.lblRoomTypeName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblCustomerTypeName = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblServicePrice = new System.Windows.Forms.Label();
            this.lblSurcharge = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblPeoples = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblIDCard = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // listViewUseService
            // 
            this.listViewUseService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listViewUseService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewUseService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewUseService.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUseService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listViewUseService.FullRowSelect = true;
            this.listViewUseService.GridLines = true;
            this.listViewUseService.HideSelection = false;
            this.listViewUseService.Location = new System.Drawing.Point(26, 323);
            this.listViewUseService.Name = "listViewUseService";
            this.listViewUseService.Size = new System.Drawing.Size(554, 298);
            this.listViewUseService.TabIndex = 149;
            this.listViewUseService.UseCompatibleStateImageBehavior = false;
            this.listViewUseService.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "service name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "price";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Qty";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total";
            this.columnHeader5.Width = 120;
            // 
            // lblIDBill
            // 
            this.lblIDBill.AutoSize = true;
            this.lblIDBill.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDBill.Location = new System.Drawing.Point(280, 19);
            this.lblIDBill.Name = "lblIDBill";
            this.lblIDBill.Size = new System.Drawing.Size(37, 21);
            this.lblIDBill.TabIndex = 146;
            this.lblIDBill.Text = "No:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(235, 66);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(84, 22);
            this.label29.TabIndex = 144;
            this.label29.Text = "Founder:";
            // 
            // lblDateCheckIn
            // 
            this.lblDateCheckIn.AutoSize = true;
            this.lblDateCheckIn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCheckIn.Location = new System.Drawing.Point(498, 234);
            this.lblDateCheckIn.Name = "lblDateCheckIn";
            this.lblDateCheckIn.Size = new System.Drawing.Size(62, 21);
            this.lblDateCheckIn.TabIndex = 138;
            this.lblDateCheckIn.Text = "label23";
            // 
            // lblRoomPrice_
            // 
            this.lblRoomPrice_.AutoSize = true;
            this.lblRoomPrice_.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomPrice_.Location = new System.Drawing.Point(498, 213);
            this.lblRoomPrice_.Name = "lblRoomPrice_";
            this.lblRoomPrice_.Size = new System.Drawing.Size(62, 21);
            this.lblRoomPrice_.TabIndex = 137;
            this.lblRoomPrice_.Text = "label24";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(344, 211);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 22);
            this.label18.TabIndex = 131;
            this.label18.Text = "Price:";
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(183, 737);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(203, 44);
            this.btnPrint.TabIndex = 115;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(26, 647);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 22);
            this.label21.TabIndex = 150;
            this.label21.Text = "Room Price:";
            // 
            // lblDateCreate
            // 
            this.lblDateCreate.AutoSize = true;
            this.lblDateCreate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCreate.Location = new System.Drawing.Point(358, 117);
            this.lblDateCreate.Name = "lblDateCreate";
            this.lblDateCreate.Size = new System.Drawing.Size(44, 21);
            this.lblDateCreate.TabIndex = 148;
            this.lblDateCreate.Text = "Date";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(392, 737);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(203, 44);
            this.btnClose.TabIndex = 114;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(474, 671);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(77, 21);
            this.lblDiscount.TabIndex = 160;
            this.lblDiscount.Text = "Founder:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(344, 692);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(105, 22);
            this.label25.TabIndex = 158;
            this.label25.Text = "Total Price:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(344, 670);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 22);
            this.label26.TabIndex = 157;
            this.label26.Text = "Discount:";
            // 
            // lblRoomPrice
            // 
            this.lblRoomPrice.AutoSize = true;
            this.lblRoomPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomPrice.Location = new System.Drawing.Point(150, 648);
            this.lblRoomPrice.Name = "lblRoomPrice";
            this.lblRoomPrice.Size = new System.Drawing.Size(37, 21);
            this.lblRoomPrice.TabIndex = 153;
            this.lblRoomPrice.Text = "No:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(26, 669);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 22);
            this.label13.TabIndex = 152;
            this.label13.Text = "ServicePrice:";
            // 
            // lblStaffSetUp
            // 
            this.lblStaffSetUp.AutoSize = true;
            this.lblStaffSetUp.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffSetUp.Location = new System.Drawing.Point(325, 67);
            this.lblStaffSetUp.Name = "lblStaffSetUp";
            this.lblStaffSetUp.Size = new System.Drawing.Size(77, 21);
            this.lblStaffSetUp.TabIndex = 147;
            this.lblStaffSetUp.Text = "Founder:";
            // 
            // lblRoomTypeName
            // 
            this.lblRoomTypeName.AutoSize = true;
            this.lblRoomTypeName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomTypeName.Location = new System.Drawing.Point(498, 191);
            this.lblRoomTypeName.Name = "lblRoomTypeName";
            this.lblRoomTypeName.Size = new System.Drawing.Size(62, 21);
            this.lblRoomTypeName.TabIndex = 136;
            this.lblRoomTypeName.Text = "label25";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(344, 275);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 22);
            this.label15.TabIndex = 134;
            this.label15.Text = "Amount of People:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(344, 189);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 22);
            this.label19.TabIndex = 130;
            this.label19.Text = "type of Room:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(344, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(112, 22);
            this.label20.TabIndex = 129;
            this.label20.Text = "RoomName:";
            // 
            // lblCustomerTypeName
            // 
            this.lblCustomerTypeName.AutoSize = true;
            this.lblCustomerTypeName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerTypeName.Location = new System.Drawing.Point(172, 232);
            this.lblCustomerTypeName.Name = "lblCustomerTypeName";
            this.lblCustomerTypeName.Size = new System.Drawing.Size(61, 21);
            this.lblCustomerTypeName.TabIndex = 126;
            this.lblCustomerTypeName.Text = "label11";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(172, 167);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(62, 21);
            this.lblCustomerName.TabIndex = 123;
            this.lblCustomerName.Text = "label14";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 22);
            this.label5.TabIndex = 120;
            this.label5.Text = "CustomerType:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 118;
            this.label4.Text = "IdCard:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 22);
            this.label3.TabIndex = 117;
            this.label3.Text = "CustomerName:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelV4.Properties.Resources.THEME_HOTEL_SIGN_FIVE_STARS_FACADE_BUILDING_GettyImages_1320779330_3;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.Location = new System.Drawing.Point(474, 691);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(44, 21);
            this.lblFinalPrice.TabIndex = 161;
            this.lblFinalPrice.Text = "Date";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(150, 670);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(37, 21);
            this.lblTotalPrice.TabIndex = 159;
            this.lblTotalPrice.Text = "No:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(26, 690);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(51, 22);
            this.label31.TabIndex = 156;
            this.label31.Text = "Toal:";
            // 
            // lblServicePrice
            // 
            this.lblServicePrice.AutoSize = true;
            this.lblServicePrice.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServicePrice.Location = new System.Drawing.Point(150, 690);
            this.lblServicePrice.Name = "lblServicePrice";
            this.lblServicePrice.Size = new System.Drawing.Size(44, 21);
            this.lblServicePrice.TabIndex = 155;
            this.lblServicePrice.Text = "Date";
            // 
            // lblSurcharge
            // 
            this.lblSurcharge.AutoSize = true;
            this.lblSurcharge.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurcharge.Location = new System.Drawing.Point(474, 650);
            this.lblSurcharge.Name = "lblSurcharge";
            this.lblSurcharge.Size = new System.Drawing.Size(77, 21);
            this.lblSurcharge.TabIndex = 154;
            this.lblSurcharge.Text = "Founder:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(344, 647);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 22);
            this.label14.TabIndex = 151;
            this.label14.Text = "Charge:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label9.Location = new System.Drawing.Point(9, 624);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(595, 13);
            this.label9.TabIndex = 142;
            this.label9.Text = "_________________________________________________________________________________" +
    "_________________";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(234, 116);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(120, 22);
            this.label30.TabIndex = 145;
            this.label30.Text = "DateCreated:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(235, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 22);
            this.label28.TabIndex = 143;
            this.label28.Text = "No:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label27.Location = new System.Drawing.Point(9, 297);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(595, 13);
            this.label27.TabIndex = 141;
            this.label27.Text = "_________________________________________________________________________________" +
    "_________________";
            // 
            // lblPeoples
            // 
            this.lblPeoples.AutoSize = true;
            this.lblPeoples.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeoples.Location = new System.Drawing.Point(498, 277);
            this.lblPeoples.Name = "lblPeoples";
            this.lblPeoples.Size = new System.Drawing.Size(62, 21);
            this.lblPeoples.TabIndex = 140;
            this.lblPeoples.Text = "label21";
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(498, 254);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(62, 21);
            this.lblDays.TabIndex = 139;
            this.lblDays.Text = "label22";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(498, 168);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(62, 21);
            this.lblRoomName.TabIndex = 135;
            this.lblRoomName.Text = "label26";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(344, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 22);
            this.label16.TabIndex = 133;
            this.label16.Text = "Amount of Night:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(342, 231);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 22);
            this.label17.TabIndex = 132;
            this.label17.Text = "Arrival date:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationality.Location = new System.Drawing.Point(171, 276);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(53, 21);
            this.lblNationality.TabIndex = 128;
            this.lblNationality.Text = "label9";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(171, 254);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(62, 21);
            this.lblAddress.TabIndex = 127;
            this.lblAddress.Text = "label10";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(172, 210);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(62, 21);
            this.lblPhoneNumber.TabIndex = 125;
            this.lblPhoneNumber.Text = "label12";
            // 
            // lblIDCard
            // 
            this.lblIDCard.AutoSize = true;
            this.lblIDCard.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDCard.Location = new System.Drawing.Point(172, 188);
            this.lblIDCard.Name = "lblIDCard";
            this.lblIDCard.Size = new System.Drawing.Size(62, 21);
            this.lblIDCard.TabIndex = 124;
            this.lblIDCard.Text = "label13";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 22);
            this.label7.TabIndex = 122;
            this.label7.Text = "Nationality:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 22);
            this.label8.TabIndex = 121;
            this.label8.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(9, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(595, 13);
            this.label2.TabIndex = 116;
            this.label2.Text = "_________________________________________________________________________________" +
    "_________________";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 22);
            this.label6.TabIndex = 119;
            this.label6.Text = "Phonenumber:";
            // 
            // fPrintBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(614, 793);
            this.Controls.Add(this.listViewUseService);
            this.Controls.Add(this.lblIDBill);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.lblDateCheckIn);
            this.Controls.Add(this.lblRoomPrice_);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblDateCreate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblRoomPrice);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblStaffSetUp);
            this.Controls.Add(this.lblRoomTypeName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblCustomerTypeName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFinalPrice);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.lblServicePrice);
            this.Controls.Add(this.lblSurcharge);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblPeoples);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblIDCard);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fPrintBill";
            this.Text = "fPrintBill";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ListView listViewUseService;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblIDBill;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblDateCheckIn;
        private System.Windows.Forms.Label lblRoomPrice_;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblDateCreate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblRoomPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblStaffSetUp;
        private System.Windows.Forms.Label lblRoomTypeName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblCustomerTypeName;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblServicePrice;
        private System.Windows.Forms.Label lblSurcharge;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblPeoples;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblIDCard;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}