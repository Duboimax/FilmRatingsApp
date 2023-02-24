using CommunityToolkit.Mvvm.ComponentModel;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableRecipient
{
    private Utilisateur userSearch;
    public Utilisateur UserSearch
    {
        get
        {
            return userSearch;
        }
        set
        {
            userSearch = value;
        }
    }
    public UtilisateurViewModel()
    {
    }

}
