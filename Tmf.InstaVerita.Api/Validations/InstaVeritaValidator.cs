using FluentValidation;
using Tmf.InstaVerita.Core.Constants;
using Tmf.InstaVerita.Core.RequestModels;

namespace Tmf.InstaVerita.Api.Validations;

public class InstaVeritaValidator : AbstractValidator<InstaVeritaRequest>
{
    public InstaVeritaValidator()
    {
        RuleFor(x => x.RcNumber).NotEmpty().WithMessage(ValidationMessages.RC_No);
    }
}
