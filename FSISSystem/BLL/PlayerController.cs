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
    [DataObject]
    public class PlayerController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_GetByTeam(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByTeam @TeamID",
                    new SqlParameter("TeamID", teamid));
                return results.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Player_GetByAgeGender(int age, string gender)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results =
                    context.Database.SqlQuery<Player>("Player_GetByAgeGender @Age, @Gender",
                    new SqlParameter("Age", age),
                    new SqlParameter("Gender", gender));
                return results.ToList();
            }
        }

        public Player Player_Find(int playerid)
        {
            using (var context = new FSISContext())
            {
                return context.Players.Find(playerid);
            }
        }

        public int Player_Add(Player item)
        {
            using (var context = new FSISContext())
            {
                context.Players.Add(item);
                context.SaveChanges();
                return item.PlayerID;
            }
        }

        public int Player_Update(Player item)
        {
            using (var context = new FSISContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int Player_Delete(int playerid)
        {
            using (var context = new FSISContext())
            {
                var existing = context.Players.Find(playerid);
                if (existing == null)
                {
                    throw new Exception("Record has been remove from database");
                }
                context.Players.Remove(existing);
                return context.SaveChanges();
            }
        }
    }
}
