namespace PISIO
{
    partial class FormBuilding
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
            this.gMapControlBuilding = new GMap.NET.WindowsForms.GMapControl();
            this.labelCodeBuilding = new System.Windows.Forms.Label();
            this.textBoxCodeBuilding = new System.Windows.Forms.TextBox();
            this.labelNameBuilding = new System.Windows.Forms.Label();
            this.textBoxNameBuilding = new System.Windows.Forms.TextBox();
            this.labelDescriptionBuilding = new System.Windows.Forms.Label();
            this.richTextBoxDescriptionBuilding = new System.Windows.Forms.RichTextBox();
            this.labelPositionBuilding = new System.Windows.Forms.Label();
            this.buttonCancelBuilding = new System.Windows.Forms.Button();
            this.buttonSaveBuilding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapControlBuilding
            // 
            this.gMapControlBuilding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gMapControlBuilding.Bearing = 0F;
            this.gMapControlBuilding.CanDragMap = true;
            this.gMapControlBuilding.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControlBuilding.GrayScaleMode = false;
            this.gMapControlBuilding.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControlBuilding.LevelsKeepInMemmory = 5;
            this.gMapControlBuilding.Location = new System.Drawing.Point(7, 175);
            this.gMapControlBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gMapControlBuilding.MarkersEnabled = true;
            this.gMapControlBuilding.MaxZoom = 18;
            this.gMapControlBuilding.MinZoom = 2;
            this.gMapControlBuilding.MouseWheelZoomEnabled = true;
            this.gMapControlBuilding.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMapControlBuilding.Name = "gMapControlBuilding";
            this.gMapControlBuilding.NegativeMode = false;
            this.gMapControlBuilding.PolygonsEnabled = true;
            this.gMapControlBuilding.RetryLoadTile = 0;
            this.gMapControlBuilding.RoutesEnabled = true;
            this.gMapControlBuilding.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControlBuilding.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControlBuilding.ShowTileGridLines = false;
            this.gMapControlBuilding.Size = new System.Drawing.Size(333, 217);
            this.gMapControlBuilding.TabIndex = 0;
            this.gMapControlBuilding.Zoom = 12D;
            this.gMapControlBuilding.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControlBuilding_MouseClick);
            // 
            // labelCodeBuilding
            // 
            this.labelCodeBuilding.AutoSize = true;
            this.labelCodeBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodeBuilding.Location = new System.Drawing.Point(3, 9);
            this.labelCodeBuilding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCodeBuilding.Name = "labelCodeBuilding";
            this.labelCodeBuilding.Size = new System.Drawing.Size(56, 20);
            this.labelCodeBuilding.TabIndex = 1;
            this.labelCodeBuilding.Text = "Code:";
            // 
            // textBoxCodeBuilding
            // 
            this.textBoxCodeBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCodeBuilding.Location = new System.Drawing.Point(127, 6);
            this.textBoxCodeBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCodeBuilding.MaxLength = 30;
            this.textBoxCodeBuilding.Name = "textBoxCodeBuilding";
            this.textBoxCodeBuilding.Size = new System.Drawing.Size(213, 26);
            this.textBoxCodeBuilding.TabIndex = 2;
            // 
            // labelNameBuilding
            // 
            this.labelNameBuilding.AutoSize = true;
            this.labelNameBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameBuilding.Location = new System.Drawing.Point(3, 39);
            this.labelNameBuilding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNameBuilding.Name = "labelNameBuilding";
            this.labelNameBuilding.Size = new System.Drawing.Size(60, 20);
            this.labelNameBuilding.TabIndex = 3;
            this.labelNameBuilding.Text = "Name:";
            // 
            // textBoxNameBuilding
            // 
            this.textBoxNameBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNameBuilding.Location = new System.Drawing.Point(127, 36);
            this.textBoxNameBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNameBuilding.MaxLength = 30;
            this.textBoxNameBuilding.Name = "textBoxNameBuilding";
            this.textBoxNameBuilding.Size = new System.Drawing.Size(213, 26);
            this.textBoxNameBuilding.TabIndex = 4;
            // 
            // labelDescriptionBuilding
            // 
            this.labelDescriptionBuilding.AutoSize = true;
            this.labelDescriptionBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescriptionBuilding.Location = new System.Drawing.Point(3, 67);
            this.labelDescriptionBuilding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDescriptionBuilding.Name = "labelDescriptionBuilding";
            this.labelDescriptionBuilding.Size = new System.Drawing.Size(105, 20);
            this.labelDescriptionBuilding.TabIndex = 5;
            this.labelDescriptionBuilding.Text = "Description:";
            // 
            // richTextBoxDescriptionBuilding
            // 
            this.richTextBoxDescriptionBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxDescriptionBuilding.Location = new System.Drawing.Point(127, 66);
            this.richTextBoxDescriptionBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxDescriptionBuilding.MaxLength = 255;
            this.richTextBoxDescriptionBuilding.Name = "richTextBoxDescriptionBuilding";
            this.richTextBoxDescriptionBuilding.Size = new System.Drawing.Size(213, 79);
            this.richTextBoxDescriptionBuilding.TabIndex = 6;
            this.richTextBoxDescriptionBuilding.Text = "";
            // 
            // labelPositionBuilding
            // 
            this.labelPositionBuilding.AutoSize = true;
            this.labelPositionBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPositionBuilding.Location = new System.Drawing.Point(3, 151);
            this.labelPositionBuilding.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPositionBuilding.Name = "labelPositionBuilding";
            this.labelPositionBuilding.Size = new System.Drawing.Size(78, 20);
            this.labelPositionBuilding.TabIndex = 7;
            this.labelPositionBuilding.Text = "Position:";
            // 
            // buttonCancelBuilding
            // 
            this.buttonCancelBuilding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCancelBuilding.BackColor = System.Drawing.Color.DimGray;
            this.buttonCancelBuilding.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelBuilding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelBuilding.ForeColor = System.Drawing.Color.White;
            this.buttonCancelBuilding.Location = new System.Drawing.Point(136, 396);
            this.buttonCancelBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancelBuilding.Name = "buttonCancelBuilding";
            this.buttonCancelBuilding.Size = new System.Drawing.Size(100, 37);
            this.buttonCancelBuilding.TabIndex = 8;
            this.buttonCancelBuilding.Text = "Cancel";
            this.buttonCancelBuilding.UseVisualStyleBackColor = false;
            // 
            // buttonSaveBuilding
            // 
            this.buttonSaveBuilding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSaveBuilding.BackColor = System.Drawing.Color.DimGray;
            this.buttonSaveBuilding.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSaveBuilding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveBuilding.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveBuilding.ForeColor = System.Drawing.Color.White;
            this.buttonSaveBuilding.Location = new System.Drawing.Point(240, 396);
            this.buttonSaveBuilding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSaveBuilding.Name = "buttonSaveBuilding";
            this.buttonSaveBuilding.Size = new System.Drawing.Size(100, 37);
            this.buttonSaveBuilding.TabIndex = 9;
            this.buttonSaveBuilding.Text = "Save";
            this.buttonSaveBuilding.UseVisualStyleBackColor = false;
            this.buttonSaveBuilding.Click += new System.EventHandler(this.buttonSaveBuilding_Click);
            // 
            // FormBuilding
            // 
            this.AcceptButton = this.buttonSaveBuilding;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(348, 438);
            this.Controls.Add(this.buttonSaveBuilding);
            this.Controls.Add(this.buttonCancelBuilding);
            this.Controls.Add(this.labelPositionBuilding);
            this.Controls.Add(this.richTextBoxDescriptionBuilding);
            this.Controls.Add(this.labelDescriptionBuilding);
            this.Controls.Add(this.textBoxNameBuilding);
            this.Controls.Add(this.labelNameBuilding);
            this.Controls.Add(this.textBoxCodeBuilding);
            this.Controls.Add(this.labelCodeBuilding);
            this.Controls.Add(this.gMapControlBuilding);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormBuilding";
            this.Text = "Building";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBuilding_FormClosing);
            this.Load += new System.EventHandler(this.FormBuilding_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControlBuilding;
        private System.Windows.Forms.Label labelCodeBuilding;
        private System.Windows.Forms.TextBox textBoxCodeBuilding;
        private System.Windows.Forms.Label labelNameBuilding;
        private System.Windows.Forms.TextBox textBoxNameBuilding;
        private System.Windows.Forms.Label labelDescriptionBuilding;
        private System.Windows.Forms.RichTextBox richTextBoxDescriptionBuilding;
        private System.Windows.Forms.Label labelPositionBuilding;
        private System.Windows.Forms.Button buttonCancelBuilding;
        private System.Windows.Forms.Button buttonSaveBuilding;
    }
}