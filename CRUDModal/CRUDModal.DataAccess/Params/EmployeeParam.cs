using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;
using System.Web;
using System.Collections.Generic;

namespace CRUDModal.DataAccess.Params
{
    
    public class EmployeeParam
    {
        public int Id { get; set; }
        public int EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Foto { get; set; }
        
        public string Departments { get; set; }
        public string Roles { get; set; }
       
        public EmployeeParam() { }

        public EmployeeParam(Employee emp)
        {
            Id = emp.Id;
            EmployeeNo = emp.EmployeeNo;
            FirstName = emp.FirstName;
            LastName = emp.LastName;
            Age = emp.Age;
            Gender = emp.Gender;
            Salary = emp.Salary;
            Address = emp.Address;
            Email = emp.Email;
            Password = emp.Password;
            Foto = emp.Foto;
            Departments = emp.Departments.ToString();
            Roles = emp.Roles.ToString();
        }
       
    }
}
