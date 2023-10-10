using FluentValidation.TestHelper;
using POCApplication.BusinessLayer.Validators;
using POCApplication.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCApplication.UnitTest.Validators
{
    public class UserToRegisterDTOValidatorTests
    {
        private readonly UserToRegisterDTOValidator _userToRegisterDTOValidator;

        public UserToRegisterDTOValidatorTests()
        {
            _userToRegisterDTOValidator = new UserToRegisterDTOValidator();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("username", "")]
        [InlineData("", "password")]
        public void Validate_WhenUsernameOrPasswordOrBothEmpty_ThrowsValidationError(string username, string password)
        {
            var userToRegisterDTO = new UserToRegisterDTO
            {
                Username = username,
                Password = password,
                Name = "",
                Surname = ""
            };

            var result = _userToRegisterDTOValidator.TestValidate(userToRegisterDTO);
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void Validate_WhenUsernameAndPasswordNotEmpty_ShouldNotThrowValidationError()
        {
            var userToRegisterDTO = new UserToRegisterDTO
            {
                Username = "username",
                Password = "password",
                Name = "",
                Surname = ""
            };

            var result = _userToRegisterDTOValidator.TestValidate(userToRegisterDTO);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
