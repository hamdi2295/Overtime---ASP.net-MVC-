using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Common.Repository
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> Get();
        Department Get(int? id);
        void Insert(DepartmentParam param);
        void Update(int? id, DepartmentParam param);
        void Delete(int? id);
    }
}
