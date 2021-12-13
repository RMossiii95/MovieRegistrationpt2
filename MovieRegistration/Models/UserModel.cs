using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistration.Models
{
    public class UserModel
    {
        
        [Required]
        [Key]
        public string ID { get; set; }
        
        [MaxLength(30)]
        public string Title { get; set; }
        public string Genre { get; set; }
        
        [Range(1880, 2021)]
        public int Year { get; set; }
        //public string Actors { get; set; }
        //public string Directors { get; set; }
        public int RunTime { get; set; }
    }
}
