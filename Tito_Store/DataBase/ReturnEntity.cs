using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.models;

namespace Tito_Store.DataBase
{
    public class ReturnEntity : Idatahelper<Return>
    {
        DBContext db;
        public ReturnEntity()
        {
            db = new DBContext();
        }
        public void Add(Return item)
        {
            db.Add(item);
            db.SaveChanges();
        }

        public void Delete(int? Id)
        {
            var Data = GetAll();
            foreach (var item in Data)
            {
                if (item.ReturnId == Id)
                {
                    db.Remove(item);
                    db.SaveChanges();
                    break; 
                }
            }
        }

        public List<Return> GetAll()
        {
            return db.Returns.ToList();
        }
    }
}
