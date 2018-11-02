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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Delete(int? id)
        {
            _employeeRepository.Delete(id);
        }

        public IEnumerable<Employee> Get()
        {
            var employee = _employeeRepository.Get();
            return employee;
        }

        public Employee Get(int? id)
        {
            var employee = _employeeRepository.Get(id);
            return employee;
        }

        public void Insert(EmployeeParam param)
        {
            _employeeRepository.Insert(param);
        }

        public void Update(int? id, EmployeeParam param)
        {
            _employeeRepository.Update(id, param);
        }
    }
}
