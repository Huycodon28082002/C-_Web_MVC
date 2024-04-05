using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TAB.ViewModels.System.Users;

namespace eShopSolution.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required")
                .MaximumLength(200).WithMessage("address can not over 200 characters");
           // RuleFor(x => x.Avatar)
             //  .NotNull().WithMessage("Vui lòng chọn ảnh đại diện");
           

            //RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-130)).WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

          //  RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required")
           //     .Matches(@"^\d{1,11}$").WithMessage("Phone number must be 1 to 11 digits");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

           /* RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            }); */
        }
    }
}