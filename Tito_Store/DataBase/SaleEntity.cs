using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.models;
using Tito_Store.viewModels;

namespace Tito_Store.DataBase
{
    public class SaleEntity : Idatahelper<Sale>
    {
        DBContext db;
        public SaleEntity()
        {
            db = new DBContext();
        }
        public void Add(Sale item)
        {
            db.Add(item);
            db.SaveChanges();
           
           

        }

        public void Delete(int? Id)
        {
            var Data = GetAll();
            foreach (var item in Data)
            {
                if (item.SaleId == Id)
                {
                    db.Remove(item);
                    db.SaveChanges();
                    break; // Exit loop once the item is found and removed
                }
            }

        }
       

        public List<Sale> GetAll()
        {
            return db.Sales.ToList();
        }

       
        

    }
}
