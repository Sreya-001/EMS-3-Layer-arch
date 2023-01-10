using Capgemini.Ems.BusinessLayer;
using Capgemini.EMS.Entities;
using Capgemini.EMS.Exceptions;
using System;

namespace Capgemini.Ems.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 Add Employee, 2 Employee List, 3 Upadte Employee, 4 Delete Employee, 5 Exit");
            while (true)
            {
                Console.Write("Enter the Choice: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int Choice))
                {
                    Console.WriteLine("Invalid input");
                    return;
                }
                switch (Choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        GetEmployee();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

            }
        }

        //Delete
        private static void DeleteEmployee()
        {
            Employee newEmp = new Employee();
            string input;
            int empid;
            do
            {
                Console.WriteLine("Enter the Id:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empid));
            newEmp.Id = empid;

            //Id- Check 
            var existingEmployee = EmployeeBL.GetById(empid);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }              

            //Delete

            var isDelete = EmployeeBL.Delete(newEmp);
            if (isDelete)
            {
                Console.WriteLine("Employee Deleted Succesfully");
            }
            else
            {
                Console.WriteLine("Employee Delete Failed");
            }


        }

        //Update
        private static void UpdateEmployee()
        {
            // Id
            string input;
            int empId;
            do
            {
                Console.WriteLine("Enter Employee Id:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empId));

            //Id- Check 
            var existingEmployee = EmployeeBL.GetById(empId);
            if (existingEmployee == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            //Name/Doj
            Employee newemp = new Employee();
            newemp.Id = empId;
            do
            {
                Console.WriteLine("Enter Employee Name:");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            newemp.Name = input;

            DateTime dateofjoining;
            do
            {
                Console.WriteLine("Enter DateOfJoining:");
                input = Console.ReadLine();

            } while (!DateTime.TryParse(input, out dateofjoining));
            newemp.DateofJoining = dateofjoining;

            //Update

            var isUpdate = EmployeeBL.Update(newemp);
            if (isUpdate)
            {
                Console.WriteLine("Employee Updated Succesfully");
            }
            else
            {
                Console.WriteLine("Employee Update Failed");
            }


        }

        //GetList
        private static void GetEmployee()
        {
            //Call BL
            var list = EmployeeBL.GetList();

            Console.WriteLine("Employee List:");
            foreach (Employee emp in list)
            {
                Console.WriteLine(emp);
            }
        }

        //AddEmployee
        private static void AddEmployee()
        {
            Employee employee = new Employee();
            string input;
            int empId;

            do
            {
                Console.WriteLine("Enter Employee Id:");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out empId));
            employee.Id = empId;
            do
            {
                Console.WriteLine("Enter Employee Name:");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            employee.Name = input;

            DateTime dateofjoining;
            do
            {
                Console.WriteLine("Enter DateOfJoining:");
                input = Console.ReadLine();

            } while (!DateTime.TryParse(input, out dateofjoining));
            employee.DateofJoining = dateofjoining;

            //Call BL
            try
            {
                bool Added = EmployeeBL.Add(employee);
                if (Added)
                {
                    Console.WriteLine("Employee Add Successfully");
                }
                else
                {
                    Console.WriteLine("Employee failed to add");
                }
            }
            catch (EmsException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
