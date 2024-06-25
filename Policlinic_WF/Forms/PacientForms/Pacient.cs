using Policlinic_WF.Forms.DoctorsForms;
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

namespace Policlinic_WF.Forms.PacientForms
{
    public partial class Pacient : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;

        public Pacient()
        {
            InitializeComponent();
            LoadData();
            LoadDivisions();
        }

        public void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand("select *,(select Наимен_подразделения from Подразделение where Подразделение.Код_подразделения = Пациент.Код_подразделения) from Пациент " +
                    "where concat(Номер_карты,Фамилия) like '%" + txtSearch.Text + "%' and Код_подразделения like '%" + cbSearch.SelectedValue + "%'", connection);
                connection.Open();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dgvPacient.DataSource = dt;
            }
            dgvPacient.Columns[2].Visible = false;

            dgvPacient.Columns[1].HeaderText = "Номер карты";
            dgvPacient.Columns[6].HeaderText = "Дата рождения";
            dgvPacient.Columns[9].HeaderText = "Страховой полис";
            dgvPacient.Columns[10].HeaderText = "Номер паспорта";
            dgvPacient.Columns[11].HeaderText = "Место учебы/работы";
            dgvPacient.Columns[13].HeaderText = "Хронические заболевания";
            dgvPacient.Columns[14].HeaderText = "Подразделение";

           
            for(int i = 0; i < dgvPacient.Columns.Count; i++)
            {
                dgvPacient.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
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
            cbSearch.Items.Clear();
            DataTable table = new DataTable();
            table = getTable("SELECT Код_подразделения,Наимен_подразделения FROM Подразделение");
            table.Rows.Add("0", "Выбор подразделения");
            cbSearch.DataSource = table;
            cbSearch.DisplayMember = "Наимен_подразделения";
            cbSearch.ValueMember = "Код_подразделения";
            cbSearch.SelectedValue = 0;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPacient.Columns[e.ColumnIndex].Name;
            if (colName == "btnUpdate")
            {
                PacientModule pacientModule = new PacientModule(this);
                pacientModule.lblCode.Text = dgvPacient.Rows[e.RowIndex].Cells[1].Value.ToString();
                pacientModule.txtForename.Text = dgvPacient.Rows[e.RowIndex].Cells[3].Value.ToString();
                pacientModule.txtName.Text = dgvPacient.Rows[e.RowIndex].Cells[4].Value.ToString();
                pacientModule.txtPatronymic.Text = dgvPacient.Rows[e.RowIndex].Cells[5].Value.ToString();
                pacientModule.dtpBirth.Value = Convert.ToDateTime(dgvPacient.Rows[e.RowIndex].Cells[6].Value);
                pacientModule.txtAddress.Text = dgvPacient.Rows[e.RowIndex].Cells[7].Value.ToString();
                pacientModule.mtxtPhone.Text = dgvPacient.Rows[e.RowIndex].Cells[8].Value.ToString();
                pacientModule.mtxtPolis.Text = dgvPacient.Rows[e.RowIndex].Cells[9].Value.ToString();
                pacientModule.mtxtDoc.Text = dgvPacient.Rows[e.RowIndex].Cells[10].Value.ToString();
                pacientModule.txtSudWork.Text = dgvPacient.Rows[e.RowIndex].Cells[11].Value.ToString();
                pacientModule.cbInv.SelectedItem = dgvPacient.Rows[e.RowIndex].Cells[12].Value.ToString();
                pacientModule.txtChron.Text = dgvPacient.Rows[e.RowIndex].Cells[13].Value.ToString();
                pacientModule.ShowDialog();
            }
        }
    }
}
