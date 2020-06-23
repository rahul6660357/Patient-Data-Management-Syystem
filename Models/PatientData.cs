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
        [Required]
        [StringLength(100)]
        public string assumptions { get; set; }
       
        [DataType(DataType.Currency)]
        [Required]
        public decimal data { get; set; }
        [Required]
       
        public int year { get; set; }
    }
}
