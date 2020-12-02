using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cryWeb.Models
{
    public class Post : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int ThreadId { get; set; }

        [ForeignKey("ThreadId")]
        public virtual Thread Thread { get; set; }

        public DateTime Created { get; set; }
    }
}