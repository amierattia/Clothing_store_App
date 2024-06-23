using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.models;

namespace Tito_Store.DataBase
{
    public class OrderEntity : Idatahelper<OrderModels>
    {
         DBContext db;
        public OrderEntity()
        {
            db = new DBContext();
        }

        public void Add(OrderModels item)
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
                    break; 
                }
            }
        }

       

        public List<OrderModels> GetAll()
        {
            return db.Order.ToList();
        }
    }
}
