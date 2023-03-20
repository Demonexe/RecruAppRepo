using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal class Components : BaseTable
    {
        public override string GenerateUpdate(DataGridViewRow row)
        {
            return $"Update [dbo].[Components] set Name = '{row.Cells[1].Value}' where Component_ID = {row.Cells[0].Value}";
        }

        public override string GenerateInsert(DataGridViewRow row)
        {
            return $"Insert into [dbo].[Components] values(NEXT VALUE FOR [dbo].Components_Seq, '{row.Cells[1].Value}')";
        }

        public override string GenerateDelete(DataGridViewRow row)
        {
            return $"Delete from [dbo].[Components] where Component_ID = {row.Cells[0].Value}";
        }
    }
}
