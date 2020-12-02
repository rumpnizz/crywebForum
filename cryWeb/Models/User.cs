using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cryWeb.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Hash { get; set; }
        
        [Required]
        public string Salt { get; set; }
        
        [Required]
        public DateTime Created { get; set; }
    }
}