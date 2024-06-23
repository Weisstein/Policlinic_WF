using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Policlinic_WF.Forms.Division_forms
{
    public partial class DivisionModule : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;
        Divisions divisions;

        public DivisionModule(Divisions divisions)
        {
            InitializeComponent();
            this.divisions = divisions;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("update Подразделение set Наимен_подразделения=@name, Телефон_подразделения=@phone, Зав_подразделением=@emp where Код_подразделения=" + lblCode.Text, connection);
                    cmd.Parameters.AddWithValue("@name",txtName.Text);
                    cmd.Parameters.AddWithValue("@phone",mtxtPhone.Text);
                    cmd.Parameters.AddWithValue("@emp",txtEmp.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                divisions.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
