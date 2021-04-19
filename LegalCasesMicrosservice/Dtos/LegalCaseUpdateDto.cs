using System;
using System.ComponentModel.DataAnnotations;

namespace LegalCasesMicrosservice.Models
{
    public class LegalCaseUpdateDto
    {  
        [Required]
        [MaxLength(27)]
        public string CaseNumber{get;set;}
        [Required]
        public string CourtName { get; set; }
        [Required]
        public string NameOfResponsible { get; set; }
        
    }
}