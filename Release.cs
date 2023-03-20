using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal class Release : BaseTable
    {
        public override string GenerateUpdate(DataGridViewRow row)
        {
            return $"Update [dbo].[Release] set Component_ID = {row.Cells[1].Value} ,Quantity = {row.Cells[3].Value} where Release_ID = {row.Cells[0].Value}";
        }

        public override string GenerateInsert(DataGridViewRow row)
        {
            return $"Insert into [dbo].[Release] values(NEXT VALUE FOR [dbo].Release_Seq,{row.Cells[1].Value}, GETDATE(), {row.Cells[3].Value})";
        }
        public override string GenerateDelete(DataGridViewRow row)
        {
            return $"Delete from [dbo].[Release] where Release_ID = {row.Cells[0].Value}";
        }
    }
}
