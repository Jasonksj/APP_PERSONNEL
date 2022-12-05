using StaffManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffManagement.DAO
{
    public class MissionDAO
    {
        GestPersonnelEntities staffManag;

        Mission mission;

        public MissionDAO()
        {
            staffManag = new GestPersonnelEntities();
            mission = new Mission();
        }

        public Mission Save(Mission mission)
        {
            try
            {
                this.mission = mission;
                staffManag.Missions.Add(this.mission);
                staffManag.SaveChanges();
                return this.mission;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement impossible de la mission ! '{this.mission.Intitule}'\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idMission)
        {
            try
            {
                this.mission = staffManag.Missions.FirstOrDefault
                    (
                        mission => mission.IdMission == idMission
                    );
                staffManag.Missions.Remove(this.mission);
                staffManag.SaveChanges();
                return this.mission.IdMission;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"suppression impossible de la mission ! '{this.mission.Intitule}'\nErreur : {ex.Message}",
                        "Erreur",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exists(int idMission, int idEmployee, DateTime dateDebut)
        {
            try
            {
                return staffManag.Missions.SingleOrDefault
                (
                    mission => mission.IdMission == idMission &&
                               mission.Contrat.IdEmployee == idEmployee &&
                               mission.Contrat.DateDebutContrat == dateDebut
                ) != null;
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Mission> FindAll()
        {
            try
            {
                return staffManag.Missions.ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Mission> FilterByName(string name)
        {
            try
            {
                return staffManag.Missions.Where
                    (
                        mission => mission.Intitule.IndexOf
                        (
                            name,
                            StringComparison.CurrentCultureIgnoreCase
                        ) != -1
                    ).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public List<Mission> FindByContrat(Contrat contrat)
        {
            try
            {
                return staffManag.Missions.Where
                    (
                        mission => mission.Contrat == contrat
                    ).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"Erreur : {ex.Message}");
            }
        }

        public Mission Update(Mission mission)
        {
            try
            {
                this.mission = mission;
                staffManag.SaveChanges();
                return this.mission;
            }
            catch(Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification impossible de la mission ! '{this.mission.Intitule}'\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
