using System;
using System.Windows.Forms;

namespace AppLayer.GUI
{
    public partial class ObserverCreationForm : Form
    {
        public ObserverCreationForm()
        {
            InitializeComponent();
        }

        public string ObserverTitle
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        private void creaetionButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public string ObserverType
        {
            get
            {
                if (listTypeRadioButton.Checked)
                    return "L";
                else if (graphicalTypeRadioButton.Checked)
                    return "G";
                else if (emailTypeRadioButton.Checked)
                    return "E";
                else
                    return "R";
            }
        }
    }
}
