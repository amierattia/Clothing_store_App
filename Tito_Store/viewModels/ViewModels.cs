using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tito_Store.DataBase;
using Tito_Store.models;

namespace Tito_Store.viewModels
{
    public partial class ViewModels : ObservableObject
    {
       
       
        

        #region FieldsOfOuterModels
        [ObservableProperty]
        string? clientName;
        [ObservableProperty]
        string? productName;
        [ObservableProperty]
        decimal? outerPrice;
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        private ObservableCollection<OuterMonyModels> outer;
        #endregion

     




     

        #region EventsOfouterMony
        [RelayCommand]
        void AddOuter()
        {
            
            // call classes
            outerMonyModelsEntity OouterMonyModelsEntity = new outerMonyModelsEntity();
            OuterMonyModels oOuterMonyModels = new OuterMonyModels();
            // pass fields to models
            oOuterMonyModels.ClientName = ClientName;
            oOuterMonyModels.ProductName = ProductName;
            oOuterMonyModels.outerPrice = OuterPrice;
            // add data data base
            OouterMonyModelsEntity.Add(oOuterMonyModels);
            GetOuter();
            ClientName = "";
            ProductName = "";
            OuterPrice = null;
        }

        [RelayCommand]
        async void GetOuter()
        {
            // call classes 
            outerMonyModelsEntity OouterMonyModelsEntity = new outerMonyModelsEntity();
            // call indecator
            IsBusy = true;
            // ObservableCollection Of Models to view data from data base 
            Outer = new ObservableCollection<OuterMonyModels>();
            // check on list if it null or no 

            // if list is null stop indecator and stop process
            if (Outer == null)
            {
                IsBusy = false;
                return;
            }
            // if list is not null make loop to add all data from db to list
            var result = await Task.Run(() => OouterMonyModelsEntity.GetAll());
            Outer.Clear();
            foreach (var item in result)
            {
                if (item != null)
                {
                    Outer.Add(item);
                }
                else
                {
                    IsBusy = false;
                    return;
                }
            }
            IsBusy = false;
        }
        #endregion


       

        

      

    }
}