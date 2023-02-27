using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.X86;
using FilmRatingsApp.Models;

namespace API_Film.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        public Utilisateur()
        {
        }

        public Utilisateur(string? nom, string? prenom, string? mobile, string mail, string pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude)
        {
            Nom = nom;
            Prenom = prenom;
            Mobile = mobile;
            Mail = mail;
            Pwd = pwd;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Utilisateur(int utilisateurId, string? nom, string? prenom, string? mobile, string mail, string pwd, string? rue, string? codePostal, string? ville, string? pays, float? latitude, float? longitude)
        {
            UtilisateurId = utilisateurId;
            Nom = nom;
            Prenom = prenom;
            Mobile = mobile;
            Mail = mail;
            Pwd = pwd;
            Rue = rue;
            CodePostal = codePostal;
            Ville = ville;
            Pays = pays;
            Latitude = latitude;
            Longitude = longitude;
        }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId
        {
            get; set;
        }

        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom
        {
            get; set;
        }

        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom
        {
            get; set;
        }

        [Column("utl_mobile", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "Le mobile doit contenir 10 chiffres")]
        public string? Mobile
        {
            get; set;
        }

        [Required]
        [Column("utl_mail")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string Mail
        {
            get; set;
        }

        [Column("utl_pwd")]
        [RegularExpression(@"^(?=.\d)(?=.[A-Z])(?=.[!@#$%^&()_+=[]{}|\,./?]).{12,20}$", ErrorMessage = "Le mot de passe doit contenir entre 12 et 20 caractères avec au moins 1 lettre majuscule, 1 chiffre et 1 caractère spécial")]
        [StringLength(64)]
        public string Pwd
        {
            get; set;
        }

        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue
        {
            get; set;
        }

        [Column("utl_cp", TypeName = "char(5)")]
        [RegularExpression(@"^[0-9]{5}$", ErrorMessage = "Le code postal doit contenir 5 chiffres")]
        public string? CodePostal
        {
            get; set;
        }

        [Column("utl_ville")]
        [StringLength(50)]
        public string? Ville
        {
            get; set;
        }

        [Column("utl_pays")]
        [StringLength(50)]
        public string? Pays { get; set; } = "France";

        [Column("utl_latitude")]
        public float? Latitude
        {
            get; set;
        }

        [Column("utl_longitude")]
        public float? Longitude
        {
            get; set;
        }

        [Column("utl_datecreation", TypeName = "date")]
        public DateTime Datecreation { get; set; } = DateTime.Now;

        [InverseProperty("UtilisateurNotant")]
        public ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();

        public override bool Equals(object? obj) => obj is Utilisateur utilisateur && UtilisateurId == utilisateur.UtilisateurId && Nom == utilisateur.Nom && Prenom == utilisateur.Prenom && Mobile == utilisateur.Mobile && Mail == utilisateur.Mail && Pwd == utilisateur.Pwd && Rue == utilisateur.Rue && CodePostal == utilisateur.CodePostal && Ville == utilisateur.Ville && Pays == utilisateur.Pays && Latitude == utilisateur.Latitude && Longitude == utilisateur.Longitude && Datecreation == utilisateur.Datecreation && EqualityComparer<ICollection<Notation>>.Default.Equals(NotesUtilisateur, utilisateur.NotesUtilisateur);

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(UtilisateurId);
            hash.Add(Nom);
            hash.Add(Prenom);
            hash.Add(Mobile);
            hash.Add(Mail);
            hash.Add(Pwd);
            hash.Add(Rue);
            hash.Add(CodePostal);
            hash.Add(Ville);
            hash.Add(Pays);
            hash.Add(Latitude);
            hash.Add(Longitude);
            hash.Add(Datecreation);
            hash.Add(NotesUtilisateur);
            return hash.ToHashCode();
        }
    }

}
