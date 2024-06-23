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
    public partial class MonyViewModels : ObservableObject
    {
        [ObservableProperty]
        string? clientName;

        [ObservableProperty]
        string? productName;

        [ObservableProperty]
        decimal? outerPrice;

        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        string? clientNameSearch;

        [ObservableProperty]
        private ObservableCollection<OuterMonyModels> outer;

        [ObservableProperty]
        private ObservableCollection<OuterMonyModels> name;

        private OuterMonyModels selectedOuter;

        #region EventsOfouterMony

        [RelayCommand]
        void AddOuter()
        {


            // Add new item
            outerMonyModelsEntity OouterMonyModelsEntity = new outerMonyModelsEntity();
            OuterMonyModels oOuterMonyModels = new OuterMonyModels
            {
                ClientName = ClientName,
                ProductName = ProductName,
                outerPrice = OuterPrice,
                Date = DateTime.Now
            };
            OouterMonyModelsEntity.Add(oOuterMonyModels);


            GetOuter();
            ClearForm();
        }

        [RelayCommand]
        async void GetOuter()
        {
            var db = new outerMonyModelsEntity();
            IsBusy = true;

            var result = await Task.Run(() => db.GetAll());
            Outer = new ObservableCollection<OuterMonyModels>(result);

            IsBusy = false;
        }


        [RelayCommand]
        void UpdateData()
        {
            if (selectedOuter != null)
            {
                // Update existing item
                selectedOuter.ClientName = ClientName;
                selectedOuter.ProductName = ProductName;
                selectedOuter.outerPrice = OuterPrice;
                selectedOuter.Date = DateTime.Now;

                var db = new outerMonyModelsEntity();
                db.Update(selectedOuter);
                GetOuter();
            }
        }

        #endregion

        [RelayCommand]
        private void Search()
        {
            IsBusy = true;
            Name = new ObservableCollection<OuterMonyModels>();
            if (!string.IsNullOrWhiteSpace(ClientNameSearch))
            {
                var db = new outerMonyModelsEntity();
                var results = db.SearchByClientName(ClientNameSearch);
                Name.Clear();
                foreach (var item in results)
                {
                    Name.Add(item);
                }
            }
            IsBusy = false;
        }

        public void EditOuter(OuterMonyModels item)
        {
            selectedOuter = item;

            ClientName = item.ClientName;
            ProductName = item.ProductName;
            OuterPrice = item.outerPrice;
        }

        private void ClearForm()
        {
            selectedOuter = null;
            ClientName = "";
            ProductName = "";
            OuterPrice = null;
        }
    }
}
