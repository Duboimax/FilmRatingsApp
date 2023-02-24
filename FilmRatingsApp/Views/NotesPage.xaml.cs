using FilmRatingsApp.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FilmRatingsApp.Views;

public sealed partial class NotesPage : Page
{
    public NotesViewModel ViewModel
    {
        get;
    }

    public NotesPage()
    {
        ViewModel = App.GetService<NotesViewModel>();
        InitializeComponent();
    }
}
