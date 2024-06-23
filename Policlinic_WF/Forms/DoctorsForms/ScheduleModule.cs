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

        }
    }
}
