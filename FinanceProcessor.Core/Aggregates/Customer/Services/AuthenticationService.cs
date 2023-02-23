using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;

namespace FinanceProcessor.Core.Aggregates.Customer.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStatusChecker _statusChecker;

        public AuthenticationService(IUserRepository userRepository,
            IStatusChecker statusChecker)
        {
            _userRepository = userRepository;
            _statusChecker = statusChecker;
        }

        public Task<bool> ChangePassword(string? oldPass, string? newPass, Guid id)
        {
            return _userRepository.ChangePassword(oldPass, newPass, id);
        }

        public async Task<FinanceUser?> CheckPassword(string? userName, string? password)
        {
            var user = await _userRepository.CheckPassword(userName, password);
            if (user is null)
            {
                return null;
            }

            if(_statusChecker.Check(user))
            {
                return user;
            }

            user.Status = Status.Expired;

            return user;
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string? username)
        {
            throw new NotImplementedException();
        }
    }
}
