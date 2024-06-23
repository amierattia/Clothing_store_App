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
    public partial class OrderViewModels : ObservableObject
    {
        OrderEntity oOrderEntity = new OrderEntity();
        OrderModels oOrderModels = new OrderModels();
        // fields
        #region fields
        [ObservableProperty]
        string? orderName;
        [ObservableProperty]
        int? orderQuntity;
        [ObservableProperty]
        ObservableCollection<OrderModels> listModels;
        [ObservableProperty]
        int? orderId;
        [ObservableProperty]
        bool isBusy;
        #endregion

        #region Add
        [RelayCommand]
        void Add()
        {
            IsBusy = true;
            OrderEntity oOrderEntity = new OrderEntity();
            OrderModels oOrderModels = new OrderModels();
            if (OrderName == null || OrderQuntity == null)
            {
                IsBusy = false;
                return;
            }
            oOrderModels.OrderName = OrderName;
            oOrderModels.OrderQuntity = OrderQuntity;
            oOrderEntity.Add(oOrderModels);
            GetAll();
            OrderName = null;
            OrderQuntity = null;
            IsBusy = false;


        }
        #endregion

        #region Delete
        [RelayCommand]
        void Delet()
        {
            oOrderEntity.Delete(OrderId);
            GetAll();
            OrderId = null;
        }
        #endregion

        #region GetAll
        [RelayCommand]
        async void GetAll()
        {
            IsBusy = true;
            // intilaiz list 
            ListModels = new ObservableCollection<OrderModels>();
            var data = await Task.Run(() => oOrderEntity.GetAll());
            // add data to lis 
            foreach (var item in data)
            {
                if (data != null)
                {
                    ListModels.Add(item);
                }
                else
                {
                    IsBusy = false;

                    break;
                }
            }

            IsBusy = false;

        }

        #endregion


    }
}
