using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

/*
 * Short instruction how program works
 * firsty choose table to work on
 * To use Update/Delete function double click row
 * Click delete button to delete selected row
 * Edit fieds then press Update button to update row in DB
 * In order to insert data to DB press button Enter Insert Mode
 * Then Insert data excluding primary key and date
 * press Insert to insert data into DB
 * 
 * Errors will be shown in label below buttons.
 * 
 * 
 * TODO/Known issues:
 * Should use SqlCommand parameters in order to prevent sql injection
 * Add starting table -> user doesn't have to click table name in ComboBox to see it's content in DGV
 * Add some dependencies between buttons
 * Rename variables and buttons
 */

namespace RecruApp
{
    public partial class MainWindow : Form
    {
        public DataTable dgvDataSource;
        string errorText;
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            LoadComboBox lcb = new LoadComboBox();
            lcb.Load(comboBox1);
        }

        private void buttonInsert_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            TableFactory tf = new TableFactory(row, comboBox1.Text, true,false);
            SqlCommand cmd = new SqlCommand(tf.Generate());
            DbQueryClass queryClass = new DbQueryClass();
            queryClass.ExecuteNonQuery(cmd, out errorText);
            label1.Text = errorText;    
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            TableFactory tf = new TableFactory(row, comboBox1.Text, false, true);
            SqlCommand cmd = new SqlCommand(tf.Generate());
            DbQueryClass queryClass = new DbQueryClass();
            queryClass.ExecuteNonQuery(cmd, out errorText);
            label1.Text = errorText;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[0];
            TableFactory tf = new TableFactory(row, comboBox1.Text, false, false);
            SqlCommand cmd = new SqlCommand(tf.Generate());
            DbQueryClass queryClass = new DbQueryClass();
            queryClass.ExecuteNonQuery(cmd, out errorText);
            label1.Text = errorText;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = dgvDataSource.Clone();
            dt.ImportRow(dgvDataSource.Rows[e.RowIndex]);
            dataGridView1.DataSource = dt;
            foreach(DataGridViewColumn dc in dataGridView1.Columns)
            {
                if (dc.Name.Contains("Date"))
                    dc.ReadOnly = true;
                else
                    dc.ReadOnly = false;
            }
            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbQueryClass dbQueryClass = new DbQueryClass();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [dbo].[{comboBox1.Text}]");
            string re;
            dgvDataSource = dbQueryClass.ExecuteQuery(cmd, out _);
            dataGridView1.DataSource = dgvDataSource;
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
                    dc.ReadOnly = true;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DbQueryClass dbQueryClass = new DbQueryClass();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [dbo].[{comboBox1.Text}]");
            string re;
            dgvDataSource = dbQueryClass.ExecuteQuery(cmd, out _);
            dataGridView1.DataSource = dgvDataSource;
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
                dc.ReadOnly = true;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvDataSource.Clone();
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                if (dc.Name.Contains("Date"))
                    dc.ReadOnly = true;
                else
                    dc.ReadOnly = false;
            }
            dataGridView1.Columns[0].ReadOnly = true;
        }
    }
}
