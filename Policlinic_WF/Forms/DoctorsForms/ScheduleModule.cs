using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Policlinic_WF.Forms.DoctorsForms
{
    public partial class ScheduleModule : Form
    {
        private string Code = string.Empty;

        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;

        public ScheduleModule(string code)
        {
            InitializeComponent();
            Code = code;
            LoadData();
        }

        public void LoadData()
        {
            short counter = 0; 
            SqlConnection connection = new SqlConnection(connectionString);
            cmd = new SqlCommand("select Пн,Вт,Ср,Чт,Пт,Сб,Вс from Расписание where Расписание.Таб_номер=" + Code, connection);
            connection.Open();
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            data.Fill(dt);
            connection.Close();
            for (int i = 0; i < dt.Rows[0].ItemArray.Length; i++)
            {
                string times = dt.Rows[0].ItemArray.ElementAt(i).ToString();
                string[] time = times.Split('-');
                foreach (string timeStr in time)
                {
                    (this.Controls["dtp"+counter] as DateTimePicker).Value = Convert.ToDateTime(timeStr);
                    counter++;
                }
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("update Расписание set Пн=@Pn,Вт=@Vt,Ср=@Sr,Чт=@Ht,Пт=@Pt,Сб=@Sb,Вс=@Vs where Таб_номер=" + Code, connection);
                    cmd.Parameters.AddWithValue("@Pn", dtp0.Text + "-" + dtp1.Text);
                    cmd.Parameters.AddWithValue("@Vt", dtp2.Text + "-" + dtp3.Text);
                    cmd.Parameters.AddWithValue("@Sr", dtp4.Text + "-" + dtp5.Text);
                    cmd.Parameters.AddWithValue("@Ht", dtp6.Text + "-" + dtp7.Text);
                    cmd.Parameters.AddWithValue("@Pt", dtp8.Text + "-" + dtp9.Text);
                    cmd.Parameters.AddWithValue("@Sb", dtp10.Text + "-" + dtp11.Text);
                    cmd.Parameters.AddWithValue("@Vs", dtp12.Text + "-" + dtp13.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
