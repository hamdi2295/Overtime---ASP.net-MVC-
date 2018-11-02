using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;

namespace CRUDModal.DataAccess.Params
{
    public class DepartmentParam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DepartmentParam() { }

        public DepartmentParam(Department dep )
        {
            Id = dep.Id;
            Name = dep.Name;
        }
    }
}
