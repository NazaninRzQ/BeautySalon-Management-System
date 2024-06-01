using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BeautySalon
{
    public partial class EditReservation : Form
    {
        public EditReservation()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string user;

        private void des_Click(object sender, EventArgs e)
        {
            
            if (reserve.Text == "")
            {
                MessageBox.Show("Enter Your name.");
            }
            else
            {
                user = reserve.Text;
                string query = "SELECT * FROM RESERVATION WHERE full_name= N'" + user + "'";
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\T460s\source\repos\BeautySalon\BeautySalon\Salon'sDatabase.mdf"";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                var rd = command.ExecuteReader();

                rd.Read();
                name.Text = rd["full_name"].ToString();
                phone.Text = rd["phoneNum"].ToString();
                date.Text = rd["date"].ToString();
                textBox1.Text = rd["service"].ToString();
                staff.Text = rd["staff_name"].ToString();


                reserve.Text = "";
             
                sqlConnection.Close();

            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            
            try
            {
                string c_name = name.Text;
                string phoneNum = phone.Text;
                string dat = date.Text;
                string service = textBox1.Text;
                string s_name = staff.Text;
                string query = "UPDATE RESERVATION SET full_name=N'" + c_name + "',phoneNum=N'" + phoneNum + "'," +
                    "date=N'" + dat + "',service=N'" + service + "', staff_name = N'"+s_name+"' WHERE full_name = N'"+user+"' " ;
                SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\T460s\\source\\repos\\BeautySalon\\BeautySalon\\Salon'sDatabase.mdf\";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Update OK");
                    name.Text = phone.Text = date.Text = textBox1.Text = staff.Text = "";
                    
                }
                else
                    MessageBox.Show("Update Failed.");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            
            try
            {
                string query = "DELETE FROM RESERVATION WHERE full_name=N'" + user + "'";
                SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\T460s\\source\\repos\\BeautySalon\\BeautySalon\\Salon'sDatabase.mdf\";Integrated Security=True");
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                int i = command.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("DELETE OK");
                    name.Text = phone.Text = date.Text = textBox1.Text = staff.Text = "";
                    
                }
                else
                    MessageBox.Show("Delete Failed.");
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
