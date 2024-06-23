using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Policlinic_WF.Forms.Division_forms
{
    public partial class Divisions : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter data;
        DataTable dt;

        public Divisions()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                dgvDivisions.Rows.Clear();
                cmd = new SqlCommand("select * from Подразделение as d " +
                    "where concat(d.Код_подразделения,d.Наимен_подразделения) like '%" + txtSearch.Text + "%'",connection);
                connection.Open();
                data = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Clear();
                data.Fill(dt);
                dgvDivisions.DataSource = dt;
            }

            dgvDivisions.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDivisions.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDivisions.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDivisions.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDivisions.Columns[1].HeaderText = "Код подразделения";
            dgvDivisions.Columns[2].HeaderText = "Наименование подразделения";
            dgvDivisions.Columns[3].HeaderText = "Телефон подразделения";
            dgvDivisions.Columns[4].HeaderText = "Заведующий подразделением";
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            LoadData();
        }

        private void dgvDivisions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvDivisions.Columns[e.ColumnIndex].Name;
            if (colName == "btnUpdate")
            {
                DivisionModule divisionModule = new DivisionModule(this);
                divisionModule.lblCode.Text = dgvDivisions.Rows[e.RowIndex].Cells[1].Value.ToString();
                divisionModule.txtName.Text = dgvDivisions.Rows[e.RowIndex].Cells[2].Value.ToString();
                divisionModule.mtxtPhone.Text = dgvDivisions.Rows[e.RowIndex].Cells[3].Value.ToString();
                divisionModule.txtEmp.Text = dgvDivisions.Rows[e.RowIndex].Cells[4].Value.ToString();
                divisionModule.txtName.Focus();
                divisionModule.ShowDialog();
            }
        }
    }
}
