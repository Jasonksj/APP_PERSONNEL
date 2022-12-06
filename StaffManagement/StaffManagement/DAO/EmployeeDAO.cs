using StaffManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffManagement.DAO
{
    public class EmployeeDAO
    {
        GestPersonnelEntities staffManag;

        Employee mainEmployee;

        public EmployeeDAO()
        {
            staffManag = new GestPersonnelEntities();
            mainEmployee = new Employee();
        }

        public Employee Save(Employee employee)
        {
            try
            {
                mainEmployee = employee;
                staffManag.Employees.Add(mainEmployee);
                staffManag.SaveChanges();
                return mainEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Enregistrement d'un employé '{employee.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }

        public int Delete(int idEmployee)
        {
            try
            {
                mainEmployee = staffManag.Employees.FirstOrDefault
                (
                    fonction => (fonction.Id == idEmployee)
                );
                staffManag.Employees.Remove(mainEmployee);
                staffManag.SaveChanges();
                return mainEmployee.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                (
                        $"Suppression d'un employé impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return -1;
            }
        }

        public bool Exist(int idEmployee)
        {
            try
            {
                return staffManag.Employees.FirstOrDefault
                (
                    fonction => fonction.Id == idEmployee
                ) != null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public List<Employee> FindAll()
        {
            try
            {
                return staffManag.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public List<Employee> FilterByName(string name)
        {
            try
            {
                List<Employee> employeeList = FindAll();
                return employeeList.Where
                    (
                        employee => employee.Nom.IndexOf(name, StringComparison.CurrentCultureIgnoreCase) != -1
                    ).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erreur {ex.Message}");
            }
        }

        public Employee Update(Employee employee)
        {
            try
            {
                mainEmployee = employee;
                staffManag.SaveChanges();
                return mainEmployee;
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (
                        $"Modification de la fonction '{employee.Nom}' impossible !\nErreur : {ex.Message}",
                        "Echec",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                return null;
            }
        }
    }
}
