using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;

namespace CRUDModal.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Koneksi") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DataOvertime> DataOvertimes { get; set; }
        public DbSet<OvertimeType> OverTimeTypes { get; set; }

        public System.Data.Entity.DbSet<CRUDModal.DataAccess.Params.DepartmentParam> DepartmentParams { get; set; }
    }
}
