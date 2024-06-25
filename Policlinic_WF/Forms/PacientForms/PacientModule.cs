using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Policlinic_WF.Forms.PacientForms
{
    public partial class PacientModule : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd;
        Pacient pacient;

        public PacientModule(Pacient pacient)
        {
            InitializeComponent();
            this.pacient = pacient;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd = new SqlCommand("update Пациент set Фамилия=@foreName,Имя=@name,Отчество=@patronymic,Адрес=@adress,Тел=@phone,Место_учебы_работы=@studWork,Инвалидность=@inv,Хрон_заболевания=@chron where Номер_карты=" + lblCode.Text, connection);
                    cmd.Parameters.AddWithValue("@foreName",txtForename.Text);
                    cmd.Parameters.AddWithValue("@name",txtName.Text);
                    cmd.Parameters.AddWithValue("@patronymic",txtPatronymic.Text);
                    cmd.Parameters.AddWithValue("@adress",txtAddress.Text);
                    cmd.Parameters.AddWithValue("@phone",mtxtPhone.Text);
                    cmd.Parameters.AddWithValue("@studWork",txtSudWork.Text);
                    cmd.Parameters.AddWithValue("@inv",cbInv.SelectedItem);
                    cmd.Parameters.AddWithValue("@chron",txtChron.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                pacient.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
