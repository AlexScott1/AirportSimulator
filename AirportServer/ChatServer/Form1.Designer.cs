namespace ChatServer
{
    partial class Form1
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
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totalTakeOffsTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.planesLandedTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // displayTextBox
            // 
            this.displayTextBox.AcceptsReturn = true;
            this.displayTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.displayTextBox.Location = new System.Drawing.Point(36, 76);
            this.displayTextBox.MaxLength = 327674;
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ReadOnly = true;
            this.displayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayTextBox.Size = new System.Drawing.Size(421, 190);
            this.displayTextBox.TabIndex = 0;
            this.displayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.displayTextBox.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Take-off log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of planes taken off:";
            // 
            // totalTakeOffsTB
            // 
            this.totalTakeOffsTB.Enabled = false;
            this.totalTakeOffsTB.Location = new System.Drawing.Point(416, 24);
            this.totalTakeOffsTB.Name = "totalTakeOffsTB";
            this.totalTakeOffsTB.ReadOnly = true;
            this.totalTakeOffsTB.Size = new System.Drawing.Size(39, 20);
            this.totalTakeOffsTB.TabIndex = 4;
            this.totalTakeOffsTB.Text = "0";
            this.totalTakeOffsTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalTakeOffsTB.TextChanged += new System.EventHandler(this.totalTakeOffsTB_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Number of planes landed:";
            // 
            // planesLandedTB
            // 
            this.planesLandedTB.Enabled = false;
            this.planesLandedTB.Location = new System.Drawing.Point(416, 49);
            this.planesLandedTB.Name = "planesLandedTB";
            this.planesLandedTB.ReadOnly = true;
            this.planesLandedTB.Size = new System.Drawing.Size(39, 20);
            this.planesLandedTB.TabIndex = 6;
            this.planesLandedTB.Text = "0";
            this.planesLandedTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 297);
            this.Controls.Add(this.planesLandedTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalTakeOffsTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayTextBox);
            this.Name = "Form1";
            this.Text = "Airport Logging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox totalTakeOffsTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox planesLandedTB;
    }
}
