using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Common.Repository;
using CRUDModal.DataAccess.Context;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.BusinessLogic.Service.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int? id)
        {
            var employee = Get(id);
            employee.Delete();
            db.SaveChanges();
        }

        public IEnumerable<Employee> Get()
        {
            var employee = db.Employees.Where(x => x.IsDelete == false).ToList();
            return employee;
        }

        public Employee Get(int? id)
        {
            if (id == null)
            {
                Console.Write("Id is null");
            }
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                Console.Write("Not found");
            }
            return employee;
        }

        public void Insert(EmployeeParam param)
        {
            var department = db.Departments.Find(Convert.ToInt32(param.Departments));
            var role = db.Roles.Find(Convert.ToInt32(param.Roles));
            var employee = new Employee(param.EmployeeNo, param.FirstName, param.LastName, param.Age, param.Gender, param.Salary, param.Address, param.Email, param.Password, param.Foto, department, role);
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public void Update(int? id, EmployeeParam param)
        {
            var department = db.Departments.Find(Convert.ToInt32(param.Departments));
            var role = db.Roles.Find(Convert.ToInt32(param.Roles));
            var get = Get(id);
            get.Update(param.EmployeeNo, param.FirstName, param.LastName, param.Age, param.Gender, param.Salary, param.Address, param.Email, param.Password, param.Foto, department, role);
            db.SaveChanges();
        }

        //public void Insert(EmployeeParam param)
        //{
        //    var department = db.Departments.Find(Convert.ToInt32(param.Departments));
        //    var role = db.Roles.Find(Convert.ToInt32(param.Roles));
        //    //var employee = new Employee(param.EmployeeNo, param.FirstName, param.LastName, param.Age, param.Gender, param.Salary, param.Address, param.Email, param.Password, param.Foto, department, role);
        //    db.Employees.Add(employee);
        //    db.SaveChanges();
        //}

        //public void Update(int? id, EmployeeParam param)
        //{
        //    var department = db.Departments.Find(Convert.ToInt32(param.Departments));
        //    var role = db.Roles.Find(Convert.ToInt32(param.Roles));
        //    var get = Get(id);
        //    get.Update(param.EmployeeNo, param.FirstName, param.LastName, param.Age, param.Gender, param.Salary, param.Address, param.Email, param.Password, param.Foto, department, role);
        //    db.SaveChanges();
        //}
    }
}
