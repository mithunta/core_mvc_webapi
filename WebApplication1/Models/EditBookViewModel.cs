using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EditBookViewModel
    {
        public Books Books { get; set; }
        public List<Categories> Categories { get; set; }
    }
}
