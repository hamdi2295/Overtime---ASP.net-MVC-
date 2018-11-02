using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Core;

namespace CRUDModal.DataAccess.Models
{
    public class Department : BaseModel
    {
        public string Name { get; set; }

        public Department() { }

        public Department(string name)
        {
            this.Name = name;
            this.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Update(string name)
        {
            this.Name = name;
            this.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Delete()
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
    }
}
