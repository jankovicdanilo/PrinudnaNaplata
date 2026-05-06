using FluentValidation;
using PrinudnaNaplata.Models.Dtos.Debtor;

namespace PrinudnaNaplata.Validators
{
    public class DebtorFilterValidator : AbstractValidator<DebtorFilterDto>
    {
        public DebtorFilterValidator() 
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).LessThanOrEqualTo(100);
            RuleFor(x => x.UkupanDug).GreaterThanOrEqualTo(0).When(x => x.UkupanDug.HasValue);
            RuleFor(x => x.DugOd).LessThanOrEqualTo(x => x.DugDo).When(x => x.DugOd.HasValue && x.DugDo.HasValue);
        }
    }
}
