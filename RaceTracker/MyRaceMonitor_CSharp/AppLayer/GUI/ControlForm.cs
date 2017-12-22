using AppLayer.observer;
using AppLayer.subject;
using AppLayer.subject.impl;
using RaceData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RaceData.Messages;

namespace AppLayer.GUI
{
    public partial class ControlForm : Form, IAthleteUpdateHandler
    {
        public static List<Athlete> athletes = new List<Athlete>();
        private readonly List<Observer> observers = new List<Observer>();
        private Observer selectedObserver;
        private double courseLength;

        public ControlForm(double courseLength)
        {
            this.courseLength = courseLength;
            InitializeComponent();
        }

        private void RefreshObversersListView()
        {
            observersListView.Items.Clear();
            foreach (Observer observer in observers)
            {
                ListViewItem item = new ListViewItem(observer.title);
                observersListView.Items.Add(item);
            }
        }

        private void RefreshAthLists(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(RefreshAthLists), new object[] { sender, e });
            }
            else
            {
                observedAthListView.Items.Clear();
                otherAthListView.Items.Clear();

                if (selectedObserver != null)
                    observedAthLabel.Text = @"Subjects of " + selectedObserver.title;
                else
                    observedAthLabel.Text = @"No obverser selected";

                foreach (Athlete ath in athletes)
                {
                    var item = new ListViewItem(new[]
                    {
                        ath.bibNumber.ToString(),
                        ath.firstName.ToString(),
                        ath.lastName.ToString()
                    })
                    { Tag = ath };
                    if (selectedObserver != null && ath.observers.Contains(selectedObserver))
                        observedAthListView.Items.Add(item);
                    else
                        otherAthListView.Items.Add(item);
                }
            }
        }

        private void observersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (observersListView.SelectedIndices.Count == 1)
            {
                    selectedObserver = observers[observersListView.SelectedIndices[0]];
                    unscribeButton.Enabled = true;
                    subscribeButton.Enabled = true;
            }
            else
            {
                selectedObserver = null;
                unscribeButton.Enabled = true;
                subscribeButton.Enabled = true;
            }
            
            RefreshAthLists(sender, e);
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            RefreshObversersListView();
            RefreshAthLists(sender, e);
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            if (selectedObserver != null)
            {
                foreach (ListViewItem item in otherAthListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.registerObserver(selectedObserver);
                    subject?.notifyObservers();
                }
                RefreshAthLists(sender, e);
            }
        }

        private void unscribeButton_Click(object sender, EventArgs e)
        {
            if (selectedObserver != null)
            {
                foreach (ListViewItem item in observedAthListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.removeObserver(selectedObserver);
                    subject?.notifyObservers();
                }
                RefreshAthLists(sender, e);
            }
        }

        private void createObserverButton_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ObserverCreationForm
            {
                Text = @"New Observer",
                ObserverTitle = $"Observer #{observers.Count + 1}"
            };
            if (modalDialogForm.ShowDialog() == DialogResult.OK)
            {
                Observer observer;
                if (modalDialogForm.ObserverType == "L")
                    observer = new ListDisplay();
                else if (modalDialogForm.ObserverType == "E")
                    observer = new EmailDisplay("MyEmail@Domain.com");
                else if (modalDialogForm.ObserverType == "G")
                    observer = new GraphicalDisplay(courseLength);
                else
                    observer = new Observer();
                observer.title = modalDialogForm.ObserverTitle;
                observers.Add(observer);
                observer.Show();

                selectedObserver = null;
                observersListView.SelectedIndices.Clear();
                RefreshObversersListView();
                RefreshAthLists(sender, e);
            }

        }

        public void ProcessUpdate(AthleteUpdate updateMessage)
        {
            UpdateAthlete(updateMessage);
            Console.WriteLine(updateMessage.ToString());
        }

        private void UpdateAthlete(AthleteUpdate updateMessage)
        {
            int athIndex = FindAthleteWithBib(updateMessage.BibNumber);

            if (athIndex == -1)
            {
                CreateNewAthlete(updateMessage);
            } else
            {
                athletes[athIndex].updateStats(updateMessage);
            }
        }

        private int FindAthleteWithBib(int bibNumber)
        {
            int athIndex = -1;
            for (int index = 0; index < athletes.Count; index += 1)
            {
                if (athletes[index].bibNumber == bibNumber)
                {
                    athIndex = index;
                    break;
                }
            }
            return athIndex;
        }

        private void CreateNewAthlete(AthleteUpdate updateMessage)
        {
            RegistrationUpdate regUpdate = (RegistrationUpdate)updateMessage;
            Athlete ath = new Athlete()
            {
                status = updateMessage.UpdateType,
                timestamp = updateMessage.Timestamp,
                bibNumber = updateMessage.BibNumber,
                firstName = regUpdate.FirstName,
                lastName = regUpdate.LastName,
                gender = regUpdate.Gender,
                age = regUpdate.Age,
                locationOnCourse = 0.0,
                officialStartTime = null,
                officialEndTime = null
            };
            athletes.Add(ath);
            RefreshAthLists(new object(), new EventArgs());
        }
    }
}
