using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecruApp
{
    public partial class MainWindow : Form
    {
        public static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = RecruAppDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False";
        public DataTable dgvDataSource;
        private int ?row;
        string clickedString;
        public MainWindow()
        {
            InitializeComponent();
            UpdateDGV();
        }

        private void UpdateDGV()
        {
            string sqlQuery = "Select * from [dbo].[Components]";
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                dgvDataSource = new DataTable();
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = sqlQuery;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(dgvDataSource);
                dataGridView1.DataSource = dgvDataSource;
                sqlDataAdapter.Dispose();
                cmd.Dispose();
                sqlConn.Close();
            }
            row = null;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string sqlQuery = $"Insert into [dbo].[Components] values(NEXT VALUE FOR [dbo].[Components_Seq], '{textBox1.Text}')"; // change 10 flat value to 
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = sqlQuery;
                cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                sqlConn.Close();
            }
            UpdateDGV();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (row == null)
                return;
            string sqlQuery = $"Delete from [dbo].[Components] where Name = '{textBox1.Text}'";
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = sqlQuery;
                cmd.ExecuteNonQuery().ToString();
                cmd.Dispose();
                sqlConn.Close();
            }
            UpdateDGV();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (row == null)
                return;
            string sqlQuery = $"Update [dbo].[Components] set Name = '{textBox1.Text}' where Name = '{clickedString}'";
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConn;
                cmd.CommandText = sqlQuery;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                sqlConn.Close();
            }
            UpdateDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            clickedString = dgvDataSource.Rows[e.RowIndex].Field<string>(1);
            textBox1.Text = clickedString;
        }
    }
}
