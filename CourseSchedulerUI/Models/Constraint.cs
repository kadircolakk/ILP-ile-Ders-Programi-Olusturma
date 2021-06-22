using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSchedulerUI.Models
{
    class Constraint
    {
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Teacher { get; set; }
        public string Course { get; set; }
    }
}
