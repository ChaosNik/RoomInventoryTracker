using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace PISIO
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string accessKey = callGetAccessKey();
            if ("false".Equals(accessKey)) {
                MessageBox.Show("Wrong username or password", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                string roleString = callRole();
                int role = 0;
                FormHome home = new FormHome(accessKey, 0);//0-admin, 1-employee
                this.Hide();
                home.Closed += (s, args) => this.Close();
                home.Show();
            }
        }

        private string callGetAccessKey()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/api/get-access-key");
            var request = new RestRequest(Method.POST);
            //While testing
            request.AddParameter("username", textBoxUsername.Text);
            request.AddParameter("password", textBoxPassword.Text);
            //request.AddParameter("username", "milan");
            //request.AddParameter("password", "milanmilan");
            //request.AddParameter("username", "knikola");
            //request.AddParameter("password", "password");
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }

        private string callRole()
        {
            var client = new RestClient("http://pisio.etfbl.net/~knikola/PISIO/api/get-role");
            var request = new RestRequest(Method.POST);
            //While testing
            request.AddParameter("username", textBoxUsername.Text);
            request.AddParameter("password", textBoxPassword.Text);
            //request.AddParameter("username", "milan");
            //request.AddParameter("password", "milanmilan");
            //request.AddParameter("username", "knikola");
            //request.AddParameter("password", "password");
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }

    }
}
