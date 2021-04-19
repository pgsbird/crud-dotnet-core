using System;

namespace LegalCasesMicrosservice.Dtos
{
    public class LegalCaseReadDto
    {
        public int LegalCaseId { get; set; }      
        public string CaseNumber{get;set;}
        public string CourtName { get; set; }
        public string NameOfResponsible { get; set; }
        public DateTime RegistrationDate { get; set; }
        
    }
}