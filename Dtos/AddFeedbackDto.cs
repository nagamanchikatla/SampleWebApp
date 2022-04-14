using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Dtos
{
    public class AddFeedbackDto
    {
        public string RName { get; set; }
        public string PName { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
    }
}
