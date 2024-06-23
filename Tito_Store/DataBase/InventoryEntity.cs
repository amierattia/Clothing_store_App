using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.models;
using Tito_Store.viewModels;

namespace Tito_Store.DataBase
{
    public class InventoryEntity : Idatahelper<InventoryItem>
    {
        DBContext db;
        public InventoryEntity()
        {
            db = new DBContext();
        }
        public void Add(InventoryItem item)
        {
            db.Inventory.Add(item);
            db.SaveChanges();

        }

        public void Delete(int? Id)
        {
            var Data = GetAll();
            foreach (var item in Data)
            {
                if (item.ProductId == Id)
                {
                    db.Remove(item);
                    db.SaveChanges();
                    break; // Exit loop once the item is found and removed
                }
            }
        }

        public List<InventoryItem> GetAll()
        {
            return db.Inventory.ToList();
        }

        public async void Edite(InventoryItem Quntity)
        {
            if(Quntity.Quantity <= 5)
            {
                Notification oNotification = new Notification();
                await oNotification.SendNotification("Xenon Store", $"الكميه بتاعه {Quntity.ProductName} قربت تخلص");

            }
            InventoryItem oInventoryItem = new InventoryItem();
            oInventoryItem.Quantity = Quntity.Quantity;
            db.SaveChanges();

        }

    }
}
