using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StaffManagement.Entities;
using static WinFormAnimation.AnimationFunctions;

namespace StaffManagement.DAO
{
    public class FonctionDAO
    {
        GestPersonnelEntities staffManag;

        Fonction fonction;

        public FonctionDAO()
        {
            staffManag = new GestPersonnelEntities();
            fonction = new Fonction();
        }

        public Fonction Save(Fonction fonction)
        {
            try
            {
                this.fonction = fonction;
                staffManag.Fonctions.Add(this.fonction);
                staffManag.SaveChanges();
                return this.fonction;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement de la fonction '{this.fonction.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idFonction)
        {
            try
            {
                this.fonction = staffManag.Fonctions.FirstOrDefault
                (
                    fonction => (fonction.IdFonction == idFonction)
                );
                staffManag.Fonctions.Remove(this.fonction);
                staffManag.SaveChanges();
                return this.fonction.IdFonction;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                        $"Suppression de la fonction impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exist(int idFonction)
        {
            try
            {
                return staffManag.Fonctions.SingleOrDefault
                (
                    fonction => fonction.IdFonction == idFonction
                ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public List<Fonction> FindAll()
        {
            try
            {
                return staffManag.Fonctions.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public List<Fonction> FilterByName(string name)
        {
            try
            {
                List<Fonction> fonctionList = FindAll();
                return fonctionList.Where
                    (
                        fonction => fonction.Nom.IndexOf
                        (
                            name, 
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public Fonction Update(Fonction fonction)
        {
            try
            {
                this.fonction = fonction;
                staffManag.SaveChanges();
                return this.fonction;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification de la fonction '{fonction.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
