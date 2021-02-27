using Domain;
using FluentValidation;

namespace Application.Doctors
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Specialization).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Date).NotEmpty();
        }
    }
}