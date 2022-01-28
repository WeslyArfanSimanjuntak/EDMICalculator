using EDMICalculator.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EDMICalculator.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}