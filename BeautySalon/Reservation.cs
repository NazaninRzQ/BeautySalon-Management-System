using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BeautySalon
{
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }


        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            refresh();
        }

        void refresh()
        {
            try
            {
                service.Items.Clear();
                string query = "SELECT * FROM SERVICES";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\T460s\source\repos\BeautySalon\BeautySalon\Salon'sDatabase.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    service.Items.Add(dr["name"]);
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InsertBtn_Click(object sender, EventArgs e)
        {
            string serName = service.SelectedItem.ToString();
            try
            {
                string c_name = name.Text;
                string phoneNum = phone.Text;
                string dat = date.Text;

                string s_name = staff.Text;
                string query = "INSERT INTO RESERVATION (full_name ,phoneNum , date , service , staff_name)" +
                    "VALUES (N'" + c_name + "', N'" + phoneNum + "' , N'" + dat + "' , N'" + serName + "' , N'" + s_name + "')";

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\T460s\source\repos\BeautySalon\BeautySalon\Salon'sDatabase.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);

                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("Succesfull.");
                    name.Text = phone.Text = date.Text = staff.Text = service.SelectedText = "";

                }
                else
                {
                    MessageBox.Show("Reservation failed.");
                    name.Text = phone.Text = date.Text = staff.Text = service.SelectedText = "";

                }
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

    }
}
