using Policlinic_WF.Forms.Division_forms;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("update Врач set Фамилия=@foreName,Имя=@name,Отчество=@patronymic,Кабинет=@cab,Квалификация=@kval,Код_подразделения=@divCode where Таб_номер=" + lblCode.Text, connection);
                    cmd.Parameters.AddWithValue("@foreName", txtForename.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@patronymic", txtPatronymic.Text);
                    cmd.Parameters.AddWithValue("@cab", mtxtNum.Text);
                    cmd.Parameters.AddWithValue("@kval", cbKval.SelectedItem);
                    cmd.Parameters.AddWithValue("@divCode", cbDiv.SelectedValue);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                doctors.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
