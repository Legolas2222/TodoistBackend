using TodoistClone.Application.Common.Errors;
using TodoistClone.Application.Common.Interfaces.Authentication;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.Authentication.Commands;

public class AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check that the user doesn't already exist
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }


        // Create user (generate unique ID) & persist that user to the DB
        var user = new User
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };
        _userRepository.Add(user);

        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}