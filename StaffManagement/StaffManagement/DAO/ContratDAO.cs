using StaffManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaffManagement.DAO
{
    public class ContratDAO
    {
        GestPersonnelEntities staffManag;

        Contrat contrat;

        public ContratDAO()
        {
            staffManag = new GestPersonnelEntities();
            contrat = new Contrat();
        }

        public Contrat Save(Contrat contrat)
        {
            try
            {
                this.contrat = contrat;
                staffManag.Contrats.Add(this.contrat);
                return this.contrat;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement du contrat '{contrat.Titre}' impossible\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }

        public bool Exists(int idEmploye, DateTime dateDebut)
        {
            try
            {
                return staffManag.Contrats.SingleOrDefault
                (
                    contrat => contrat.IdEmployee == idEmploye &&
                               contrat.DateDebutContrat == dateDebut
                ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Contrat> FindAll()
        {
            try
            {
                return staffManag.Contrats.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Contrat Update(Contrat contrat)
        {
            try
            {
                this.contrat = contrat;
                staffManag.SaveChanges();
                return this.contrat;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification du contrat '{this.contrat.Titre}' impossible\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                return null;
            }
        }
    }
}
