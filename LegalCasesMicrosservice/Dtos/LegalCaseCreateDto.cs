using System;
using System.ComponentModel.DataAnnotations;

namespace LegalCasesMicrosservice.Models
{
    public class LegalCaseCreateDto
    {
        [Required]
        [MaxLength(25)]
        public string CaseNumber{get;set;}
        [Required]
        public string CourtName { get; set; }
        [Required]
        public string NameOfResponsible { get; set; }
        
    }
}