using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PupilManager.Models;
using System;
using System.Linq;

namespace PupilManager.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Pupils.Any())
                {
                    return;
                }

                context.Pupils.Add(
                     new Pupil
                     {
                         FirstNames = "Jaf",
                         LastName = "Ca",
                         DOB = DateTime.Parse("1970-1-1"),
                         Gender = false,
                         MedicalConditions = null
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
