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
    public partial class FormHome : Form
    {
        private string accessKey;
        private bool first = true;
        private List<PrimaryResource> primaryResources = new List<PrimaryResource>();
        private List<Room> rooms = new List<Room>();
        private List<Person> people = new List<Person>();
        private List<Building> buildings = new List<Building>();
        private List<Transit> transits = new List<Transit>();

        public FormHome(string accessKey, int role)
        {
            this.accessKey = accessKey.Substring(1, accessKey.Length - 2);
            InitializeComponent();
        }

        private void loadPrimaryResources()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/primary-resource-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                primaryResources = JsonSerializer.DeserializeFromString<List<PrimaryResource>>(response.Content);
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
            }
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
            }
        }

        private void loadTransits()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/transit-dsk/index?access-token=" + accessKey);
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            response.ContentType = "application/x-www-form-urlencoded";
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                transits = JsonSerializer.DeserializeFromString<List<Transit>>(response.Content);
            }
        }

        private void loadDataGridPrimaryResources()
        {
            string searchText = textBoxSearchPrimaryResource.Text.Trim();
            dataGridViewPrimaryResources.Rows.Clear();
            if ("Search for a resource ...".Equals(searchText)) searchText = "";
            searchText = searchText.ToLower();
            foreach (var primaryResource in primaryResources)
            {
                if (primaryResource.InventoryNumber.ToString().ToLower().StartsWith(searchText) || primaryResource.Name.ToLower().StartsWith(searchText) || primaryResource.Description.ToLower().StartsWith(searchText) || primaryResource.category.Name.ToLower().StartsWith(searchText) || primaryResource.room.Name.ToLower().StartsWith(searchText) || primaryResource.person.LastName.ToLower().StartsWith(searchText))
                {
                    DataGridViewRow dgvr = new DataGridViewRow()
                    {
                        Tag = primaryResource
                    };
                    dgvr.CreateCells(dataGridViewPrimaryResources);
                    dgvr.SetValues(primaryResource.InventoryNumber, primaryResource.Name, primaryResource.Description, primaryResource.DateOfPurchase.ToShortDateString(), primaryResource.Value, primaryResource.Ammortization, primaryResource.Location, primaryResource.condition.Name, primaryResource.category.Name, primaryResource.room.Name, primaryResource.person.FirstName + " " + primaryResource.person.LastName);
                    dataGridViewPrimaryResources.Rows.Add(dgvr);
                }
            }
            if (dataGridViewPrimaryResources.SelectedRows.Count > 0)
            {
                dataGridViewPrimaryResources.ClearSelection();
            }
        }

        private void loadDataGridRooms()
        {
            string searchText = textBoxSearchRoom.Text.Trim();
            dataGridViewRooms.Rows.Clear();
            if ("Search for a room ...".Equals(searchText)) searchText = "";
            searchText = searchText.ToLower();
            foreach (var room in rooms)
            {
                if (room.Code.ToLower().StartsWith(searchText) || room.Name.ToLower().StartsWith(searchText) || room.Description.ToLower().StartsWith(searchText) || room.building.Code.ToLower().StartsWith(searchText))
                {
                    DataGridViewRow dgvr = new DataGridViewRow()
                    {
                        Tag = room
                    };
                    dgvr.CreateCells(dataGridViewRooms);
                    dgvr.SetValues(room.Code, room.Name, room.Description, room.building.Code);
                    dataGridViewRooms.Rows.Add(dgvr);
                }
            }
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                dataGridViewRooms.ClearSelection();
            }
        }

        private void loadDataGridBuildings()
        {
            string searchText = textBoxBuildingSearch.Text.Trim();
            dataGridViewBuildings.Rows.Clear();
            if ("Search for a building ...".Equals(searchText)) searchText = "";
            searchText = searchText.ToLower();
            foreach (var building in buildings)
            {
                if (building.Code.ToLower().StartsWith(searchText) || building.Name.ToLower().StartsWith(searchText) || building.Description.ToLower().StartsWith(searchText) || ("(" + building.Latitude + ", " + building.Longitude + ")").StartsWith(searchText))
                {
                    DataGridViewRow dgvr = new DataGridViewRow()
                    {
                        Tag = building
                    };
                    dgvr.CreateCells(dataGridViewBuildings);
                    dgvr.SetValues(building.Code, building.Name, building.Description, "(" + Math.Round(building.Latitude, 3) + ", " + Math.Round(building.Longitude, 3) + ")");
                    dataGridViewBuildings.Rows.Add(dgvr);
                }
            }
            if (dataGridViewBuildings.SelectedRows.Count > 0)
            {
                dataGridViewBuildings.ClearSelection();
            }
        }

        private void loadDataGridPeople()
        {
            string searchText = textBoxSearchForPerson.Text.Trim();
            dataGridViewPeople.Rows.Clear();
            if ("Search for a person ...".Equals(searchText)) searchText = "";
            searchText = searchText.ToLower();
            foreach (var person in people)
            {
                if (person.LastName.ToLower().StartsWith(searchText) || person.FirstName.ToLower().StartsWith(searchText) || person.calling.Name.ToLower().StartsWith(searchText) || person.Employment.ToLower().StartsWith(searchText))
                {
                    DataGridViewRow dgvr = new DataGridViewRow()
                    {
                        Tag = person
                    };
                    dgvr.CreateCells(dataGridViewPeople);
                    dgvr.SetValues(person.LastName, person.FirstName, person.calling.Name, person.UIN, person.Employment, person.Contact);
                    dataGridViewPeople.Rows.Add(dgvr);
                }
            }
            if (dataGridViewPeople.SelectedRows.Count > 0)
            {
                dataGridViewPeople.ClearSelection();
            }
        }

        private void loadDataGridTransits()
        {
            string searchText = textBoxSearchTransit.Text.Trim();
            dataGridViewTransits.Rows.Clear();
            if ("Search for a transit ...".Equals(searchText)) searchText = "";
            searchText = searchText.ToLower();
            foreach (var transit in transits)
            {
                foreach (var room in rooms)
                {
                    if (transit.RoomIDFrom == room.ID)
                    {
                        transit.room_from = room;
                        break;
                    }
                }

                foreach (var room in rooms)
                {
                    if (transit.RoomIDTo == room.ID)
                    {
                        transit.room_to = room;
                        break;
                    }
                }

                foreach (var person in people)
                {
                    if (transit.PersonIDFrom == person.ID)
                    {
                        transit.person_from = person;
                    }
                }

                foreach (var person in people)
                {
                    if (transit.PersonIDTo == person.ID)
                    {
                        transit.person_to = person;
                    }
                }

                foreach (var resource in primaryResources)
                {
                    if (transit.PrimaryResourceID == resource.ID)
                    {
                        transit.primary_resource = resource;
                        break;
                    }
                }

                if (transit.room_from.Name.ToLower().StartsWith(searchText) || transit.room_to.Name.ToLower().StartsWith(searchText) || transit.person_from.LastName.ToLower().StartsWith(searchText) || transit.person_to.LastName.ToLower().StartsWith(searchText) || transit.primary_resource.Name.ToLower().StartsWith(searchText))
                {
                    DataGridViewRow dgvr = new DataGridViewRow()
                    {
                        Tag = transit
                    };
                
                    dgvr.CreateCells(dataGridViewTransits);
                    dgvr.SetValues(transit.DateAndTime.ToString(), transit.room_from.Name, transit.room_to.Name, transit.person_from.LastName + " " + transit.person_from.FirstName, transit.person_to.LastName + " " + transit.person_to.FirstName, transit.primary_resource.Name + " [" + transit.primary_resource.InventoryNumber +"]");
                    dataGridViewTransits.Rows.Add(dgvr);
                }
            }
            if (dataGridViewTransits.SelectedRows.Count > 0)
            {
                dataGridViewTransits.ClearSelection();
            }
        }

        #region load and tab changed

        private void FormHome_Load(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            first = false;
            loadPrimaryResources();
            loadDataGridPrimaryResources();
            textBoxSearchPrimaryResource.Text = "Search for a resource ...";
            textBoxSearchPrimaryResource.ForeColor = Color.Gray;
            textBoxBuildingSearch.Text = "Search for a building ...";
            textBoxBuildingSearch.ForeColor = Color.Gray;
            textBoxSearchRoom.Text = "Search for a room ...";
            textBoxSearchRoom.ForeColor = Color.Gray;
            textBoxSearchForPerson.Text = "Search for a person ...";
            textBoxSearchForPerson.ForeColor = Color.Gray;
            textBoxSearchTransit.Text = "Search for a transit ...";
            textBoxSearchTransit.ForeColor = Color.Gray;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0  && !first)
            {
                Thread thread = new Thread(() =>
                {
                    loadPrimaryResources();
                    this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridPrimaryResources();
                    });
                });
                thread.Start();
            } else if (tabControl.SelectedIndex == 1)
            {          
                this.Visible = true;
                Thread threadRooms = new Thread(() =>
                {
                    loadRooms();
                    this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridRooms();
                    });
                });
                threadRooms.Start();

                Thread threadBuildings = new Thread(() =>
                {
                    loadBuildings();
                    this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridBuildings();
                    });
                });
                threadBuildings.Start();
            }
            else if (tabControl.SelectedIndex == 2)
            {
                Thread threadPeople = new Thread(() =>
                {
                    loadPeople();
                    this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridPeople();
                    });
                });
                threadPeople.Start();
            }
            else if (tabControl.SelectedIndex == 3)
            {
                Thread thread = new Thread(() =>
                {
                    loadPeople();
                    loadRooms();
                    loadPrimaryResources();
                    loadTransits();
                    this.dataGridViewTransits.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridTransits();
                    });
                });
                thread.Start();
            }
        }

        private void textBoxBuildingSearch_TextChanged(object sender, EventArgs e)
        {
            loadDataGridBuildings();
        }

        private void textBoxBuildingSearch_Enter(object sender, EventArgs e)
        {
            if ("Search for a building ..." == textBoxBuildingSearch.Text)
            {
                textBoxBuildingSearch.Text = "";
                textBoxBuildingSearch.ForeColor = Color.Black;
            }
        }

        private void textBoxBuildingSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxBuildingSearch.Text == "")
            {
                textBoxBuildingSearch.Text = "Search for a building ...";
                textBoxBuildingSearch.ForeColor = Color.Gray;
            }
        }

        private void textBoxSearchRoom_Enter(object sender, EventArgs e)
        {
            if ("Search for a room ..." == textBoxSearchRoom.Text)
            {
                textBoxSearchRoom.Text = "";
                textBoxSearchRoom.ForeColor = Color.Black;
            }
        }

        private void textBoxSearchRoom_Leave(object sender, EventArgs e)
        {
            if (textBoxSearchRoom.Text == "")
            {
                textBoxSearchRoom.Text = "Search for a room ...";
                textBoxSearchRoom.ForeColor = Color.Gray;
            }
        }

        private void textBoxSearchRoom_TextChanged(object sender, EventArgs e)
        {
            loadDataGridRooms();
        }

        private void textBoxSearchForPerson_TextChanged(object sender, EventArgs e)
        {
            loadDataGridPeople();
        }

        private void textBoxSearchForPerson_Leave(object sender, EventArgs e)
        {
            if (textBoxSearchForPerson.Text == "")
            {
                textBoxSearchForPerson.Text = "Search for a person ...";
                textBoxSearchForPerson.ForeColor = Color.Gray;
            }
        }

        private void textBoxSearchForPerson_Enter(object sender, EventArgs e)
        {
            if ("Search for a person ..." == textBoxSearchForPerson.Text)
            {
                textBoxSearchForPerson.Text = "";
                textBoxSearchForPerson.ForeColor = Color.Black;
            }
        }

        private void textBoxSearchPrimaryResource_TextChanged(object sender, EventArgs e)
        {
            loadDataGridPrimaryResources();
        }

        private void textBoxSearchPrimaryResource_Leave(object sender, EventArgs e)
        {
            if (textBoxSearchPrimaryResource.Text == "")
            {
                textBoxSearchPrimaryResource.Text = "Search for a resource ...";
                textBoxSearchPrimaryResource.ForeColor = Color.Gray;
            }
        }

        private void textBoxSearchPrimaryResource_Enter(object sender, EventArgs e)
        {
            if ("Search for a resource ..." == textBoxSearchPrimaryResource.Text)
            {
                textBoxSearchPrimaryResource.Text = "";
                textBoxSearchPrimaryResource.ForeColor = Color.Black;
            }
        }

        private void textBoxSearchTransit_TextChanged(object sender, EventArgs e)
        {
            loadDataGridTransits();
        }

        private void textBoxSearchTransit_Leave(object sender, EventArgs e)
        {
            if (textBoxSearchTransit.Text == "")
            {
                textBoxSearchTransit.Text = "Search for a transit ...";
                textBoxSearchTransit.ForeColor = Color.Gray;
            }
        }

        private void textBoxSearchTransit_Enter(object sender, EventArgs e)
        {
            if ("Search for a transit ..." == textBoxSearchTransit.Text)
            {
                textBoxSearchTransit.Text = "";
                textBoxSearchTransit.ForeColor = Color.Black;
            }
        }

        #endregion

        private void dataGridViewBuildings_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewBuildings.CurrentCell = dataGridViewBuildings.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewBuildings.Rows[e.RowIndex].Selected = true;
                dataGridViewBuildings.Focus();
            }
            else
            {
                dataGridViewBuildings.ClearSelection();
            }
        }

        private void dataGridViewBuildings_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo hitTest = dataGridViewBuildings.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.None)
                {
                    dataGridViewBuildings.ClearSelection();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewRooms_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewRooms.CurrentCell = dataGridViewRooms.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewRooms.Rows[e.RowIndex].Selected = true;
                dataGridViewRooms.Focus();
            }
            else
            {
                dataGridViewRooms.ClearSelection();
            }
        }

        private void dataGridViewRooms_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo hitTest = dataGridViewRooms.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.None)
                {
                    dataGridViewRooms.ClearSelection();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewPeople.CurrentCell = dataGridViewPeople.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewPeople.Rows[e.RowIndex].Selected = true;
                dataGridViewPeople.Focus();
            }
            else
            {
                dataGridViewPeople.ClearSelection();
            }
        }

        private void dataGridViewPeople_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo hitTest = dataGridViewPeople.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.None)
                {
                    dataGridViewPeople.ClearSelection();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewPrimaryResources_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo hitTest = dataGridViewPrimaryResources.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.None)
                {
                    dataGridViewPrimaryResources.ClearSelection();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewPrimaryResources_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewPrimaryResources.CurrentCell = dataGridViewPrimaryResources.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewPrimaryResources.Rows[e.RowIndex].Selected = true;
                dataGridViewPrimaryResources.Focus();
            }
            else
            {
                dataGridViewPrimaryResources.ClearSelection();
            }
        }

        private void dataGridViewTransits_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewTransits.CurrentCell = dataGridViewTransits.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridViewTransits.Rows[e.RowIndex].Selected = true;
                dataGridViewTransits.Focus();
            }
            else
            {
                dataGridViewTransits.ClearSelection();
            }
        }

        private void dataGridViewTransits_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView.HitTestInfo hitTest = dataGridViewTransits.HitTest(e.X, e.Y);

                if (hitTest.Type == DataGridViewHitTestType.None)
                {
                    dataGridViewTransits.ClearSelection();
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void buttonAddBuilding_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FormBuilding(accessKey, null).ShowDialog())
            {
                var helpForm = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                MessageBox.Show(helpForm, "Inserted.", "Success");
                Thread thread = new Thread(() =>
                {
                    loadBuildings();
                    this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridBuildings();
                    });
                });
                thread.Start();

            }
        }

        private void dataGridViewBuildings_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateBuildingToolStripMenuItem.PerformClick();
        }

        private void dataGridViewBuildings_SelectionChanged(object sender, EventArgs e)
        {
            updateBuildingToolStripMenuItem.Enabled = deleteBuildingToolStripMenuItem.Enabled = dataGridViewBuildings.SelectedRows.Count == 1;
        }

        private void deleteBuildingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewBuildings.SelectedRows.Count == 1)
            {
                Building building = (Building)dataGridViewBuildings.SelectedRows[0].Tag;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete building ('" + building.Name + "') ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/delete?id=" + building.ID + "&access-token=" + accessKey);
                    var request = new RestRequest(Method.DELETE);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if ("false".Equals(response.Content.ToString()))
                        {
                            MessageBox.Show("Delete failed. There are still rooms in the building..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Deleted.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadBuildings();
                                loadRooms();
                                this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridBuildings();
                                });
                                this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridRooms();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadBuildings();
                            loadRooms();
                            this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridBuildings();
                            });
                            this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridRooms();
                            });
                        });
                        thread.Start();
                    }
                }
            }
        }

        private void updateBuildingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewBuildings.SelectedRows.Count == 1)
            {
                Building building = (Building)dataGridViewBuildings.SelectedRows[0].Tag;
                var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/view?id=" + building.ID + "&access-token=" + accessKey);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                response.ContentType = "application/x-www-form-urlencoded";
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    building = JsonSerializer.DeserializeFromString<Building>(response.Content);
                    if (building != null)
                    {
                        if (DialogResult.OK == new FormBuilding(accessKey, building).ShowDialog())
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Updated.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadBuildings();
                                this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridBuildings();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1))
                            .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadBuildings();
                            this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridBuildings();
                            });
                        });
                        thread.Start();
                    }
                }
                else
                {
                    var helpForm = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    MessageBox.Show(helpForm, "Error.", "Fail");
                    Thread thread = new Thread(() =>
                    {
                        loadBuildings();
                        this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                        {
                            loadDataGridBuildings();
                        });
                    });
                    thread.Start();
                }
            }
        }

        private void dataGridViewRooms_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateRoomToolStripMenuItem.PerformClick();
        }

        private void dataGridViewRooms_SelectionChanged(object sender, EventArgs e)
        {
            updateRoomToolStripMenuItem.Enabled = deleteRoomToolStripMenuItem.Enabled = dataGridViewRooms.SelectedRows.Count == 1;
        }

        private void buttonAddRoom_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FormRoom(accessKey, null).ShowDialog())
            {
                var helpForm = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                MessageBox.Show(helpForm, "Inserted.", "Success");
                Thread thread = new Thread(() =>
                {
                    loadRooms();
                    this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridRooms();
                    });
                });
                thread.Start();

            }
        }

        private void updateRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 1)
            {
                Room room = (Room)dataGridViewRooms.SelectedRows[0].Tag;
                bool fail = false;
                var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/view?id=" + room.ID + "&access-token=" + accessKey);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                response.ContentType = "application/x-www-form-urlencoded";
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    room = JsonSerializer.DeserializeFromString<Room>(response.Content);
                    if (room != null)
                    {
                        if (DialogResult.OK == new FormRoom(accessKey, room).ShowDialog())
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Updated.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadRooms();
                                this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridRooms();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else
                {
                    fail = true;
                }
                if (fail)
                {
                    var helpForm = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    MessageBox.Show(helpForm, "Error.", "Fail");
                    Thread thread = new Thread(() =>
                    {
                        loadBuildings();
                        loadRooms();
                        this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                        {
                            loadDataGridBuildings();
                        });
                        this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                        {
                            loadDataGridRooms();
                        });
                    });
                    thread.Start();
                }
            }
        }

        private void deleteRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count == 1)
            {
                Room room = (Room)dataGridViewRooms.SelectedRows[0].Tag;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete room ('" + room.Name + "') ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/room-dsk/delete?id=" + room.ID + "&access-token=" + accessKey);
                    var request = new RestRequest(Method.DELETE);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if ("false".Equals(response.Content.ToString()))
                        {
                            MessageBox.Show("Delete failed. There are transits and/or primary resources connected to this room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Deleted.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadRooms();
                                this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridRooms();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadBuildings();
                            loadRooms();
                            this.dataGridViewBuildings.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridBuildings();
                            });
                            this.dataGridViewRooms.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridRooms();
                            });
                        });
                        thread.Start();
                    }
                }
            }
        }

        private void dataGridViewPeople_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updatePersonToolStripMenuItem.PerformClick();
        }

        private void dataGridViewPeople_SelectionChanged(object sender, EventArgs e)
        {
            updatePersonToolStripMenuItem.Enabled = deletePersonToolStripMenuItem.Enabled = dataGridViewPeople.SelectedRows.Count == 1;
        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.SelectedRows.Count == 1)
            {
                Person person = (Person)dataGridViewPeople.SelectedRows[0].Tag;
                bool fail = false;
                var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/view?id=" + person.ID + "&access-token=" + accessKey);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                response.ContentType = "application/x-www-form-urlencoded";
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    person = JsonSerializer.DeserializeFromString<Person>(response.Content);
                    if (person != null)
                    {
                        if (DialogResult.OK == new FormPerson(accessKey, person).ShowDialog())
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Updated.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadPeople();
                                this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridPeople();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else
                {
                    fail = true;
                }
                if (fail)
                {
                    var helpForm = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    MessageBox.Show(helpForm, "Error.", "Fail");
                    Thread thread = new Thread(() =>
                    {
                        loadPeople();
                        this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                        {
                            loadDataGridPeople();
                        });
                    });
                    thread.Start();
                }
            }

        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.SelectedRows.Count == 1)
            {
                Person person = (Person)dataGridViewPeople.SelectedRows[0].Tag;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete person ('" + person.LastName + " " + person.FirstName + "') ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/person-dsk/delete?id=" + person.ID + "&access-token=" + accessKey);
                    var request = new RestRequest(Method.DELETE);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if ("false".Equals(response.Content.ToString()))
                        {
                            MessageBox.Show("Delete failed. There are transits and/or primary resources connected to this person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Deleted.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadPeople();
                                this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridPeople();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadPeople();
                            this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridPeople();
                            });
                        });
                        thread.Start();
                    }
                }
            }
        }

        private void buttonPersonAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FormPerson(accessKey, null).ShowDialog())
            {
                var helpForm = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                MessageBox.Show(helpForm, "Inserted.", "Success");
                Thread thread = new Thread(() =>
                {
                    loadPeople();
                    this.dataGridViewPeople.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridPeople();
                    });
                });
                thread.Start();

            }
        }

        private void dataGridViewPrimaryResources_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            updateResourceToolStripMenuItem.PerformClick();
        }

        private void buttonResourceAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FormPrimaryResource(accessKey, null).ShowDialog())
            {
                var helpForm = new Form() { Size = new Size(0, 0) };
                Task.Delay(TimeSpan.FromSeconds(1))
                    .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                MessageBox.Show(helpForm, "Inserted.", "Success");
                Thread thread = new Thread(() =>
                {              
                    loadPrimaryResources();
                    this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                    {
                        loadDataGridPrimaryResources();
                    });
                });
                thread.Start();

            }
        }

        private void updateResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrimaryResources.SelectedRows.Count == 1)
            {
                PrimaryResource resource = (PrimaryResource)dataGridViewPrimaryResources.SelectedRows[0].Tag;
                bool fail = false;
                var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/primary-resource-dsk/view?id=" + resource.ID + "&access-token=" + accessKey);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                response.ContentType = "application/x-www-form-urlencoded";
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    resource = JsonSerializer.DeserializeFromString<PrimaryResource>(response.Content);
                    if (resource != null)
                    {
                        if (DialogResult.OK == new FormPrimaryResource(accessKey, resource).ShowDialog())
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1))
                                .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Updated.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadPrimaryResources();
                                this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridPrimaryResources();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        fail = true;
                    }
                }
                else
                {
                    fail = true;
                }
                if (fail)
                {
                    var helpForm = new Form() { Size = new Size(0, 0) };
                    Task.Delay(TimeSpan.FromSeconds(1))
                        .ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                    MessageBox.Show(helpForm, "Error.", "Fail");
                    Thread thread = new Thread(() =>
                    {
                        loadPrimaryResources();
                        this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                        {
                            loadDataGridPrimaryResources();
                        });
                    });
                    thread.Start();
                }
            }
        }

        private void deleteResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrimaryResources.SelectedRows.Count == 1)
            {
                PrimaryResource resource = (PrimaryResource)dataGridViewPrimaryResources.SelectedRows[0].Tag;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete room ('" + resource.Name + "') ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/primary-resource-dsk/delete?id=" + resource.ID + "&access-token=" + accessKey);
                    var request = new RestRequest(Method.DELETE);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if ("false".Equals(response.Content.ToString()))
                        {
                            MessageBox.Show("Delete failed. There are transits and/or primary resources connected to this primary resource.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Deleted.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadPrimaryResources();
                                this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridPrimaryResources();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadPrimaryResources();
                            this.dataGridViewPrimaryResources.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridPrimaryResources();
                            });
                        });
                        thread.Start();
                    }
                }
            }
        }

        private void deleteTransitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransits.SelectedRows.Count == 1)
            {
                Transit resource = (Transit)dataGridViewTransits.SelectedRows[0].Tag;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete tranist ('" + resource.ID + "') ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/transit-dsk/delete?id=" + resource.ID + "&access-token=" + accessKey);
                    var request = new RestRequest(Method.DELETE);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if ("false".Equals(response.Content.ToString()))
                        {
                            MessageBox.Show("Delete failed. There are resources connected to this transit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var helpForm = new Form() { Size = new Size(0, 0) };
                            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                            MessageBox.Show(helpForm, "Deleted.", "Success");
                            Thread thread = new Thread(() =>
                            {
                                loadTransits();
                                this.dataGridViewTransits.Invoke((MethodInvoker)delegate
                                {
                                    loadDataGridTransits();
                                });
                            });
                            thread.Start();
                        }
                    }
                    else
                    {
                        var helpForm = new Form() { Size = new Size(0, 0) };
                        Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith((t) => helpForm.Close(), TaskScheduler.FromCurrentSynchronizationContext());
                        MessageBox.Show(helpForm, "Error.", "Fail");
                        Thread thread = new Thread(() =>
                        {
                            loadTransits();
                            this.dataGridViewTransits.Invoke((MethodInvoker)delegate
                            {
                                loadDataGridTransits();
                            });
                        });
                        thread.Start();
                    }
                }
            }
        }

        private void contextMenuStripBuilding_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
