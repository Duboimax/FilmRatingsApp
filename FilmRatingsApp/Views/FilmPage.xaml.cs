using FilmRatingsApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.Views;

public sealed partial class FilmPage : Page
{
    public FilmViewModel ViewModel
    {
        get;
    }

    public FilmPage()
    {
        ViewModel = App.GetService<FilmViewModel>();
        InitializeComponent();
    }
}
