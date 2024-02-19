using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Commands.UpdateUserCommand;
using Application.Features.Users.Validators;
using Core.Security.Entities;
using FluentValidation;

namespace Application.Features.Users.Rules
{
    public static class UsersRules
    {
        public static void IsUserValid(CreateUserValidator validationRules, CreateUserCommand user)
        {
            var validationResult = validationRules.Validate(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }

        public static void IsUpdateUserCommandValid(UpdateUserValidator validationRules, UpdateUserCommand updateUserCommand)
        {
            var validationResult = validationRules.Validate(updateUserCommand);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}