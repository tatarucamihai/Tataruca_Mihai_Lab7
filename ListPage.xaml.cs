using Tataruca_Mihai_Lab7.Models;
namespace Tataruca_Mihai_Lab7;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var product = (Product)listView.SelectedItem; // Assuming listView is your ListView
        if (product != null)
        {
            var shopList = (ShopList)BindingContext;

            // Assuming you have a method in App.Database to delete a product from a specific list
            await App.Database.DeleteProductAsync(product);

            // Refresh the list view
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
        }
        else
        {
            await DisplayAlert("Error", "Please select a product to delete", "OK");
        }
    }



}