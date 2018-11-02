using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Core;

namespace CRUDModal.DataAccess.Models
{
    public class DataOvertime : BaseModel
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual OvertimeType OvertimeTypes { get; set; }

        public DataOvertime() { }

        public DataOvertime(DateTime date, string status, int price, Employee employees, OvertimeType types)
        {
            this.Date = date;
            this.Status = status;
            this.Price = price;
            this.Employees = employees;
            this.OvertimeTypes = types;
            this.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Update(DateTime date, string status, int price, Employee employees, OvertimeType types)
        {
            this.Date = date;
            this.Status = status;
            this.Price = price;
            this.Employees = employees;
            this.OvertimeTypes = types;
            this.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
        public virtual void Delete()
        {
            IsDelete = true;
            DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
        }
    }
}
