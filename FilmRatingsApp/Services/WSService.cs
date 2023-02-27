using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using API_Film.Models.EntityFramework;
using FilmRatingsApp.Models;
using Windows.ApplicationModel.UserDataTasks;

namespace FilmRatingsApp.Services;
public class WSService : IService
{
    private readonly HttpClient client = new HttpClient();

    public WSService(string uriString)
    {
        client.BaseAddress = new Uri(uriString);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<bool> DeleteUtilisateurAsync(int id)
    {
        try
        {
            var result = await client.DeleteAsync($"api/Utilisateurs/Delete/{id}");
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<Utilisateur> GetUtilisateurByIdAsync(int id)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>($"/api/utilisateurs/GetById/{id}");
        }
        catch (Exception)
        {
            return null;
            
        }
    }
    public async Task<Utilisateur> GetUtilisateurByEmailAsync(string email)
    {
        try
        {
            return await client.GetFromJsonAsync<Utilisateur>($"/api/utilisateurs/getbyemail/{email}");
        }
        catch (Exception)
        {
            return null;

        }
    }
    public async Task<bool> PostUtilisateurAsync(Utilisateur newUser)
    {
        try
        {
            var result = await client.PostAsJsonAsync("/api/utilisateurs/post/", newUser);
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public async Task<bool> PutUtilisateurAsync(int id, Utilisateur updateUser)
    {
        try
        {
            var result = await client.PutAsJsonAsync($"/api/utilisateurs/put/{id}", updateUser);
            result.EnsureSuccessStatusCode();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
