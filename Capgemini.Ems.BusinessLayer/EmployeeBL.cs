using System;
using System.Collections.Generic;
using Capgemini.EMS.DAL;
using Capgemini.EMS.Entities;
namespace Capgemini.Ems.BusinessLayer
{
    public class EmployeeBL
    {
        public static bool Add(Employee emp )
        {
            //Validation
            if(emp.Id<=0)
            {
                Console.WriteLine("Employee id should be greater than zero");
            }

            //call DAL method
            var isAdded = EmployeeDAL.Add(emp);
            return isAdded;
        }

        public static List<Employee> GetList()
        {
            //Call DAL
           var list =  EmployeeDAL.GetList();
            return list;
        }

        public static Employee GetById(int id)
        {
            var emp = EmployeeDAL.GetById(id);
            return emp;
        }

        public static bool Update(Employee emp)
        {
            var isUpdated = EmployeeDAL.Update(emp);
            return isUpdated;
        }

        public static bool Delete(Employee emp)
        {
            var isDelete = EmployeeDAL.Delete(emp);
            return isDelete;
        }

    }
}
