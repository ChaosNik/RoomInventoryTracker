using RestSharp;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISIO
{
    public partial class FormPrimaryResource : Form
    {
        private bool saved = false;
        private string accessKey;
        private PrimaryResource resource;
        private List<Category> categories = new List<Category>();
        private List<Condition> conditions = new List<Condition>();
        private List<Room> rooms = new List<Room>();
        private List<Person> people = new List<Person>();
        Category selectedCategory = null;
        Room selectedRoom = null;
        Person selectedPerson = null;
        Condition selectedCondition = null;

        public FormPrimaryResource(string accessKey, PrimaryResource resource)
        {
            this.accessKey = accessKey;
            this.resource = resource;
            InitializeComponent();
            this.CenterToParent();
        }

        private void FormResource_Load(object sender, EventArgs e)
        {
            newThreadForCategories();
            newThreadForConditions();
            newThreadForRooms();
            newThreadForPeople();
            if (resource != null)
            {
                textBoxNumberResource.Text = resource.InventoryNumber;
                textBoxNameResource.Text = resource.Name;
                richTextBoxDescriptionResource.Text = resource.Description;
                dateTimePickerDatePurchaseResource.Value = resource.DateOfPurchase;
                textBoxValueResource.Text = resource.Value.ToString();
                numericUpDownAmortizationResource.Value = (decimal)resource.Ammortization;
                richTextBoxLocationResource.Text = resource.Location;
                comboBoxCategoryResource.SelectedItem = selectedCategory;
                comboBoxRoomResource.SelectedItem = selectedRoom;
                comboBoxPersonResource.SelectedItem = selectedPerson;
            } 
        }

        private void newThreadForCategories()
        {
            Thread thread = new Thread(() =>
            {
                loadCategories();
            });
            thread.Start();
        }

        private void newThreadForConditions()
        {
            Thread thread = new Thread(() =>
            {
                loadConditions();
            });
            thread.Start();
        }

        private void newThreadForRooms()
        {
            Thread thread = new Thread(() =>
            {
                loadRooms();
            });
            thread.Start();
        }

        private void newThreadForPeople()
        {
            Thread thread = new Thread(() =>
            {
                loadPeople();
            });
            thread.Start();
        }

        private void loadCategories()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/category-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                categories = JsonSerializer.DeserializeFromString<List<Category>>(response.Content);
                this.comboBoxCategoryResource.Invoke((MethodInvoker)delegate
                {
                    comboBoxCategoryResource.Items.Clear();
                    foreach (var category in categories)
                    {
                        comboBoxCategoryResource.Items.Add(category);
                        if (resource != null && resource.CategoryID == category.ID)
                        {
                            selectedCategory = category;
                        }
                    }
                    comboBoxCategoryResource.SelectedItem = selectedCategory;
                });
            }
        }

        private void loadConditions()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/condition-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                conditions = JsonSerializer.DeserializeFromString<List<Condition>>(response.Content);
                this.comboBoxStatusResource.Invoke((MethodInvoker)delegate
                {
                    comboBoxStatusResource.Items.Clear();
                    foreach (var condition in conditions)
                    {
                        comboBoxStatusResource.Items.Add(condition);
                        if (resource != null && resource.ConditionID == condition.ID)
                        {
                            selectedCondition = condition;
                        }
                    }
                    comboBoxStatusResource.SelectedItem = selectedCondition;
                });
            }
        }

        private void loadRooms()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                rooms = JsonSerializer.DeserializeFromString<List<Room>>(response.Content);
                this.comboBoxRoomResource.Invoke((MethodInvoker)delegate
                {
                    comboBoxRoomResource.Items.Clear();
                    foreach (var room in rooms)
                    {
                        comboBoxRoomResource.Items.Add(room);
                        if (resource != null && resource.RoomID == room.ID)
                        {
                            selectedRoom = room;
                        }
                    }
                    comboBoxRoomResource.SelectedItem = selectedRoom;
                });
            }
        }

        private void loadPeople()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                people = JsonSerializer.DeserializeFromString<List<Person>>(response.Content);
                this.comboBoxPersonResource.Invoke((MethodInvoker)delegate
                {
                    comboBoxPersonResource.Items.Clear();
                    foreach (var person in people)
                    {
                        comboBoxPersonResource.Items.Add(person);
                        if (resource != null && resource.PersonID == person.ID)
                        {
                            selectedPerson = person;
                        }
                    }
                    comboBoxPersonResource.SelectedItem = selectedPerson;
                });
            }
        }

        private void FormResource_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                string message = "";
                if (textBoxNumberResource.Text.Trim().Length == 0)
                {
                    message += "Insert invertory number.\n";
                }
                if (textBoxNameResource.Text.Trim().Length == 0)
                {
                    message += "Insert name.\n";
                }
                if (textBoxValueResource.Text.Trim().Length == 0)
                {
                    message += "Insert value.\n";
                }
                if (numericUpDownAmortizationResource.Value.ToString().Trim().Length == 0)
                {
                    message += "Insert amortization.\n";
                }
                if (comboBoxCategoryResource.SelectedItem == null)
                {
                    message += "Select category.\n";
                }
                if (comboBoxStatusResource.SelectedItem == null)
                {
                    message += "Select current condition.\n";
                }
                if (comboBoxPersonResource.SelectedItem == null)
                {
                    message += "Select person.\n";
                }
                if (comboBoxRoomResource.SelectedItem == null)
                {
                    message += "Select room.\n";
                }
                if (richTextBoxLocationResource.Text.Trim().Length == 0)
                {
                    message += "Insert location.\n";
                }
                RestClient client = null;
                RestRequest request = null;
                IRestResponse response = null;
                if (comboBoxRoomResource.SelectedItem != null)
                {
                    client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/check?id=" + ((Room)comboBoxRoomResource.SelectedItem).ID + "&access-token=" + accessKey);
                    request = new RestRequest(Method.GET);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode != System.Net.HttpStatusCode.OK || ("false".Equals(response.Content) && response.StatusCode == System.Net.HttpStatusCode.OK))
                    {
                        message += "Room deleted.\n";
                        newThreadForRooms();
                    }
                }
                if (comboBoxPersonResource.SelectedItem != null)
                {
                    client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/check?id=" + ((Person)comboBoxPersonResource.SelectedItem).ID + "&access-token=" + accessKey);
                    request = new RestRequest(Method.GET);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode != System.Net.HttpStatusCode.OK || ("false".Equals(response.Content) && response.StatusCode == System.Net.HttpStatusCode.OK))
                    {
                        message += "Person deleted.\n";
                        newThreadForPeople();
                    }
                }
                if (string.IsNullOrEmpty(message))
                {
                    if (resource != null)
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/primary-resource-dsk/update?id=" + resource.ID + "&access-token=" + accessKey);
                        request = new RestRequest(Method.PUT);
                    }
                    else
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/primary-resource-dsk/create?access-token=" + accessKey);
                        request = new RestRequest(Method.POST);
                        request.AddParameter("ID", 0);
                    }
                    request.AddParameter("InventoryNumber", textBoxNumberResource.Text);
                    request.AddParameter("Name", textBoxNameResource.Text);
                    request.AddParameter("Description", richTextBoxDescriptionResource.Text);
                    request.AddParameter("DateOfPurchase", dateTimePickerDatePurchaseResource.Value.Date.ToString("yyyy-MM-dd"));
                    request.AddParameter("Value", textBoxValueResource.Text);
                    request.AddParameter("Ammortization", numericUpDownAmortizationResource.Value.ToString("N6", new CultureInfo("en-us")));
                    request.AddParameter("Location", richTextBoxLocationResource.Text);
                    request.AddParameter("CategoryID", ((Category)comboBoxCategoryResource.SelectedItem).ID);
                    request.AddParameter("ConditionID", ((Condition)comboBoxStatusResource.SelectedItem).ID);
                    request.AddParameter("RoomID", ((Room)comboBoxRoomResource.SelectedItem).ID);
                    request.AddParameter("PersonID", ((Person)comboBoxPersonResource.SelectedItem).ID);
                    request.AddParameter("Status", 1);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";                
                    if (resource != null && response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (resource == null && response.StatusCode != System.Net.HttpStatusCode.Created)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Insert failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                                    
                   if (resource != null && (resource.RoomID != ((Room)comboBoxRoomResource.SelectedItem).ID ||
                        resource.PersonID != ((Person)comboBoxPersonResource.SelectedItem).ID))
                    {
                        var clientTrans = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/transit-dsk/create?access-token=" + accessKey);
                        var requestTrans = new RestRequest(Method.POST);
                        requestTrans.AddParameter("DateAndTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        requestTrans.AddParameter("RoomIDFrom", resource.RoomID);
                        requestTrans.AddParameter("RoomIDTo", ((Room)comboBoxRoomResource.SelectedItem).ID);
                        requestTrans.AddParameter("PersonIDFrom", resource.PersonID);
                        requestTrans.AddParameter("PersonIDTo", ((Person)comboBoxPersonResource.SelectedItem).ID);
                        requestTrans.AddParameter("PrimaryResourceID", resource.ID);
                        requestTrans.AddParameter("Status", 1);
                        response = clientTrans.Execute(requestTrans);
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

        private void buttonSaveResource_Click(object sender, EventArgs e)
        {
            saved = true;
        }

        private void textBoxValueResource_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            //check if '.' , ',' pressed
            char sepratorChar = 's';
            if (e.KeyChar == '.')
            {
                // check if it's in the beginning of text not accept
                if (textBoxValueResource.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (textBoxValueResource.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(textBoxValueResource.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (textBoxValueResource.SelectionStart != textBoxValueResource.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = textBoxValueResource.Text.Substring(textBoxValueResource.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(textBoxValueResource.Text, ref sepratorChar))
                {
                    int sepratorPosition = textBoxValueResource.Text.IndexOf(sepratorChar);
                    string afterSepratorString = textBoxValueResource.Text.Substring(sepratorPosition + 1);
                    if (textBoxValueResource.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }

                }
            }
        }

        private bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }
            return false;
        }



    }
}
