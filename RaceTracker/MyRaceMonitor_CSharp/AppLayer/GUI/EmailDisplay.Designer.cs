namespace AppLayer.GUI
{
    partial class EmailDisplay
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
            this.athTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // athTextBox
            // 
            this.athTextBox.Location = new System.Drawing.Point(12, 12);
            this.athTextBox.Name = "athTextBox";
            this.athTextBox.Size = new System.Drawing.Size(495, 367);
            this.athTextBox.TabIndex = 0;
            this.athTextBox.Text = "";
            // 
            // EmailDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 391);
            this.Controls.Add(this.athTextBox);
            this.Name = "EmailDisplay";
            this.Text = "AthleteListDisplay";
            this.Load += new System.EventHandler(this.ListDisplay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox athTextBox;
    }
}