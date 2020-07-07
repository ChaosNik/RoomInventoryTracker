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
    public partial class FormRoom : Form
    {
        private bool saved = false;
        private string accessKey;
        private Room room;
        private List<Building> buildings = new List<Building>();
        Building selectedBuilding;

        public FormRoom(String accessKey, Room room)
        {
            this.accessKey = accessKey;
            this.room = room;
            InitializeComponent();
            this.CenterToParent();
        }

        private void FormRoom_Load(object sender, EventArgs e)
        {
            newThreadForBuildings();       
            if (room != null)
            {
                textBoxRoomCode.Text = room.Code;
                textBoxRoomName.Text = room.Name;
                richTextBoxRoomDescription.Text = room.Description;
                comboBoxBuildings.SelectedItem = selectedBuilding;
            }
        }

        private void newThreadForBuildings()
        {
            Thread thread = new Thread(() =>
            {
                loadBuildings();
            });
            thread.Start();
        }

        private void loadBuildings()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                buildings = JsonSerializer.DeserializeFromString<List<Building>>(response.Content);
                this.comboBoxBuildings.Invoke((MethodInvoker)delegate {
                    comboBoxBuildings.Items.Clear();
                    foreach (var building in buildings)
                    {
                        comboBoxBuildings.Items.Add(building);
                        if (room != null && room.BuildingID == building.ID)
                        {
                            selectedBuilding = building;
                        }
                    }
                    comboBoxBuildings.SelectedItem = selectedBuilding;
                });               
            }
        }

        private void buttonRoomSave_Click(object sender, EventArgs e)
        {
            saved = true;
        }

        private void FormRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                string message = "";
                if (textBoxRoomCode.Text.Trim().Length == 0)
                {
                    message += "Insert code.\n";
                }
                if (textBoxRoomName.Text.Trim().Length == 0)
                {
                    message += "Insert name.\n";
                }
                if (comboBoxBuildings.SelectedItem == null)
                {
                    message += "Select building.\n";
                }
                RestClient client = null;
                RestRequest request = null;
                IRestResponse response = null;
                if (comboBoxBuildings.SelectedItem != null)
                {
                    client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/check?id=" + ((Building)comboBoxBuildings.SelectedItem).ID + "&access-token=" + accessKey);
                    request = new RestRequest(Method.GET);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode != System.Net.HttpStatusCode.OK || ("false".Equals(response.Content) && response.StatusCode == System.Net.HttpStatusCode.OK))
                    {
                        message += "Building deleted.\n";
                        newThreadForBuildings();
                    }
                }
                if (string.IsNullOrEmpty(message))
                {
                    if (room != null)
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/update?id=" + room.ID + "&access-token=" + accessKey);
                        request = new RestRequest(Method.PUT);        
                    }
                    else
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/create?access-token=" + accessKey);
                        request = new RestRequest(Method.POST);
                        request.AddParameter("ID", 0);
                    }
                    request.AddParameter("Code", textBoxRoomCode.Text);
                    request.AddParameter("Name", textBoxRoomName.Text);
                    request.AddParameter("Description", richTextBoxRoomDescription.Text);
                    request.AddParameter("BuildingID", ((Building)comboBoxBuildings.SelectedItem).ID);
                    request.AddParameter("Status", 1);
                    response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode != System.Net.HttpStatusCode.OK && room != null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (response.StatusCode != System.Net.HttpStatusCode.Created && room == null)
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

        private void comboBoxBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
