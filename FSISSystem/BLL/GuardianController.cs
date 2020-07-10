using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#region Additional Namespaces
using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.ComponentModel;
#endregion

namespace FSISSystem.BLL
{
    public class GuardianController
    {
        public List<Guardian> Guardian_List()
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.ToList();
            }
        }
    }
}
