using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Film.Models.EntityFramework;
using FilmRatingsApp.Models;

namespace FilmRatingsApp.Services;
public interface IService
{
    Task<Utilisateur> GetUtilisateurByIdAsync(int id);
    Task<Utilisateur> GetUtilisateurByEmailAsync(string email);
    Task<bool> PutUtilisateurAsync(int id, Utilisateur updateSerie);
    Task<bool> PostUtilisateurAsync(Utilisateur newSerie);
    Task<bool> DeleteUtilisateurAsync(int id);
}
