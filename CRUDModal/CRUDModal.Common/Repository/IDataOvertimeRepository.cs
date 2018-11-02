using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.DataAccess.Models;
using CRUDModal.DataAccess.Params;

namespace CRUDModal.Common.Repository
{
    public interface IDataOvertimeRepository
    {
        IEnumerable<DataOvertime> Get();
        DataOvertime Get(int? id);
        void Insert(DataOvertimeParam param);
        void Update(int? id, DataOvertimeParam param);
        void Delete(int? id);
    }
}
