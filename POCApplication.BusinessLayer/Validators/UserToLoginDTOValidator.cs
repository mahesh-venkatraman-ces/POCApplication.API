using FluentValidation;
using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Validators
{
    public class UserToLoginDTOValidator : AbstractValidator<UserToLoginDTO>
    {
        public UserToLoginDTOValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
