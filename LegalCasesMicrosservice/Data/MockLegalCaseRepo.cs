using System;
using System.Collections.Generic;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Data
{
    public class MockLegalCaseRepo : ILegalCaseRepo
    {
        public void CreateLegalCase(LegalCase lcase)
        {
            throw new NotImplementedException();
        }

        public void DeleteLegalCase(LegalCase lcase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LegalCase> GetAllLegalCases()
        {
             var legalcases = new List<LegalCase>
            {
            new LegalCase{LegalCaseId=1,
                CaseNumber="6587498-87.9875.9.57.1547",
                CourtName="Center Court Town",
                NameOfResponsible="Paulo Guilherme",
                RegistrationDate=new DateTime(2021,04,19)},
            new LegalCase{LegalCaseId=2,
                CaseNumber="8759878-21.4534.6.12.5732",
                CourtName="Second Avenue Street",
                NameOfResponsible="Mike Perse",
                RegistrationDate=new DateTime(2021,04,18)},
            new LegalCase{LegalCaseId=3,
                CaseNumber="0258741-25.9630.3.41.8520",
                CourtName="Great Honor Court",
                NameOfResponsible="Samantha Reed",
                RegistrationDate=new DateTime(2021,04,17)}
            };
            return legalcases;
        }

        public LegalCase GetLegalCaseById(int id)
        {
            return new LegalCase{LegalCaseId=1,
            CaseNumber="6587498-87.9875.9.57.1547",
            CourtName="Center Court Town",
            NameOfResponsible="Paulo Guilherme",
            RegistrationDate=new DateTime(2021,04,19)};
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateLegalCase(LegalCase lcase)
        {
            throw new NotImplementedException();
        }
    }
}