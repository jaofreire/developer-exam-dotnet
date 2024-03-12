using FluentValidation;
using PixApi.Models;

namespace PixApi.Validations
{
    public class KeyValidations : AbstractValidator<KeyModel>
    {
        public KeyValidations()
        {
            RuleFor(x => x.TypeKey).NotNull().WithMessage("TypeKey cannot be null")
                .NotEmpty().WithMessage("TypeKey cannot be empty")
                .MinimumLength(3).WithMessage("MinimumLength is 3")
                .Must(ValidateType).WithMessage("Just exist 3 TypeKeys: CPF, E-MAIL, CELLPHONE, in capital letters");

            When(x => x.TypeKey == "CPF", () =>
            {
                RuleFor(x => x.Key).MinimumLength(11).WithMessage("CPF need 11 numbers").MaximumLength(11).WithMessage("CPF just need 11 numbers");
            });

            When(x => x.TypeKey == "E-MAIL", () =>
            {
                RuleFor(x => x.Key).MinimumLength(4).WithMessage("MinimumLength is 4");
            });

            When(x => x.TypeKey == "CELLPHONE", () =>
            {
                RuleFor(x => x.Key).MinimumLength(11).WithMessage("MinimumLength is 11, Ex: 81999998888").MaximumLength(11).WithMessage("MaximumLength is 11, Ex: 81999998888");

            });


        }

        public bool ValidateType(string? type)
        {
            switch (type)
            {
                case "CPF":
                    return true;
                case "E-MAIL":
                    return true;
                case "CELLPHONE":
                    return true;

                default: return false;
            }


        }
    }
}
