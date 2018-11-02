using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Common.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee Get(int? id);
        void Insert(EmployeeParam param);
        void Update(int? id, EmployeeParam param);
        void Delete(int? id);
    }
}
