using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Models
{
    public class Retro
    {
        public int Id { set; get; }
        public string RName { set; get; }
        public string Summary { set; get; }
        public string Date { set; get; }
        public List<string> PName { set; get; }
        public List<Feedback> Fdback { set; get; }

    }
}
