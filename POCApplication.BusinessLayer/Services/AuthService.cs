using AutoMapper;
using Microsoft.Extensions.Configuration;
using POCApplication.BusinessLayer.Services.Interfaces;
using POCApplication.BusinessLayer.Utilities.CustomExceptions;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DataAccessLayer.Repositories.Interfaces;
using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserToReturnDTO> LoginAsync(UserToLoginDTO userToLoginDTO)
        {
            var user = await _userRepository.GetAsync(
                u => u.Username == userToLoginDTO.Username.ToLower() && u.Password == userToLoginDTO.Password);

            if (user == null)
                throw new UserNotFoundException();

            var userToReturn = _mapper.Map<UserToReturnDTO>(user);

            return userToReturn;
        }

        public async Task<UserToReturnDTO> RegisterAsync(UserToRegisterDTO userToRegisterDTO)
        {
            userToRegisterDTO.Username = userToRegisterDTO.Username.ToLower();

            var addedUser = await _userRepository.AddAsync(_mapper.Map<User>(userToRegisterDTO));

            var userToReturn = _mapper.Map<UserToReturnDTO>(addedUser);

            return userToReturn;
        }                
    }
}
