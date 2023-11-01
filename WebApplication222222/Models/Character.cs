using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication222222.Models
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Rerun { get; set; } 
        public int? ElementID { get; set; }
        public virtual Element Element { get; set; }
    }
}