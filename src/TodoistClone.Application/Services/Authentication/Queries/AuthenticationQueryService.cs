using TodoistClone.Application.Common.Errors;
using TodoistClone.Application.Common.Interfaces.Authentication;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

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

    public AuthenticationResult Login(string email, string password)
    {
        // Validate the user exists
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }
        // Check the password 
        if (user.Password != password)
        {
            throw new Exception("The given password is not correct");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        // Create JWT token and return that token
        return new AuthenticationResult(
            user,
            token);
    }
}