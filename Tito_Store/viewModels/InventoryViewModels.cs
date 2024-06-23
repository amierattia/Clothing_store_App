using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.LocalNotification;
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
    public partial class InventoryViewModels : ObservableObject
    {
        [ObservableProperty]
        string? productName;
        [ObservableProperty]
        int quantity;
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        int? id;
        [ObservableProperty]
        ObservableCollection<InventoryItem> inventory;


        [RelayCommand]
        void Add()
        {
            InventoryItem oInventoryItem = new InventoryItem();
            InventoryEntity oInventoryEntity = new InventoryEntity();
            var QuntityStore = oInventoryEntity.GetAll();
            var FindQuntity = QuntityStore.FirstOrDefault(q => q.Quantity <= 5);

            if (ProductName != null || Quantity != null)
            {
                oInventoryItem.ProductName = ProductName;
                oInventoryItem.Quantity = Quantity;
                oInventoryEntity.Add(oInventoryItem);
            }
            else
            {
                return;
            }
            GetAll();
            ProductName = null;
            //Quantity = null;

        }

        [RelayCommand]
        async void GetAll()
        {
            IsBusy = true;
            Inventory = new ObservableCollection<InventoryItem>();

            if (Inventory == null)
            {
                IsBusy = false;
                return;
            }
            Inventory.Clear();

            InventoryEntity oInventoryEntity = new InventoryEntity();
            if (oInventoryEntity == null)
            {
                IsBusy = false;
                return;
            }

            var result = await Task.Run(() => oInventoryEntity.GetAll());
            if (result != null)
            {
                Inventory.Clear();
                foreach (var item in result)
                {
                    if (item != null)
                    {
                        Inventory.Add(item);
                    }
                }
            }
            else
            {
                return;
            }

            IsBusy = false;
        }

       

    }



}
