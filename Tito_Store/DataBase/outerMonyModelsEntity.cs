using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.models;

namespace Tito_Store.DataBase
{
    public class outerMonyModelsEntity : Idatahelper<OuterMonyModels>
    {
        DBContext db;
        public outerMonyModelsEntity()
        {
            db = new DBContext();
        }
        public void Add(OuterMonyModels item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public void Delete(int? Id)
        {
            var Data = GetAll();
            foreach (var item in Data)
            {
                if (item.Id == Id)
                {
                    db.Remove(item);
                    db.SaveChanges();
                    break; // Exit loop once the item is found and removed
                }
            }

        }

        public List<OuterMonyModels> GetAll()
        {
            return db.outerMonyModels.ToList();

        }

        public List<OuterMonyModels> GetName()
        {
            return db.outerMonyModels.ToList();
        }

        public void Update(OuterMonyModels item)
        {
            db.Update(item);
            db.SaveChanges();
        }

        public List<OuterMonyModels> SearchByClientName(string clientName)
        {
            return db.outerMonyModels
                     .Where(o => o.ClientName.Contains(clientName))
                     .ToList();
        }

    }
}
