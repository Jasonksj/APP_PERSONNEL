using Microsoft.Identity.Client;
using StaffManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffManagement.DAO
{
    public class UtilisateurDAO
    {
        GestPersonnelEntities staffManag;

        Utilisateur utilisateur;

        public UtilisateurDAO()
            {
            staffManag = new GestPersonnelEntities();
            utilisateur= new Utilisateur();
            }

        public Utilisateur Save(Utilisateur utilisateur)
        {
            try
            {
                this.utilisateur = utilisateur;
                staffManag.Utilisateurs.Add(this.utilisateur);
                staffManag.SaveChanges();
                return this.utilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                   (
                       $"Enregistrement impossible de la mission ! '{this.utilisateur.NomUtilisateur}'\nErreur : {ex.Message}",
                       "Echec",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error
                   );
                return null;
            }
            
        }
        public int Delete (int IdUtilisateur)
        {
            try
            {
                this.utilisateur = staffManag.Utilisateurs.FirstOrDefault
                    (
                        utilisateur => utilisateur.IdUtilisateur == IdUtilisateur
                    );
                staffManag.Utilisateurs.Remove(this.utilisateur);
                staffManag.SaveChanges();
                return this.utilisateur.IdUtilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"suppression impossible de la mission ! '{this.utilisateur.NomUtilisateur}'\nErreur : {ex.Message}",
                        "Erreur",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }
        public bool Exists(int IdUtilisateur)
        {
            try
            {
                return staffManag.Utilisateurs.SingleOrDefault
                (
                    utilisateur => utilisateur.IdUtilisateur == IdUtilisateur 
                        
                ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }
        public List<Utilisateur> FindAll()
        {
            try
            {
                return staffManag.Utilisateurs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Utilisateur> FilterByName(string name)
        {
            try
            {
                return staffManag.Utilisateurs.Where
                    (
                        utilisateur => utilisateur.NomUtilisateur.IndexOf
                        (
                            name,
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Utilisateur> FindByUtilisateur(Employee employee)
        {
            try
            {
                return staffManag.Utilisateurs.Where
                    (
                        utilisateur => utilisateur.Employee == employee
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Utilisateur Update(Utilisateur utilisateur)
        {
            try
            {
                this.utilisateur = utilisateur;
                staffManag.SaveChanges();
                return this.utilisateur;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la mission ! '{this.utilisateur.NomUtilisateur}'\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

    }
}
