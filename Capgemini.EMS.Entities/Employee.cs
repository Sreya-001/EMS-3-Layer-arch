using System;

namespace Capgemini.EMS.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateofJoining { get; set; }

        public override string ToString()
        {
            return $"Employee Id: {Id}, Employee Name: {Name}, DateofJoining: {DateofJoining}";
        }
    }
}
