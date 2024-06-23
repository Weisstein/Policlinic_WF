using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinic_WF.Forms.DoctorsForms
{
    public partial class DoctorsModule : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;
        Doctors doctors;

        public DoctorsModule(Doctors doctors)
        {
            InitializeComponent();
            LoadDivisions();
            this.doctors = doctors;

        }

        private DataTable getTable(string qery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand(qery, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }

        }

        private void LoadDivisions()
        {
            cbDiv.Items.Clear();
            cbDiv.DataSource = getTable("SELECT Код_подразделения,Наимен_подразделения FROM Подразделение");
            cbDiv.DisplayMember = "Наимен_подразделения";
            cbDiv.ValueMember = "Код_подразделения";
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            ScheduleModule scheduleModule = new ScheduleModule(lblCode.Text);
            scheduleModule.Show();
        }
    }
}
