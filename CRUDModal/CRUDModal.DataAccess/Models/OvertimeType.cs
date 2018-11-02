using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDModal.Core;

namespace CRUDModal.DataAccess.Models
{
    public class OvertimeType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Hours { get; set; }
        public int Amount { get; set; }
    }
}
