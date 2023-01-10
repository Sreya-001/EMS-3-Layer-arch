﻿using Capgemini.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Capgemini.EMS.DAL
{
    public class EmployeeDAL
    {
        static List<Employee> list = new List<Employee>();

        public static bool Add(Employee emp)
        {
            list.Add(emp);
            return true;
        }

        public static List<Employee> GetList()
        {
            return list;
        }

        public static Employee GetById(int id)
        {
            //linq
            var emp = list.Where(e => e.Id == id).FirstOrDefault();
            return emp;
        }
        public static bool Update(Employee emp)
        {
            var existingemp = list.Where(e => e.Id == emp.Id).FirstOrDefault();

            //update
            existingemp.Name = emp.Name;
            existingemp.DateofJoining = emp.DateofJoining;
            return true;
        }

        public static bool Delete(Employee emp)
        {
            var delete = list.Where(e => e.Id == emp.Id).FirstOrDefault();
            list.Remove(delete);
            return true;
        }
    }
}
