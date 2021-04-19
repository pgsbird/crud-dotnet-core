using System;
using LegalCasesMicrosservice.Data;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Tests
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {   
        }

        public void Seed(LegalCaseContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.LegalCases.AddRange(
                new LegalCase(){ CaseNumber = "6587498-87.9875.9.57.1547", CourtName = "Supreme Federal Court", NameOfResponsible = "Sam Witwick", RegistrationDate = new DateTime(2021,04,16)},
                new LegalCase(){ CaseNumber = "6587498-87.9875.9.57.1533", CourtName = "State Federal Court", NameOfResponsible = "Ben Scholes", RegistrationDate = new DateTime(2021,04,14)},
                new LegalCase(){ CaseNumber = "6587498-87.9875.9.57.0533", CourtName = "Federal Center Court", NameOfResponsible = "Johnny Fingerstone", RegistrationDate = new DateTime(2021,04,18)}
            );

            context.SaveChanges();
        }
    }
}