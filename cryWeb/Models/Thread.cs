using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cryWeb.Models
{
    public class Thread : IEntity
    {
        public Thread()
        {
            Posts = new List<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public DateTime Created { get; set; }
    }
}