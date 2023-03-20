using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecruApp
{
    internal abstract class BaseTable
    {
        public abstract string GenerateUpdate(DataGridViewRow row);

        public abstract string GenerateInsert(DataGridViewRow row);

        public abstract string GenerateDelete(DataGridViewRow row);
    }
}
