using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal class TableFactory
    {
        private DataGridViewRow row;
        private string tableName;
        private bool insert;
        private bool delete;

        public TableFactory(DataGridViewRow row, string tableName, bool insert, bool delete)
        {
            this.row = row;
            this.tableName = tableName;
            this.insert = insert;
            this.delete = delete;
        }

        public string Generate()
        {
            BaseTable baseTable = Assembly.GetExecutingAssembly()
                .CreateInstance("RecruApp." + tableName) as BaseTable;
            if(insert)
                return baseTable.GenerateInsert(row);
            else if(delete)
                return baseTable.GenerateDelete(row);   
            else
                return baseTable.GenerateUpdate(row);
        }
    }
}
