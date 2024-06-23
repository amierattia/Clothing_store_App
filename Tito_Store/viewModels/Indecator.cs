using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tito_Store.viewModels
{
    public partial class Indecator : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
    }
}
