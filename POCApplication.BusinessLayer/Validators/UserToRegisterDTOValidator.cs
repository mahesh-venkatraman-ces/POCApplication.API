using FluentValidation;
using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Validators
{
    public class UserToRegisterDTOValidator : AbstractValidator<UserToRegisterDTO>
    {
        public UserToRegisterDTOValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
