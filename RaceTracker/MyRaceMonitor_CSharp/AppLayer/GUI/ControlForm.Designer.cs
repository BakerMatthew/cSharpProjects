namespace AppLayer.GUI
{
    partial class ControlForm
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
            this.otherAthListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.otherAthLabel = new System.Windows.Forms.Label();
            this.observersLabel = new System.Windows.Forms.Label();
            this.observedAthLabel = new System.Windows.Forms.Label();
            this.observedAthListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.observersListView = new System.Windows.Forms.ListView();
            this.unscribeButton = new System.Windows.Forms.Button();
            this.subscribeButton = new System.Windows.Forms.Button();
            this.createObserverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // otherAthListView
            // 
            this.otherAthListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.otherAthListView.FullRowSelect = true;
            this.otherAthListView.Location = new System.Drawing.Point(289, 35);
            this.otherAthListView.Name = "otherAthListView";
            this.otherAthListView.Size = new System.Drawing.Size(210, 447);
            this.otherAthListView.TabIndex = 1;
            this.otherAthListView.UseCompatibleStateImageBehavior = false;
            this.otherAthListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Bin #";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "First";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last";
            // 
            // otherAthLabel
            // 
            this.otherAthLabel.AutoSize = true;
            this.otherAthLabel.Location = new System.Drawing.Point(286, 18);
            this.otherAthLabel.Name = "otherAthLabel";
            this.otherAthLabel.Size = new System.Drawing.Size(102, 13);
            this.otherAthLabel.TabIndex = 2;
            this.otherAthLabel.Text = "Registered Athletes:";
            // 
            // observersLabel
            // 
            this.observersLabel.AutoSize = true;
            this.observersLabel.Location = new System.Drawing.Point(12, 18);
            this.observersLabel.Name = "observersLabel";
            this.observersLabel.Size = new System.Drawing.Size(58, 13);
            this.observersLabel.TabIndex = 3;
            this.observersLabel.Text = "Observers:";
            // 
            // observedAthLabel
            // 
            this.observedAthLabel.AutoSize = true;
            this.observedAthLabel.Location = new System.Drawing.Point(12, 194);
            this.observedAthLabel.Name = "observedAthLabel";
            this.observedAthLabel.Size = new System.Drawing.Size(79, 13);
            this.observedAthLabel.TabIndex = 5;
            this.observedAthLabel.Text = "Subscribed To:";
            // 
            // observedAthListView
            // 
            this.observedAthListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.observedAthListView.FullRowSelect = true;
            this.observedAthListView.Location = new System.Drawing.Point(15, 213);
            this.observedAthListView.Name = "observedAthListView";
            this.observedAthListView.Size = new System.Drawing.Size(210, 269);
            this.observedAthListView.TabIndex = 6;
            this.observedAthListView.UseCompatibleStateImageBehavior = false;
            this.observedAthListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Bin #";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "First";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last";
            // 
            // observersListView
            // 
            this.observersListView.Location = new System.Drawing.Point(12, 35);
            this.observersListView.MultiSelect = false;
            this.observersListView.Name = "observersListView";
            this.observersListView.Size = new System.Drawing.Size(213, 103);
            this.observersListView.TabIndex = 7;
            this.observersListView.UseCompatibleStateImageBehavior = false;
            this.observersListView.View = System.Windows.Forms.View.List;
            this.observersListView.SelectedIndexChanged += new System.EventHandler(this.observersListView_SelectedIndexChanged);
            // 
            // unscribeButton
            // 
            this.unscribeButton.Location = new System.Drawing.Point(234, 333);
            this.unscribeButton.Name = "unscribeButton";
            this.unscribeButton.Size = new System.Drawing.Size(41, 23);
            this.unscribeButton.TabIndex = 8;
            this.unscribeButton.Text = ">";
            this.unscribeButton.UseVisualStyleBackColor = true;
            this.unscribeButton.Click += new System.EventHandler(this.unscribeButton_Click);
            // 
            // subscribeButton
            // 
            this.subscribeButton.Location = new System.Drawing.Point(234, 298);
            this.subscribeButton.Name = "subscribeButton";
            this.subscribeButton.Size = new System.Drawing.Size(41, 23);
            this.subscribeButton.TabIndex = 9;
            this.subscribeButton.Text = "<";
            this.subscribeButton.UseVisualStyleBackColor = true;
            this.subscribeButton.Click += new System.EventHandler(this.subscribeButton_Click);
            // 
            // createObserverButton
            // 
            this.createObserverButton.Location = new System.Drawing.Point(12, 144);
            this.createObserverButton.Name = "createObserverButton";
            this.createObserverButton.Size = new System.Drawing.Size(75, 23);
            this.createObserverButton.TabIndex = 11;
            this.createObserverButton.Text = "Create";
            this.createObserverButton.UseVisualStyleBackColor = true;
            this.createObserverButton.Click += new System.EventHandler(this.createObserverButton_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 498);
            this.Controls.Add(this.createObserverButton);
            this.Controls.Add(this.subscribeButton);
            this.Controls.Add(this.unscribeButton);
            this.Controls.Add(this.observersListView);
            this.Controls.Add(this.observedAthListView);
            this.Controls.Add(this.observedAthLabel);
            this.Controls.Add(this.observersLabel);
            this.Controls.Add(this.otherAthLabel);
            this.Controls.Add(this.otherAthListView);
            this.Name = "ControlForm";
            this.Text = "ControlForm";
            this.Load += new System.EventHandler(this.ControlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView otherAthListView;
        private System.Windows.Forms.Label otherAthLabel;
        private System.Windows.Forms.Label observersLabel;
        private System.Windows.Forms.Label observedAthLabel;
        private System.Windows.Forms.ListView observedAthListView;
        private System.Windows.Forms.ListView observersListView;
        private System.Windows.Forms.Button unscribeButton;
        private System.Windows.Forms.Button subscribeButton;
        private System.Windows.Forms.Button createObserverButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}