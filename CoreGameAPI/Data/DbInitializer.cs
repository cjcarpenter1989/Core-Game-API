
using CoreGameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGameAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SandboxContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();

            // Look for any students.
            if (context.SandboxElements.Any())
            {
                return;   // DB has been seeded
            }

            List<SandboxElement> defaultElements = new List<SandboxElement>();

            SandboxElement firstElement = new SandboxElement
            {
                SandboxElementKey = 1,
                SandboxElementStyle = new SandboxElementStyle { Color = "red" }
            };

            SandboxElement secondElement = new SandboxElement
            {
                SandboxElementKey = 2,
                SandboxElementStyle = new SandboxElementStyle { Color = "blue" }
            };

            defaultElements.Add(firstElement);
            defaultElements.Add(secondElement);

            foreach (SandboxElement element in defaultElements)
            {
                context.SandboxElements.Add(element);
            }
            context.SaveChanges();
        }
    }

}
