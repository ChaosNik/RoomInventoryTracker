using RestSharp;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISIO
{
    public partial class FormPerson : Form
    {

        private bool saved = false;
        private string accessKey;
        private Person person;
        private List<Calling> callings = new List<Calling>();
        Calling selectedcalling;
        private bool wrongUid = false;

        public FormPerson(string accessKey, Person person)
        {
            this.accessKey = accessKey;
            this.person = person;
            InitializeComponent();
            this.CenterToParent();
        }

        private void buttonSavePerson_Click(object sender, EventArgs e)
        {
            saved = true;
        }

        private void FormPerson_Load(object sender, EventArgs e)
        {
            newThreadForcallings();
            if (person != null)
            {
                textBoxLastNamePerson.Text = person.LastName;
                textBoxFirstNamePerson.Text = person.FirstName;
                maskedTextBoxUidPerson.Text = person.UIN;
                textBoxEmploymentPerson.Text = person.Employment;
                textBoxContactPerson.Text = person.Contact;
                comboBoxTitlePerson.SelectedItem = selectedcalling;
            }
        }

        private void newThreadForcallings()
        {
            Thread thread = new Thread(() =>
            {
                loadcallings();
            });
            thread.Start();
        }

        private void loadcallings()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/calling-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                callings = JsonSerializer.DeserializeFromString<List<Calling>>(response.Content);
                Console.WriteLine(callings.Count);
                this.comboBoxTitlePerson.Invoke((MethodInvoker)delegate {
                    foreach (var calling in callings)
                    {
                        comboBoxTitlePerson.Items.Add(calling);
                        if (person != null && calling.ID == person.CallingID)
                        {
                            selectedcalling = calling;
                        }
                    }
                    comboBoxTitlePerson.SelectedItem = selectedcalling;
                });
            }
        }

        private void FormPerson_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                string message = "";
                if (textBoxLastNamePerson.Text.Trim().Length == 0)
                {
                    message += "Insert last name.\n";
                }
                if (textBoxFirstNamePerson.Text.Trim().Length == 0)
                {
                    message += "Insert first name.\n";
                }
                if (comboBoxTitlePerson.Text.Trim().Length == 0)
                {
                    message += "Select calling.\n";
                }
                if (wrongUid || maskedTextBoxUidPerson.Text.Trim().Length != 13)
                {
                    message += "Insert UID.\n";
                }
                if (string.IsNullOrEmpty(message))
                {
                    RestClient client = null;
                    RestRequest request = null;
                    IRestResponse response = null;
                    if (person != null)
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/check?id=" + person.ID + "&access-token=" + accessKey);
                        request = new RestRequest(Method.GET);
                        response = client.Execute(request);
                        response.ContentType = "application/x-www-form-urlencoded";
                        if (response.StatusCode == System.Net.HttpStatusCode.OK && "true".Equals(response.Content))
                        {
                            client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/update?id=" + person.ID + "&access-token=" + accessKey);
                            request = new RestRequest(Method.PUT);
                        } else
                        {
                            e.Cancel = true;
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/create?access-token=" + accessKey);
                        request = new RestRequest(Method.POST);
                        request.AddParameter("ID", 0);
                    }
                    request.AddParameter("FirstName", textBoxFirstNamePerson.Text);
                    request.AddParameter("LastName", textBoxLastNamePerson.Text);
                    request.AddParameter("CallingID", ((Calling)comboBoxTitlePerson.SelectedItem).ID);
                    request.AddParameter("UIN", maskedTextBoxUidPerson.Text);
                    request.AddParameter("Employment", textBoxEmploymentPerson.Text);
                    request.AddParameter("Contact", textBoxContactPerson.Text);
                    request.AddParameter("Status", 1);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";  
                    if (response.StatusCode != System.Net.HttpStatusCode.OK && person != null)
                        {
                            e.Cancel = true;
                            MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    if (response.StatusCode != System.Net.HttpStatusCode.Created && person == null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Insert failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                   
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                saved = false;
            }
        }

        private void maskedTextBoxUidPerson_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxUidPerson.Text.Length == 13)
            {
                string jmbg = maskedTextBoxUidPerson.Text;
                string danStr = jmbg.Substring(0, 2);
                int dan = (int)decimal.Parse(danStr);
                string mjesecStr = jmbg.Substring(2, 2);
                int mjesec = (int)decimal.Parse(mjesecStr);
                string godinaStr = jmbg.Substring(4, 3);
                int godina = (int)decimal.Parse(godinaStr);
                if (godina >= 800)
                {
                    godina += 1000;
                }
                else
                {
                    godina += 2000;
                }
                try
                {
                    DateTime datum = new DateTime(godina, mjesec, dan);
                    if (datum > DateTime.Today.Date)
                    {
                        throw new Exception();
                    }
                    wrongUid = false;
                }
                catch (Exception exception)
                {
                    wrongUid = true;
                    var helpForm = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    MessageBox.Show(helpForm, "Wrong UID format.", "Fail");
                }
            }
        }


    }
}
