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
    public class DataOvertimeService : IDataOvertimeService
    {
        private readonly IDataOvertimeRepository _dataovertimeRepository;
        public DataOvertimeService(IDataOvertimeRepository dataot)
        {
            _dataovertimeRepository = dataot;
        }

        public void Delete(int? id)
        {
            _dataovertimeRepository.Delete(id);
        }

        public IEnumerable<DataOvertime> Get()
        {
            var ot = _dataovertimeRepository.Get();
            return ot;
        }

        public DataOvertime Get(int? id)
        {
            var ot = _dataovertimeRepository.Get(id);
            return ot;
        }

        public void Insert(DataOvertimeParam param)
        {
            _dataovertimeRepository.Insert(param);
        }

        public void Update(int? id, DataOvertimeParam param)
        {
            _dataovertimeRepository.Update(id, param);
        }
    }
}
