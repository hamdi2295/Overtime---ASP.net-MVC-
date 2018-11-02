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
    public class DepartmentRepository : IDepartmentRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int? id)
        {
            var dep = Get(id);
            dep.Delete();
            db.SaveChanges();    
        }

        public IEnumerable<Department> Get()
        {
            var dep = db.Departments.Where(x => x.IsDelete == false).ToList();
            return dep;
        }

        public Department Get(int? id)
        {
            if (id == null)
            {
                Console.Write("Id is null");
            }
            var department = db.Departments.Find(id);
            if (department == null)
            {
                Console.Write("Not found");
            }
            return department;
        }

        public void Insert(DepartmentParam param)
        {
            var department = new Department(param.Name);
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void Update(int? id, DepartmentParam param)
        {
            var department = Get(id);
            department.Update(param.Name);
            db.SaveChanges();
        }

        
    }
}
