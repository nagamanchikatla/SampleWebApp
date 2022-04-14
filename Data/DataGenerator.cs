
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApp.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RetroDBContext(
            serviceProvider.GetRequiredService<DbContextOptions<RetroDBContext>>()))
            {
                if ( context.Retros.Any() && context.Feedbacks.Any())
                {
                    return;
                }
                //context.Retros.AddRange(
                //    new Retro
                //    {
                //        Id = 1,
                //        RName = "R001",
                //        PName = { "Naga", "Samala", "Laxmi" },
                //        Summary = "this is summary for this R001",
                //        Date = DateTime.Now,
                //        Fdback = null
                        
                //    },
                //    new Retro
                //    {
                //        Id = 2,
                //        RName = "R002",
                //        PName = { "Naga", "Samala", "Laxmi" },
                //        Summary = "this is summary for this R002",
                //        Date = DateTime.Now.AddDays(1),
                //        Fdback = null
                //    }
                //    );
                //context.Feedbacks.AddRange(                    
                //    new Feedback
                //    {
                //        RName = "R001",
                //        PName = "Naga",
                //        Body = "This is some positive feedback  provided by participant",
                //        Type = "Positive"
                //    },
                //    new Feedback
                //    {
                //        RName = "R001",
                //        PName = "Samala",
                //        Body = "This is some negative feedback provided by participant",
                //        Type = "Negative"
                //    },
                //    new Feedback
                //    {
                //        RName = "R001",
                //        PName = "Laxmi",
                //        Body = "This is some idea provided by participant",
                //        Type = "Idea"
                //    },
                //    new Feedback
                //    {
                //        RName = "R002",
                //        PName = "Naga",
                //        Body = "This is some negative feedback  provided by participant",
                //        Type = "Negative"
                //    },
                //    new Feedback
                //    {
                //        RName = "R002",
                //        PName = "Laxmi",
                //        Body = "This is some praise provided by participant",
                //        Type = "Praise"
                //    }
                //    );
                context.SaveChanges();
            }
        }
    }
}
