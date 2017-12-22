namespace AppLayer.GUI
{
    partial class GraphicalDisplay
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
            this.athListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeSize = new System.Windows.Forms.CheckBox();
            this.changeColor = new System.Windows.Forms.CheckBox();
            this.updateAthletesButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // athListView
            // 
            this.athListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.athListView.Location = new System.Drawing.Point(12, 12);
            this.athListView.Name = "athListView";
            this.athListView.Size = new System.Drawing.Size(96, 367);
            this.athListView.TabIndex = 0;
            this.athListView.UseCompatibleStateImageBehavior = false;
            this.athListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Athlete";
            this.columnHeader1.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeSize);
            this.groupBox1.Controls.Add(this.changeColor);
            this.groupBox1.Location = new System.Drawing.Point(114, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 69);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Athlete Features";
            // 
            // changeSize
            // 
            this.changeSize.AutoSize = true;
            this.changeSize.Location = new System.Drawing.Point(6, 42);
            this.changeSize.Name = "changeSize";
            this.changeSize.Size = new System.Drawing.Size(86, 17);
            this.changeSize.TabIndex = 4;
            this.changeSize.Text = "Change Size";
            this.changeSize.UseVisualStyleBackColor = true;
            // 
            // changeColor
            // 
            this.changeColor.AutoSize = true;
            this.changeColor.Location = new System.Drawing.Point(6, 19);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(90, 17);
            this.changeColor.TabIndex = 3;
            this.changeColor.Text = "Change Color";
            this.changeColor.UseVisualStyleBackColor = true;
            // 
            // updateAthletesButton
            // 
            this.updateAthletesButton.Location = new System.Drawing.Point(114, 87);
            this.updateAthletesButton.Name = "updateAthletesButton";
            this.updateAthletesButton.Size = new System.Drawing.Size(99, 23);
            this.updateAthletesButton.TabIndex = 16;
            this.updateAthletesButton.Text = "Update Athlete(s)";
            this.updateAthletesButton.UseVisualStyleBackColor = true;
            this.updateAthletesButton.Click += new System.EventHandler(this.updateAthletesButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "_________________________________________________________________";
            // 
            // GraphicalDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateAthletesButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.athListView);
            this.Name = "GraphicalDisplay";
            this.Text = "AthleteListDisplay";
            this.Load += new System.EventHandler(this.ListDisplay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView athListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox changeColor;
        private System.Windows.Forms.Button updateAthletesButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox changeSize;
    }
}