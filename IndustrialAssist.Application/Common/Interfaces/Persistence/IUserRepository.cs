using IndustrialAssist.Domain.UserAggregate;

namespace IndustrialAssist.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}