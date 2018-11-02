using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;

namespace CRUDModal.DataAccess.Params
{
    public class DataOvertimeParam
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string Employees { get; set; }
        public string OvertimeTypes { get; set; }

        public DataOvertimeParam() { }

        public DataOvertimeParam(DataOvertime ot)
        {
            Id = ot.Id;
            Date = ot.Date;
            Status = ot.Status;
            Price = ot.Price;
            Employees = ot.Employees.ToString();
            OvertimeTypes = ot.OvertimeTypes.ToString();
        }
    }
}
