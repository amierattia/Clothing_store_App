using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.DataBase;
using Tito_Store.models;

namespace Tito_Store.viewModels
{
    public partial class SaleViewModels : ObservableObject
    {
        [ObservableProperty]
        string? productName;
        [ObservableProperty]
        int? saleId;
        [ObservableProperty]
        int quantitySold;
        [ObservableProperty]
        DateTime saleDate;
        [ObservableProperty]
        DateTime saleTime;
        [ObservableProperty]
        decimal? price;
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        ObservableCollection<Sale> listSale;

        public string? returnName()
        {
            return ProductName;
        }
        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrEmpty(ProductName) || QuantitySold <= 0 || Price == null)
            {
                return; 
            }

            SaleEntity oSaleEntity = new SaleEntity();
            InventoryEntity oInventoryEntity = new InventoryEntity();
            InventoryItem oInventoryItem = new InventoryItem();

            List<string> listInventoryItems = GetDataStore();

            if (listInventoryItems.Contains(ProductName))
            {
                var inventoryData = oInventoryEntity.GetAll();

                var productInInventory = inventoryData.FirstOrDefault(item => item.ProductName == ProductName);

                if (productInInventory != null )
                {
                    productInInventory.Quantity -= QuantitySold;
                    oInventoryEntity.Edite(productInInventory);

                    Sale oSale = new Sale
                    {
                        ProductName = ProductName,
                        QuantitySold = QuantitySold,
                        Price = Price,
                        SaleDate = DateTime.Now
                    };
                    oSaleEntity.Add(oSale);
                }
                else
                {
                   
                    return;
                }
            }

            GetAll();
            ProductName = null;
        }


        [RelayCommand]
        async void GetAll()
        {
            IsBusy = true;
            ListSale = new ObservableCollection<Sale>();

            if (ListSale == null)
            {
                IsBusy = false;
                return;
            }
            ListSale.Clear();

            SaleEntity oSaleEntity = new SaleEntity();
            if (oSaleEntity == null)
            {
                IsBusy = false;
                return;
            }

            var result = await Task.Run(() => oSaleEntity.GetAll());
            if (result != null)
            {
                ListSale.Clear();
                foreach (var item in result)
                {
                    if (item != null)
                    {
                        ListSale.Add(item);
                    }
                }
            }
            else
            {
                return;
            }

            IsBusy = false;
        }
        /// get all data from store 
        /// store data int list 
        /// cheeck on name if it in the list or no 
        /// the add to dataBase
        List<string> GetDataStore()
        {
            InventoryEntity oInventoryEntity = new InventoryEntity();
            var data = oInventoryEntity.GetAll();
            List<string> listSale = new List<string>();
            foreach (var item in data)
            {
                listSale.Add(item.ProductName);
            }
            return listSale;
        }



    }
}
