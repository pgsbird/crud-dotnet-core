using FluentValidation;
using LegalCasesMicrosservice.Data;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Validator
{
    public class LegalCaseValidatorCreate:AbstractValidator<LegalCaseCreateDto>
    {
        private readonly ILegalCaseRepo _repository;
        public LegalCaseValidatorCreate(ILegalCaseRepo repository)
        {
            _repository = repository;
            RuleFor(x => x.CourtName).NotNull().NotEmpty();
            RuleFor(x => x.NameOfResponsible).NotNull().NotEmpty();
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(25).Must(IsUniqueCase)
            .WithMessage("The Case Number must be unique");
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(25)
            .Matches("[0-9]{7}-[0-9]{2}[.][0-9]{4}[.][0-9][.][0-9]{2}[.][0-9]{4}")
            .WithMessage("The Case Number has to be the format 'NNNNNNN-NN.NNNN.N.NN.NNNN'");
            
        }
        private bool IsUniqueCase(string caseNumber)
        {
            return _repository.isUniqueCase(caseNumber);
        }
    }
        public class LegalCaseValidatorUpdate:AbstractValidator<LegalCaseUpdateDto>
    {
        private readonly ILegalCaseRepo _repository;

        public LegalCaseValidatorUpdate(ILegalCaseRepo repository)
        {
            _repository = repository;
            RuleFor(x => x.CourtName).NotNull().NotEmpty();
            RuleFor(x => x.NameOfResponsible).NotNull().NotEmpty();
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(25).Must(IsUniqueCase)
            .WithMessage("The Case Number must be unique");
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(25)
            .Matches("[0-9]{7}-[0-9]{2}[.][0-9]{4}[.][0-9][.][0-9]{2}[.][0-9]{4}")
            .WithMessage("The Case Number has to be the format 'NNNNNNN-NN.NNNN.N.NN.NNNN'.");
            
        }

        private bool IsUniqueCase(string caseNumber)
        {
            return _repository.isUniqueCase(caseNumber);
        }

    }
}