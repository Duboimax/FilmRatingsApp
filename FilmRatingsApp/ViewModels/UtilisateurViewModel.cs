using API_Film.Models.EntityFramework;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FilmRatingsApp.Models;
using FilmRatingsApp.Services;
using Microsoft.UI.Xaml.Controls;
using Windows.Networking.NetworkOperators;

namespace FilmRatingsApp.ViewModels;

public class UtilisateurViewModel : ObservableObject
{
    private Utilisateur utilisateurSearch;
    public Utilisateur UtilisateurSearch
    {
        get => utilisateurSearch;
        set
        {
            utilisateurSearch = value;
            OnPropertyChanged();
        }
    }

    private string searchMail;
    public string SearchMail
    {
        get => searchMail;
        set
        {
            searchMail = value;
        }
    }
    public IRelayCommand BtnAddUtilisateurCommand
    {
        get;
    }
    public IRelayCommand BtnSearchUtilisateurCommand
    {
        get;
    }

    public IRelayCommand BtnModifyUtilisateurCommand
    {
        get;    
    }

    public IRelayCommand BtnClearUtilisateurCommand
    {
        get;
    }
    public UtilisateurViewModel()
    {
        UtilisateurSearch = new Utilisateur();
        BtnSearchUtilisateurCommand = new RelayCommand(ActionSearcheEmail);
        BtnAddUtilisateurCommand = new RelayCommand(ActionAddUtilisateur);
        BtnModifyUtilisateurCommand = new RelayCommand(ActionSavesChanged);
        BtnClearUtilisateurCommand = new RelayCommand(ActionClear);
    }

    private void ActionClear()
    {
        UtilisateurSearch = null;
    }
    private async void ActionSavesChanged()
    {
        WSService service = new WSService("https://localhost:7226/");
        bool result = await service.PutUtilisateurAsync(UtilisateurSearch.UtilisateurId, UtilisateurSearch);
        if (!result)
            MessageAsync("Erreur dans les modifications", "Erreur");
        else
            MessageAsync("Modifications validées", "Erreur");
    }
    private async void ActionAddUtilisateur()
    {
        WSService service = new WSService("https://localhost:7226/");
        if (UtilisateurSearch == null)
            MessageAsync("Il manque des champs dans le formulaire", "Erreur");

        bool result = await service.PostUtilisateurAsync(UtilisateurSearch);

        if (result)
            MessageAsync("Utilisateur ajouté", "Valide");
        else
            MessageAsync("Utilisateur n'a pas pu être ajouter", "Erreur");
        
    }

    private async void ActionSearcheEmail()
    {
        WSService service = new WSService("https://localhost:7226/");

        if (SearchMail == null)
            MessageAsync("Veuillez entrez un numéro de serie", "Erreur");
        Utilisateur utilisateur = await service.GetUtilisateurByEmailAsync(SearchMail);
        UtilisateurSearch = utilisateur;
    }

    private async void MessageAsync(string content, string title)
    {
        ContentDialog noWifiDialog = new ContentDialog
        {
            Title = title,
            Content = content,
            CloseButtonText = "Ok"
        };
        noWifiDialog.XamlRoot = App.MainRoot.XamlRoot;
        ContentDialogResult result = await noWifiDialog.ShowAsync();
    }

}
