using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using cryWeb.Models;

namespace cryWeb.ViewModels
{
    public class CreateThreadVM
    {
        public CreateThreadVM()
        {
            this.Thread = new Thread();
            this.Post = new Post();
        }

        public Thread Thread { get; set; }
        public Post Post { get; set; }
    }
}