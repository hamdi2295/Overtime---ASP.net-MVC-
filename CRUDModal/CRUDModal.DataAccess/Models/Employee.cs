using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Core;

namespace CRUDModal.DataAccess.Models
{
    public class Employee : BaseModel
    {
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
        public virtual Department Departments { get; set; }
        public virtual Role Roles { get; set; }

        public Employee() { }

        public Employee(int employeeno, string firstname, string lastname, int age, string gender, int salary, string address, string email, string password, string foto, Department departments, Role roles)
        {
            this.EmployeeNo = employeeno;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
            this.Gender = gender;
            this.Salary = salary;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Foto = foto;
            this.Departments = departments;
            this.Roles = roles;
            this.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Update(int employeeno, string firstname, string lastname, int age, string gender, int salary, string address, string email, string password, string foto, Department departments, Role roles)
        {
            this.EmployeeNo = employeeno;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Age = age;
            this.Gender = gender;
            this.Salary = salary;
            this.Address = address;
            this.Email = email;
            this.Password = password;
            this.Foto = foto;
            this.Departments = departments;
            this.Roles = roles;
            this.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
    }
}
