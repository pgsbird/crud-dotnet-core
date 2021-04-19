using System;
using System.Collections.Generic;
using System.Linq;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Data
{
    public class SqlLegalCaseRepo: ILegalCaseRepo
    {
        private readonly LegalCaseContext _context;

        public SqlLegalCaseRepo(LegalCaseContext context)
        {
            _context = context;
        }

        public void CreateLegalCase(LegalCase lcase)
        {
            if(lcase == null)
            {
                throw new ArgumentNullException(nameof(lcase));
            }
            _context.LegalCases.Add(lcase);
        }

        public void DeleteLegalCase(LegalCase lcase)
        {
             if(lcase == null)
            {
                throw new ArgumentNullException(nameof(lcase));
            }
            _context.LegalCases.Remove(lcase);
        }

        public IEnumerable<LegalCase> GetAllLegalCases()
        {
            return _context.LegalCases.ToList();
        }

        public LegalCase GetLegalCaseById(int id)
        {
            return _context.LegalCases.FirstOrDefault(l => l.LegalCaseId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLegalCase(LegalCase lcase)
        {
             if(lcase == null)
            {
                throw new ArgumentNullException(nameof(lcase));
            }
            _context.LegalCases.Update(lcase);
        }

        public bool isUniqueCase(string caseNumber)
        {
            return !_context.LegalCases.Any(x => x.CaseNumber == caseNumber);
        }
    }
}