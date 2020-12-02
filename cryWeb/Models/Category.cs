using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace cryWeb.Models
{
    public class Category : IEntity
    {
        public Category()
        {
            Children = new List<Category>();
            Threads = new List<Thread>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Category Parent { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<Category> Children { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}