using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaffManagement.DAO;
using StaffManagement.Entities;

namespace StaffManagement.Services
{
    public class EmployeeService
    {
        public EmployeeDAO employeeDAO { get; set; }
        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
        }

        public Employee Save(Employee employee)
        {
            try
            {
                List<Employee> ExistEmployee = FilterByName(employee.Nom);
                if (ExistEmployee.Count > 0)
                {
                    throw new Exception("Erreur: Cet employé existe deja!");
                }
                else
                {
                    return employeeDAO.Save(employee);
                }
            }catch(Exception e)
            {
                throw new Exception($"Erreur: {e.Message}");
            }
        }

        public Employee Update(Employee employee)
        {
            try
            {
                if (employeeDAO.Exist(employee.Id))
                {
                    return employeeDAO.Update(employee);
                }
                else
                {
                    throw new Exception("Erreur: L'element que vous voulez modifier n'existe pas!");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erreur: {e.Message}");
            }
        }

        public int Delete(int id)
        {
            try
            {
                if (employeeDAO.Exist(id))
                {
                    return employeeDAO.Delete(id);
                }
                else
                {
                    throw new Exception("Erreur: L'element que vous voulez supprimer n'existe pas!");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Erreur: {e.Message}");
            }
        }

        public List<Employee> FindAll()
        {
            return employeeDAO.FindAll();
        }

        public List<Employee> FilterByName(string name)
        {
            return employeeDAO.FilterByName(name);
        }
    }
}
