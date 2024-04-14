using Microsoft.Extensions.DependencyInjection;
using Quartz.Abstraction.Attribute;
using Quartz.Abstraction.Interfaces;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.Abstraction.Configuration
{
    public static class JobAbstractService
    {

        public static void JobRunnerConfiguration(this IServiceCollection services, Assembly assembly)
        {

            var types = assembly.GetTypes()
                .Where(type => type.GetCustomAttribute<JobSchedulerAttribute>() != null);

            foreach (var type in types)
            {
                Start(type);
            }

        }

        private static void Start(Type type)
        {
            var _scheduler = new StdSchedulerFactory().GetScheduler().Result;
            _scheduler.Start().Wait();


            var attribute = type.GetCustomAttribute<JobSchedulerAttribute>();
            if (attribute != null && typeof(IJobBase).IsAssignableFrom(type))
            {
                var jobName = attribute.JobName;
                var cronExpression = attribute.Schedule;

                // Define the job
                var jobDetail = JobBuilder.Create()
                            .OfType(type)
                            .WithIdentity(jobName)
                            .Build();

                // Define the trigger
                var trigger = TriggerBuilder.Create()
                    .WithIdentity($"{jobName}_trigger")
                    .WithCronSchedule(cronExpression)
                    .Build();

                _scheduler.ScheduleJob(jobDetail, trigger).Wait();

            }
        }

    }
}
