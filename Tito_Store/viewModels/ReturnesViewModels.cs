using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tito_Store.DataBase;
using Tito_Store.models;
using Tito_Store.View;

namespace Tito_Store.viewModels
{
    public partial class ReturnesViewModels : ObservableObject
    {
        // fields
        [ObservableProperty]
        int? productId;

        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        string? returnName;
        [ObservableProperty]
        ObservableCollection<Return> listOfReturn;
        [ObservableProperty]
        int quantityReturned;

        ReturnEntity oReturnEntity;
        InventoryItem oInventoryItem;
        InventoryEntity oInventoryEntity;

        public ReturnesViewModels()
        {
            oReturnEntity = new ReturnEntity();
            listOfReturn = new ObservableCollection<Return>();
            oInventoryEntity = new InventoryEntity();
            oInventoryItem = new InventoryItem();
        }

        // events 
        [RelayCommand]
        void Add()
        {

            // get all data from store 
            var storeData = oInventoryEntity.GetAll();
            // search on name on db
            var FindName = storeData.FirstOrDefault(name => name.ProductName == ReturnName);
            //cheeck on on name if it is null or no 
            if (FindName != null)
            {

                // add quntity of product 
                FindName.Quantity += QuantityReturned;
                // updata changes
                oInventoryEntity.Edite(oInventoryItem);
                Return oReturnes = new Return
                {
                    ReturnName = ReturnName,
                    QuantityReturned = QuantityReturned,
                    ReturnDate = DateTime.Now,
                };
                oReturnEntity.Add(oReturnes);
            }

            ReturnName = null;
            ProductId = null;


        }

        [RelayCommand]
        void Remove()
        {
            if (ProductId != null)
            {
                oInventoryEntity.Delete(ProductId);

            }
        }

      
    }
}
