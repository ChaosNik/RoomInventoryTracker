using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using RestSharp;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleJson;
using System.Globalization;

namespace PISIO
{
    public partial class FormBuilding : Form
    {
        private GMapOverlay markersOverlay = new GMapOverlay("markers");
        private bool saved = false;
        private double latitude = 0.00;
        private double longitude = 0.00;
        private string accessKey;
        private Building building;

        public FormBuilding(string accessKey, Building building)
        {
            this.accessKey = accessKey;
            this.building = building;
            InitializeComponent();
            this.CenterToParent();
        }

        private void FormBuilding_Load(object sender, EventArgs e)
        {
            gMapControlBuilding.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            var client = new RestClient("http://ip-api.com/json");
            var request = new RestRequest(Method.PUT);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var position = JsonSerializer.DeserializeFromString<Building>(response.Content);
                gMapControlBuilding.Position = new PointLatLng(position.Latitude, position.Longitude);
            } else
            {
                gMapControlBuilding.Position = new PointLatLng(44.77583, 17.18556);
            }  
            if (building != null)
            {
                latitude = building.Latitude;
                longitude = building.Longitude;
                gMapControlBuilding.Position = new PointLatLng(building.Latitude, building.Longitude);
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(building.Latitude, building.Longitude), GMarkerGoogleType.red);
                markersOverlay.Markers.Add(marker);
                gMapControlBuilding.Overlays.Add(markersOverlay);
                textBoxCodeBuilding.Text = building.Code;
                textBoxNameBuilding.Text = building.Name;
                richTextBoxDescriptionBuilding.Text = building.Description;
            }
        }

        private void gMapControlBuilding_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                latitude = gMapControlBuilding.FromLocalToLatLng(e.X, e.Y).Lat;
                longitude = gMapControlBuilding.FromLocalToLatLng(e.X, e.Y).Lng;
                if (markersOverlay.Markers.Count == 1)
                {
                    markersOverlay.Markers.Clear();
                }
                GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latitude, longitude), GMarkerGoogleType.red);
                markersOverlay.Markers.Add(marker);
                gMapControlBuilding.Overlays.Add(markersOverlay);
            }

        }

        private void buttonSaveBuilding_Click(object sender, EventArgs e)
        {
            saved = true;
        }

        private void FormBuilding_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saved)
            {
                string message = "";
                if (textBoxCodeBuilding.Text.Trim().Length == 0)
                {
                    message += "Insert code.\n";
                }
                if (textBoxNameBuilding.Text.Trim().Length == 0)
                {
                    message += "Insert name.\n";
                }
                if (markersOverlay.Markers.Count == 0)
                {
                    message += "Select position.\n";
                }
                if (string.IsNullOrEmpty(message)) {
                    RestClient client = null;
                    RestRequest request = null;
                    if (building != null)
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/update?id=" + building.ID + "&access-token=" + accessKey);
                        request = new RestRequest(Method.PUT);               
                    }
                    else
                    {
                        client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/building-dsk/create?access-token=" + accessKey);
                        request = new RestRequest(Method.POST);
                        request.AddParameter("ID", 0);
                    }
                    request.AddParameter("Code", textBoxCodeBuilding.Text);
                    request.AddParameter("Name", textBoxNameBuilding.Text);
                    request.AddParameter("Description", richTextBoxDescriptionBuilding.Text);
                    request.AddParameter("Latitude", latitude.ToString("N6", new CultureInfo("en-us")));
                    request.AddParameter("Longitude", longitude.ToString("N6", new CultureInfo("en-us")));
                    request.AddParameter("Status", 1);
                    IRestResponse response = client.Execute(request);
                    response.ContentType = "application/x-www-form-urlencoded";
                    if (response.StatusCode != System.Net.HttpStatusCode.OK && building != null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (response.StatusCode != System.Net.HttpStatusCode.Created && building == null)
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

    }
}
