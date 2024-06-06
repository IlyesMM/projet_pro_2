using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace projet_pro_2.Models

{
    public class Personnel
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        [Phone]
        public string Tel { get; set; }

        [Required]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public string Service { get; set; }
    }
}
