using System.Collections.Generic;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Data
{
    public interface ILegalCaseRepo
    {
        bool SaveChanges();
        
        IEnumerable<LegalCase> GetAllLegalCases();

        LegalCase GetLegalCaseById(int id);

        void CreateLegalCase(LegalCase lcase);

        void UpdateLegalCase(LegalCase lcase);

        void DeleteLegalCase(LegalCase lcase);
    }
}