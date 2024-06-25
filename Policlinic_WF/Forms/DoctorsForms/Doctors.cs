using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinic_WF.Forms.DoctorsForms
{
    public partial class Doctors : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;

        public Doctors()
        {
            InitializeComponent();
            LoadData();
            LoadDivisions();
        }

        public void LoadData()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand("select *,(select Наимен_подразделения from Подразделение where Подразделение.Код_подразделения = Врач.Код_подразделения) from Врач " +
                    "where concat(Таб_номер,Фамилия) like '%" + txtSearch.Text + "%' and Код_подразделения like '%" + cbSearch.SelectedValue + "%'", connection);
                connection.Open();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dgvDoctors.DataSource = dt;

            }
            this.dgvDoctors.Columns[9].Visible = false;

            dgvDoctors.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDoctors.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            dgvDoctors.Columns[1].HeaderText = "Табельный номер";
            dgvDoctors.Columns[6].HeaderText = "Дата рождения";
            dgvDoctors.Columns[7].HeaderText = "Дата приема на работу";
            dgvDoctors.Columns[10].HeaderText = "Код подразделения";
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
            string colName = dgvDoctors.Columns[e.ColumnIndex].Name;
            if(colName == "btnUpdate")
            {
                DoctorsModule doctorsModule = new DoctorsModule(this);
                doctorsModule.lblCode.Text = dgvDoctors.Rows[e.RowIndex].Cells[1].Value.ToString();
                doctorsModule.txtForename.Text = dgvDoctors.Rows[e.RowIndex].Cells[2].Value.ToString();
                doctorsModule.txtName.Text = dgvDoctors.Rows[e.RowIndex].Cells[3].Value.ToString();
                doctorsModule.txtPatronymic.Text = dgvDoctors.Rows[e.RowIndex].Cells[4].Value.ToString();
                doctorsModule.mtxtNum.Text = dgvDoctors.Rows[e.RowIndex].Cells[5].Value.ToString();
                doctorsModule.dtpBrthd.Value = Convert.ToDateTime(dgvDoctors.Rows[e.RowIndex].Cells[6].Value);
                doctorsModule.dtpPick.Value = Convert.ToDateTime(dgvDoctors.Rows[e.RowIndex].Cells[7].Value);
                doctorsModule.cbKval.SelectedItem = dgvDoctors.Rows[e.RowIndex].Cells[8].Value.ToString();
                doctorsModule.cbDiv.SelectedItem = dgvDoctors.Rows[e.RowIndex].Cells[10].Value.ToString();
                doctorsModule.Show();
            }
        }
    }
}
