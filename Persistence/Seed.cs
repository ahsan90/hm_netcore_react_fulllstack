using System;
using System.Text.Json;
using Bogus;
using Domain;

namespace Persistence
{
    public static class Seed
    {
        public static void DbSeed(DataContext context)
        {
            var docotorsSeed = new Faker<Doctor>()
                .RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, x => "Dr. " + x.Person.FullName)
                .RuleFor(x => x.Gender, x => x.Person.Gender.ToString())
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.PhoneNumber, x => x.Person.Phone)
                .RuleFor(x => x.Address, x => x.Person.Address.Street + ", " +
                    x.Person.Address.City + ", " + x.Person.Address.State +
                    " " + x.Person.Address.ZipCode)
                .RuleFor(x => x.Date, DateTime.Now)
                .RuleFor(x => x.Specialization, x => x.Lorem.Sentence(1));

            foreach (var item in docotorsSeed.Generate(20))
            {
                context.Doctors.AddRange(item);
                context.SaveChanges();
            }

        }
    }
}