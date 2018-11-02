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
    public class DataOvertimeRepository : IDataOvertimeRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int? id)
        {
            var ot = Get(id);
            ot.Delete();
            db.SaveChanges();
        }

        public IEnumerable<DataOvertime> Get()
        {
            var ot = db.DataOvertimes.Where(x => x.IsDelete == false).ToList();
            return ot;
        }

        public DataOvertime Get(int? id)
        {
            if (id == null)
            {
                Console.Write("Id is null");
            }
            var ot = db.DataOvertimes.Find(id);
            if (ot == null)
            {
                Console.Write("Id is not found");
            }
            return ot;
        }

        public void Insert(DataOvertimeParam param)
        {
            var employee = db.Employees.Find(Convert.ToInt32(param.Employees));
            var type = db.OverTimeTypes.Find(Convert.ToInt32(param.OvertimeTypes));
            var ot = new DataOvertime(param.Date, param.Status, param.Price, employee, type);
            db.DataOvertimes.Add(ot);
            db.SaveChanges();
        }

        public void Update(int? id, DataOvertimeParam param)
        {
            var employee = db.Employees.Find(Convert.ToInt32(param.Employees));
            var type = db.OverTimeTypes.Find(Convert.ToInt32(param.OvertimeTypes));
            var ot = Get(id);
            ot.Update(param.Date, param.Status, param.Price, employee, type);
            db.SaveChanges();
        }
    }
}
