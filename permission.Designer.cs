
namespace HotelV4
{
    partial class permission
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbbStaffType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btndleft = new System.Windows.Forms.Button();
            this.btnleft = new System.Windows.Forms.Button();
            this.btndright = new System.Windows.Forms.Button();
            this.btnright = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvC = new System.Windows.Forms.DataGridView();
            this.colAccessNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdNow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvR = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdRest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbExit = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.cbbStaffType);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(713, 148);
            this.groupBox3.TabIndex = 64;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Employee Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 19);
            this.label10.TabIndex = 70;
            this.label10.Text = "Employee type name:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(493, 85);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(202, 41);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(274, 87);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(202, 37);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbbStaffType
            // 
            this.cbbStaffType.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStaffType.FormattingEnabled = true;
            this.cbbStaffType.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cbbStaffType.Location = new System.Drawing.Point(30, 70);
            this.cbbStaffType.Name = "cbbStaffType";
            this.cbbStaffType.Size = new System.Drawing.Size(221, 39);
            this.cbbStaffType.TabIndex = 67;
            this.cbbStaffType.SelectedIndexChanged += new System.EventHandler(this.cbbStaffType_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(493, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(202, 41);
            this.btnAdd.TabIndex = 45;
            this.btnAdd.Text = "Add new";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(274, 30);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(202, 37);
            this.btnEdit.TabIndex = 41;
            this.btnEdit.Text = "Edit Name";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(345, 32);
            this.label5.TabIndex = 65;
            this.label5.Text = "Employee Type Can Access";
            // 
            // btndleft
            // 
            this.btndleft.Location = new System.Drawing.Point(341, 263);
            this.btndleft.Name = "btndleft";
            this.btndleft.Size = new System.Drawing.Size(52, 41);
            this.btndleft.TabIndex = 71;
            this.btndleft.Text = "<<";
            this.btndleft.UseVisualStyleBackColor = true;
            this.btndleft.Click += new System.EventHandler(this.btndleft_Click);
            // 
            // btnleft
            // 
            this.btnleft.Location = new System.Drawing.Point(341, 321);
            this.btnleft.Name = "btnleft";
            this.btnleft.Size = new System.Drawing.Size(52, 41);
            this.btnleft.TabIndex = 72;
            this.btnleft.Text = "<";
            this.btnleft.UseVisualStyleBackColor = true;
            this.btnleft.Click += new System.EventHandler(this.btnleft_Click);
            // 
            // btndright
            // 
            this.btndright.Location = new System.Drawing.Point(341, 411);
            this.btndright.Name = "btndright";
            this.btndright.Size = new System.Drawing.Size(52, 41);
            this.btndright.TabIndex = 73;
            this.btndright.Text = ">>";
            this.btndright.UseVisualStyleBackColor = true;
            this.btndright.Click += new System.EventHandler(this.btndright_Click);
            // 
            // btnright
            // 
            this.btnright.Location = new System.Drawing.Point(341, 470);
            this.btnright.Name = "btnright";
            this.btnright.Size = new System.Drawing.Size(52, 41);
            this.btnright.TabIndex = 74;
            this.btnright.Text = ">";
            this.btnright.UseVisualStyleBackColor = true;
            this.btnright.Click += new System.EventHandler(this.btnright_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.dgvC);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 349);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current now";
            // 
            // dgvC
            // 
            this.dgvC.AllowUserToAddRows = false;
            this.dgvC.AllowUserToDeleteRows = false;
            this.dgvC.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccessNow,
            this.colIdNow});
            this.dgvC.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvC.Location = new System.Drawing.Point(7, 29);
            this.dgvC.Name = "dgvC";
            this.dgvC.ReadOnly = true;
            this.dgvC.Size = new System.Drawing.Size(292, 314);
            this.dgvC.TabIndex = 0;
            // 
            // colAccessNow
            // 
            this.colAccessNow.DataPropertyName = "name";
            this.colAccessNow.HeaderText = "";
            this.colAccessNow.MinimumWidth = 240;
            this.colAccessNow.Name = "colAccessNow";
            this.colAccessNow.ReadOnly = true;
            this.colAccessNow.Visible = false;
            this.colAccessNow.Width = 240;
            // 
            // colIdNow
            // 
            this.colIdNow.DataPropertyName = "id";
            this.colIdNow.HeaderText = "";
            this.colIdNow.Name = "colIdNow";
            this.colIdNow.ReadOnly = true;
            this.colIdNow.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.dgvR);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(420, 233);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 349);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remaining right";
            // 
            // dgvR
            // 
            this.dgvR.AllowUserToAddRows = false;
            this.dgvR.AllowUserToDeleteRows = false;
            this.dgvR.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.colIdRest});
            this.dgvR.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvR.Location = new System.Drawing.Point(6, 28);
            this.dgvR.Name = "dgvR";
            this.dgvR.ReadOnly = true;
            this.dgvR.Size = new System.Drawing.Size(293, 315);
            this.dgvR.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 240;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 240;
            // 
            // colIdRest
            // 
            this.colIdRest.DataPropertyName = "Id";
            this.colIdRest.HeaderText = "";
            this.colIdRest.Name = "colIdRest";
            this.colIdRest.ReadOnly = true;
            this.colIdRest.Visible = false;
            // 
            // lbExit
            // 
            this.lbExit.AutoSize = true;
            this.lbExit.BackColor = System.Drawing.Color.Transparent;
            this.lbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.Red;
            this.lbExit.Location = new System.Drawing.Point(699, 9);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(26, 25);
            this.lbExit.TabIndex = 75;
            this.lbExit.Text = "X";
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            // 
            // permission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 594);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnright);
            this.Controls.Add(this.btndright);
            this.Controls.Add(this.btnleft);
            this.Controls.Add(this.btndleft);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "permission";
            this.Text = "permission";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbbStaffType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btndleft;
        private System.Windows.Forms.Button btnleft;
        private System.Windows.Forms.Button btndright;
        private System.Windows.Forms.Button btnright;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvC;
        private System.Windows.Forms.DataGridView dgvR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdRest;
        private System.Windows.Forms.Label lbExit;
    }
}