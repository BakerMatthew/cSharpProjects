namespace AppLayer.GUI
{
    partial class ObserverCreationForm
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
            this.creationButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.typeGroupBox = new System.Windows.Forms.GroupBox();
            this.randomTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.emailTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.graphicalTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.listTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.typeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // creationButton
            // 
            this.creationButton.Location = new System.Drawing.Point(298, 133);
            this.creationButton.Name = "creationButton";
            this.creationButton.Size = new System.Drawing.Size(110, 23);
            this.creationButton.TabIndex = 0;
            this.creationButton.Text = "Create Observer";
            this.creationButton.UseVisualStyleBackColor = true;
            this.creationButton.Click += new System.EventHandler(this.creaetionButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(20, 133);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(17, 105);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 13);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Name:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(53, 102);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(355, 20);
            this.titleTextBox.TabIndex = 3;
            // 
            // typeGroupBox
            // 
            this.typeGroupBox.Controls.Add(this.randomTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.emailTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.graphicalTypeRadioButton);
            this.typeGroupBox.Controls.Add(this.listTypeRadioButton);
            this.typeGroupBox.Location = new System.Drawing.Point(20, 13);
            this.typeGroupBox.Name = "typeGroupBox";
            this.typeGroupBox.Size = new System.Drawing.Size(358, 75);
            this.typeGroupBox.TabIndex = 4;
            this.typeGroupBox.TabStop = false;
            this.typeGroupBox.Text = "Observer Type";
            // 
            // randomTypeRadioButton
            // 
            this.randomTypeRadioButton.AutoSize = true;
            this.randomTypeRadioButton.Location = new System.Drawing.Point(148, 42);
            this.randomTypeRadioButton.Name = "randomTypeRadioButton";
            this.randomTypeRadioButton.Size = new System.Drawing.Size(102, 17);
            this.randomTypeRadioButton.TabIndex = 3;
            this.randomTypeRadioButton.TabStop = true;
            this.randomTypeRadioButton.Text = "Random Display";
            this.randomTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // emailTypeRadioButton
            // 
            this.emailTypeRadioButton.AutoSize = true;
            this.emailTypeRadioButton.Location = new System.Drawing.Point(12, 42);
            this.emailTypeRadioButton.Name = "emailTypeRadioButton";
            this.emailTypeRadioButton.Size = new System.Drawing.Size(87, 17);
            this.emailTypeRadioButton.TabIndex = 2;
            this.emailTypeRadioButton.TabStop = true;
            this.emailTypeRadioButton.Text = "Email Display";
            this.emailTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // graphicalTypeRadioButton
            // 
            this.graphicalTypeRadioButton.AutoSize = true;
            this.graphicalTypeRadioButton.Location = new System.Drawing.Point(148, 19);
            this.graphicalTypeRadioButton.Name = "graphicalTypeRadioButton";
            this.graphicalTypeRadioButton.Size = new System.Drawing.Size(107, 17);
            this.graphicalTypeRadioButton.TabIndex = 1;
            this.graphicalTypeRadioButton.TabStop = true;
            this.graphicalTypeRadioButton.Text = "Graphical Display";
            this.graphicalTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // listTypeRadioButton
            // 
            this.listTypeRadioButton.AutoSize = true;
            this.listTypeRadioButton.Checked = true;
            this.listTypeRadioButton.Location = new System.Drawing.Point(12, 19);
            this.listTypeRadioButton.Name = "listTypeRadioButton";
            this.listTypeRadioButton.Size = new System.Drawing.Size(78, 17);
            this.listTypeRadioButton.TabIndex = 0;
            this.listTypeRadioButton.TabStop = true;
            this.listTypeRadioButton.Text = "List Display";
            this.listTypeRadioButton.UseVisualStyleBackColor = true;
            // 
            // ObserverCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 172);
            this.Controls.Add(this.typeGroupBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.creationButton);
            this.Name = "ObserverCreationForm";
            this.Text = "ObserverCreationForm";
            this.typeGroupBox.ResumeLayout(false);
            this.typeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button creationButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.GroupBox typeGroupBox;
        private System.Windows.Forms.RadioButton graphicalTypeRadioButton;
        private System.Windows.Forms.RadioButton listTypeRadioButton;
        private System.Windows.Forms.RadioButton emailTypeRadioButton;
        private System.Windows.Forms.RadioButton randomTypeRadioButton;
    }
}