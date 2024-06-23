using Tito_Store.models;
using Tito_Store.viewModels;

namespace Tito_Store.View;

public partial class outerMony : ContentPage
{
	public outerMony()
	{
		InitializeComponent();
	}

    private void OnItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedItem = e.CurrentSelection[0] as OuterMonyModels;
            if (selectedItem != null)
            {
                var viewModel = BindingContext as MonyViewModels;
                if (viewModel != null)
                {
                    viewModel.EditOuter(selectedItem);
                }
            }
        }
    }
}