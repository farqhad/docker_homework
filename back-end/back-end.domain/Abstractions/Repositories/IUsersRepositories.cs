using Backend.Domain.Models;

namespace Backend.Domain.Abstractions.Repositories;

public interface IUsersRepository
{
    Task<User> GetById(Guid Id);
    Task<User> CreateUser(User user);
}
