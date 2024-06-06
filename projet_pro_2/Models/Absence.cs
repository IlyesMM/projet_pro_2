using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace projet_pro_2.Models
{
    public class Absence
    {
        public int Id { get; set; }

        [Required]
        public int PersonnelId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateFin { get; set; }

        [Required]
        public string Motif { get; set; }
    }
}