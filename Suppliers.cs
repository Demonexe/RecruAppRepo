using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal class Suppliers : BaseTable
    {
        public override string GenerateUpdate(DataGridViewRow row)
        {
            return $"Update [dbo].[Suppliers] set Name = '{row.Cells[1].Value}', E-mail = '{row.Cells[2].Value}', Phone_number = '{row.Cells[3].Value}', Address = '{row.Cells[4].Value}'," +
                $" City = '{row.Cells[5].Value}', Postal_code = '{row.Cells[6].Value}' where Supplier_ID = {row.Cells[0].Value}";
        }

        public override string GenerateInsert(DataGridViewRow row)
        {
            return $"Insert into [dbo].[Suppliers] values(NEXT VALUE FOR [dbo].Suppliers_Seq, '{row.Cells[1].Value}', '{row.Cells[2].Value}', '{row.Cells[3].Value}','{row.Cells[4].Value}','{row.Cells[5].Value}','{row.Cells[6].Value}')";
        }

        public override string GenerateDelete(DataGridViewRow row)
        {
            return $"Delete from [dbo].[Suppliers] where Supplier_ID = {row.Cells[0].Value}";
        }
    }
}
