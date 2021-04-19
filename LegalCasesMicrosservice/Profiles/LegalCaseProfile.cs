using AutoMapper;
using LegalCasesMicrosservice.Dtos;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Profiles
{
    public class LegalCasesProfile : Profile
    {
        public LegalCasesProfile()
        {
            //Source - Target
            CreateMap<LegalCase,LegalCaseReadDto>();
            CreateMap<LegalCaseCreateDto, LegalCase>();
            CreateMap<LegalCaseUpdateDto,LegalCase>();
            CreateMap<LegalCase, LegalCaseUpdateDto>();
        }
    }
}