using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Dtos
{
    public class AddRetroDto
    {
        public string RName { set; get; }
        public string Summary { set; get; }
        public string Date { set; get; }
        public List<String> PName  { set; get; }
    }
}
