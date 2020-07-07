namespace PISIO
{
    partial class FormRoom
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
            this.labelRoomCode = new System.Windows.Forms.Label();
            this.labelRoomName = new System.Windows.Forms.Label();
            this.textBoxRoomCode = new System.Windows.Forms.TextBox();
            this.textBoxRoomName = new System.Windows.Forms.TextBox();
            this.richTextBoxRoomDescription = new System.Windows.Forms.RichTextBox();
            this.labelRoomBuilding = new System.Windows.Forms.Label();
            this.comboBoxBuildings = new System.Windows.Forms.ComboBox();
            this.buttonRoomSave = new System.Windows.Forms.Button();
            this.buttonRoomCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelRoomCode
            // 
            this.labelRoomCode.AutoSize = true;
            this.labelRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoomCode.Location = new System.Drawing.Point(3, 9);
            this.labelRoomCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoomCode.Name = "labelRoomCode";
            this.labelRoomCode.Size = new System.Drawing.Size(56, 20);
            this.labelRoomCode.TabIndex = 0;
            this.labelRoomCode.Text = "Code:";
            // 
            // labelRoomName
            // 
            this.labelRoomName.AutoSize = true;
            this.labelRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoomName.Location = new System.Drawing.Point(3, 39);
            this.labelRoomName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoomName.Name = "labelRoomName";
            this.labelRoomName.Size = new System.Drawing.Size(60, 20);
            this.labelRoomName.TabIndex = 1;
            this.labelRoomName.Text = "Name:";
            this.labelRoomName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxRoomCode
            // 
            this.textBoxRoomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoomCode.Location = new System.Drawing.Point(114, 6);
            this.textBoxRoomCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRoomCode.MaxLength = 30;
            this.textBoxRoomCode.Name = "textBoxRoomCode";
            this.textBoxRoomCode.Size = new System.Drawing.Size(213, 26);
            this.textBoxRoomCode.TabIndex = 3;
            // 
            // textBoxRoomName
            // 
            this.textBoxRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRoomName.Location = new System.Drawing.Point(114, 36);
            this.textBoxRoomName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRoomName.MaxLength = 30;
            this.textBoxRoomName.Name = "textBoxRoomName";
            this.textBoxRoomName.Size = new System.Drawing.Size(213, 26);
            this.textBoxRoomName.TabIndex = 4;
            // 
            // richTextBoxRoomDescription
            // 
            this.richTextBoxRoomDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxRoomDescription.Location = new System.Drawing.Point(114, 66);
            this.richTextBoxRoomDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxRoomDescription.MaxLength = 255;
            this.richTextBoxRoomDescription.Name = "richTextBoxRoomDescription";
            this.richTextBoxRoomDescription.Size = new System.Drawing.Size(213, 79);
            this.richTextBoxRoomDescription.TabIndex = 5;
            this.richTextBoxRoomDescription.Text = "";
            // 
            // labelRoomBuilding
            // 
            this.labelRoomBuilding.AutoSize = true;
            this.labelRoomBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoomBuilding.Location = new System.Drawing.Point(3, 152);
            this.labelRoomBuilding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoomBuilding.Name = "labelRoomBuilding";
            this.labelRoomBuilding.Size = new System.Drawing.Size(78, 20);
            this.labelRoomBuilding.TabIndex = 6;
            this.labelRoomBuilding.Text = "Building:";
            // 
            // comboBoxBuildings
            // 
            this.comboBoxBuildings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBuildings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBuildings.Location = new System.Drawing.Point(114, 149);
            this.comboBoxBuildings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxBuildings.Name = "comboBoxBuildings";
            this.comboBoxBuildings.Size = new System.Drawing.Size(213, 28);
            this.comboBoxBuildings.TabIndex = 7;
            this.comboBoxBuildings.SelectedIndexChanged += new System.EventHandler(this.comboBoxBuildings_SelectedIndexChanged);
            // 
            // buttonRoomSave
            // 
            this.buttonRoomSave.BackColor = System.Drawing.Color.DimGray;
            this.buttonRoomSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonRoomSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRoomSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRoomSave.ForeColor = System.Drawing.Color.White;
            this.buttonRoomSave.Location = new System.Drawing.Point(227, 181);
            this.buttonRoomSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRoomSave.Name = "buttonRoomSave";
            this.buttonRoomSave.Size = new System.Drawing.Size(100, 37);
            this.buttonRoomSave.TabIndex = 8;
            this.buttonRoomSave.Text = "Save";
            this.buttonRoomSave.UseVisualStyleBackColor = false;
            this.buttonRoomSave.Click += new System.EventHandler(this.buttonRoomSave_Click);
            // 
            // buttonRoomCancel
            // 
            this.buttonRoomCancel.BackColor = System.Drawing.Color.DimGray;
            this.buttonRoomCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonRoomCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRoomCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRoomCancel.ForeColor = System.Drawing.Color.White;
            this.buttonRoomCancel.Location = new System.Drawing.Point(123, 181);
            this.buttonRoomCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRoomCancel.Name = "buttonRoomCancel";
            this.buttonRoomCancel.Size = new System.Drawing.Size(100, 37);
            this.buttonRoomCancel.TabIndex = 9;
            this.buttonRoomCancel.Text = "Cancel";
            this.buttonRoomCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description:";
            // 
            // FormRoom
            // 
            this.AcceptButton = this.buttonRoomSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(334, 222);
            this.Controls.Add(this.buttonRoomCancel);
            this.Controls.Add(this.buttonRoomSave);
            this.Controls.Add(this.comboBoxBuildings);
            this.Controls.Add(this.labelRoomBuilding);
            this.Controls.Add(this.richTextBoxRoomDescription);
            this.Controls.Add(this.textBoxRoomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRoomCode);
            this.Controls.Add(this.labelRoomName);
            this.Controls.Add(this.labelRoomCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRoom";
            this.Text = "Room";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRoom_FormClosing);
            this.Load += new System.EventHandler(this.FormRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRoomCode;
        private System.Windows.Forms.Label labelRoomName;
        private System.Windows.Forms.TextBox textBoxRoomCode;
        private System.Windows.Forms.TextBox textBoxRoomName;
        private System.Windows.Forms.RichTextBox richTextBoxRoomDescription;
        private System.Windows.Forms.Label labelRoomBuilding;
        private System.Windows.Forms.ComboBox comboBoxBuildings;
        private System.Windows.Forms.Button buttonRoomSave;
        private System.Windows.Forms.Button buttonRoomCancel;
        private System.Windows.Forms.Label label1;
    }
}