using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Abstraction.Attribute
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class JobSchedulerAttribute : System.Attribute
    {
        public string JobName { get; set; }
        public string Schedule { get; set; }
        public JobSchedulerAttribute(string jobName, string schedule)
        {
            JobName = jobName;

            Schedule = schedule;

        }
    }
}
