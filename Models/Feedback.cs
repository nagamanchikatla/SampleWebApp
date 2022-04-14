using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Models
{
    public class Feedback 
    {
        public int Id { set; get; }
        public string PName { set; get; }
        public string RName { set; get; }
        public string Body { set; get;  }
        public string Type { set; get;  }
    }
}
