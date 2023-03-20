using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecruApp
{
    internal class LoadComboBox
    {
        public void Load(ComboBox comboBox)
        {
            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME FROM RecruAppDb.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'");
            DbQueryClass query = new DbQueryClass();
            DataTable tableNames = query.ExecuteQuery(cmd, out _);
            foreach(DataRow row in tableNames.Rows)
                comboBox.Items.Add(row["TABLE_NAME"]);
        }
    }
}
