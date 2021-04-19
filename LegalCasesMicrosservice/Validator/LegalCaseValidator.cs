using FluentValidation;
using LegalCasesMicrosservice.Models;

namespace LegalCasesMicrosservice.Validator
{
    public class LegalCaseValidatorCreate:AbstractValidator<LegalCaseCreateDto>
    {
        public LegalCaseValidatorCreate()
        {
            RuleFor(x => x.CourtName).NotNull().NotEmpty();
            RuleFor(x => x.NameOfResponsible).NotNull().NotEmpty();
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(27)
            .Matches("[0-9]{7}-[0-9]{2}.[0-9]{4}.[0-9].[0-9]{2}.[0-9]{4}")
            .WithMessage("The Case Number has to be the format 'NNNNNNN-NN.NNNN.N.NN.NNNN'");
        }
    }
        public class LegalCaseValidatorUpdate:AbstractValidator<LegalCaseUpdateDto>
    {
        public LegalCaseValidatorUpdate()
        {
            RuleFor(x => x.CourtName).NotNull().NotEmpty();
            RuleFor(x => x.NameOfResponsible).NotNull().NotEmpty();
            RuleFor(x => x.CaseNumber).NotNull().NotEmpty().Length(27)
            .Matches("[0-9]{7}-[0-9]{2}.[0-9]{4}.[0-9].[0-9]{2}.[0-9]{4}")
            .WithMessage("The Case Number has to be the format 'NNNNNNN-NN.NNNN.N.NN.NNNN'");
        }
    }
}