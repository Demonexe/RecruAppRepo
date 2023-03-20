using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal class Delivery : BaseTable
    {
        public override string GenerateUpdate(DataGridViewRow row)
        {
            return $"Update[dbo].[Delivery] set Supplier_ID = {row.Cells[1].Value}, Component_ID = {row.Cells[2].Value}, Quantity = {row.Cells[4].Value} where Delivery_ID = {row.Cells[0].Value}";
        }

        public override string GenerateInsert(DataGridViewRow row)
        {
            return $"Insert into [dbo].[Delivery] values(NEXT VALUE FOR [dbo].Delivery_Seq, {row.Cells[1].Value},{row.Cells[2].Value},GETDATE(),{row.Cells[4].Value})";
        }

        public override string GenerateDelete(DataGridViewRow row)
        {
            return $"Delete from [dbo].[Delivery] where Delivery_ID = {row.Cells[0].Value}";
        }
    }
}
