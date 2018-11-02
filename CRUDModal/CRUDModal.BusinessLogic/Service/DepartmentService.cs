using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Common.Repository;
using CRUDModal.Common.Service;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.BusinessLogic.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void Delete(int? id)
        {
            _departmentRepository.Delete(id);
        }

        public IEnumerable<Department> Get()
        {
            var department = _departmentRepository.Get();
            return department;
        }

        public Department Get(int? id)
        {
            var department = _departmentRepository.Get(id);
            return department;
        }

        public void Insert(DepartmentParam param)
        {
            _departmentRepository.Insert(param);
        }

        public void Update(int? id, DepartmentParam param)
        {
            _departmentRepository.Update(id, param);
        }
    }
}
