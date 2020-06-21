using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WNS_DEMOPROJECT.Models
{
    public class PatientData
    {
        public int id { get; set; }
        public string assumptions { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        public decimal data { get; set; }

        public int year { get; set; }
    }
}
