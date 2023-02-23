using FinanceProcessor.Core.Aggregates.Customer.DTOs;
using FinanceProcessor.Core.Aggregates.Customer.Enums;
using FinanceProcessor.Core.Aggregates.Customer.Models;
using FinanceProcessor.Core.Aggregates.Customer.Repository;
using FinanceProcessor.Core.Aggregates.DataConsumer.Interfaces.User;

namespace FinanceProcessor.Core.Aggregates.Customer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurity _security;

        public UserService(IUserRepository userRepository, ISecurity security)
        {
            _userRepository = userRepository;
            _security = security;
        }

        public Guid? CreateUser(CreateUserDto data, UserRole role)
        {
            //data.Password = _security.EncryptStringToBytes(data.Password);
            return _userRepository.CreateUser(data, role);
        }

        public async Task DeletedUser(Guid userId)
        {
            var userIdStr = userId.ToString();
            await _userRepository.DeleteUser(userIdStr);
        }

        public List<FinanceUser> GetAllUsers(FilterUsersDto filterUsersDto)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserDataByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public CreateProfile? GetUserProfile(string id)
        {
            return _userRepository.GetUserProfile(id);
        }

        public UserDto UpdateUser(FinanceUser user)
        {
            throw new NotImplementedException();
        }

        public bool UpdatingProfile(CreateProfile profile)
        {
            return _userRepository.UpdateUser(profile);
        }
    }
}
