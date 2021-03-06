﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DTSLocalDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var templateStates = new TemplateState[]
            {
                new TemplateState{State = "Active"},
                new TemplateState{State = "Inactive"}
            };

            foreach (var templateState in templateStates)
            {
                context.TemplateState.Add(templateState);
            }

            var types = new UserType[]
            {
                new UserType{Name = "Admin"},
                new UserType{Name = "Editor"},
                new UserType{Name = "User"}
            };

            foreach (var type in types)
            {
                context.UserType.Add(type);
            }

            context.SaveChanges();

            var statuses = new UserStatus[]
            {
                new UserStatus{Name = "Active"},
                new UserStatus{Name = "Suspended"},
                new UserStatus{Name = "Blocked"}

                
            };

            foreach (var status in statuses)
            {
                context.UserStatus.Add(status);
            }


            var users = new User[]
            {
                new User{Name ="Bartłomiej",Surname ="Żądło",Email ="bZadlo@DTS.com", Login="BZadlo", Password = "$2a$10$jxSg7fZ47f0LmivT5IJ/G.eM4jazTAcAnFwcplp.Qcd6UASc/OkiC", Type = types[1], Status = statuses[0]},
                new User{Name ="Magda",Surname ="Kiebała",Email ="mKiebala@DTS.com", Login="MKiebala", Password = "$2a$10$jxSg7fZ47f0LmivT5IJ/G.eM4jazTAcAnFwcplp.Qcd6UASc/OkiC", Type = types[2], Status = statuses[0]},
                new User{Name ="Piotrek",Surname ="Kamiński",Email ="pKaminski@DTS.com", Login="PKaminski", Password = "$2a$10$jxSg7fZ47f0LmivT5IJ/G.eM4jazTAcAnFwcplp.Qcd6UASc/OkiC", Type = types[0], Status = statuses[0]},

            };
            foreach (var user in users)
            {
                context.User.Add(user);
            }
            context.SaveChanges();
        }
    }
}
