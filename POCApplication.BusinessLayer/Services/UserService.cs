using AutoMapper;
using POCApplication.BusinessLayer.Services.Interfaces;
using POCApplication.BusinessLayer.Utilities.CustomExceptions;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DataAccessLayer.Repositories.Interfaces;
using POCApplication.DTO.DTOs;

namespace POCApplication.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var usersToReturn = await _userRepository.GetListAsync(cancellationToken: cancellationToken);

            return _mapper.Map<List<UserDTO>>(usersToReturn);
        }

        public async Task<UserDTO> GetUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            var userToReturn = await _userRepository.GetAsync(x => x.UserId == userId, cancellationToken);

            if (userToReturn is null)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<UserDTO>(userToReturn);
        }

        public async Task<UserDTO> AddUserAsync(UserToAddDTO userToAddDTO)
        {
            userToAddDTO.Username = userToAddDTO.Username.ToLower();
            var addedUser = await _userRepository.AddAsync(_mapper.Map<User>(userToAddDTO));

            return _mapper.Map<UserDTO>(addedUser);
        }

        public async Task<UserDTO> UpdateUserAsync(UserToUpdateDTO userToUpdateDTO)
        {
            userToUpdateDTO.Username = userToUpdateDTO.Username.ToLower();
            var user = await _userRepository.GetAsync(x => x.UserId == userToUpdateDTO.UserId);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var userToUpdate = _mapper.Map<User>(userToUpdateDTO);

            return _mapper.Map<UserDTO>(await _userRepository.UpdateUserAsync(userToUpdate));
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userToDelete = await _userRepository.GetAsync(x => x.UserId == userId);

            if (userToDelete is null)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.DeleteAsync(userToDelete);
        }
    }
}
