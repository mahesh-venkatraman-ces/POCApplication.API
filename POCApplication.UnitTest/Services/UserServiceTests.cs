using AutoFixture.Xunit2;
using AutoMapper;
using Moq;
using POCApplication.BusinessLayer.Services;
using POCApplication.BusinessLayer.Services.Interfaces;
using POCApplication.BusinessLayer.Utilities.AutomapperProfiles;
using POCApplication.BusinessLayer.Utilities.CustomExceptions;
using POCApplication.DataAccessLayer.Entities;
using POCApplication.DataAccessLayer.Repositories.Interfaces;
using POCApplication.DTO.DTOs;
using System.Linq.Expressions;

namespace POCApplication.UnitTest.Services
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;

        public UserServiceTests()
        {
            var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

            _userService = new UserService(_userRepository.Object, _mapper);
        }

        [Theory]
        [AutoData]
        public async Task GetUsersAsync_WhenSuccess_ReturnsUserDTOList(List<User> users)
        {
            //Arrange
            var userEntityList = users;

            _userRepository
                .Setup(repo => repo.GetListAsync(null!, CancellationToken.None))
                .ReturnsAsync(userEntityList);

            //Act
            var result = await _userService.GetUsersAsync();

            //Assert
            Assert.Equal(2, result.Count);
        }

        [Theory]
        [AutoData]
        public async Task GetUserAsync_WhenSuccess_ReturnsUserDTOList(int userid)
        {
            //Act
            var result = await _userService.GetUserAsync(userid);

            //Assert
            Assert.NotNull(result);
        }

        [Theory]
        [AutoData]
        public async Task GetUserAsync_WhenUserDoesNotExist_ThrowsUserNotFoundException(int userid)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), CancellationToken.None))
                .ReturnsAsync((User)null!);

            //Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.GetUserAsync(userid));
        }

        [Theory]
        [AutoData]
        public async Task AddUserAsync_WhenSuccess_AddsThenReturnsUserDTO(User user, UserToAddDTO usertoaddDTO)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.AddAsync(It.IsAny<User>()))
                .ReturnsAsync(user);

            //Act
            var result = await _userService.AddUserAsync(usertoaddDTO);

            //Assert
            Assert.IsType<UserDTO>(result);
            Assert.Equal(user.UserId, result.UserId);
        }

        [Theory]
        [AutoData]
        public async Task UpdateUserAsync_WhenSuccess_UpdatesThenReturnsUserDTO(User user, UserToUpdateDTO userToUpdateDTO)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.UpdateUserAsync(It.IsAny<User>()))
                .ReturnsAsync(user);

            //Act
            var result = await _userService.UpdateUserAsync(userToUpdateDTO);

            //Assert
            Assert.IsType<UserDTO>(result);
            Assert.NotNull(result);
        }

        [Theory]
        [AutoData]
        public async Task UpdateUserAsync_WhenUserDoesNotExist_ThrowsUserNotFoundException(UserToUpdateDTO userToUpdateDTO)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), CancellationToken.None))
                .ReturnsAsync((User)null!);

            //Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.UpdateUserAsync(userToUpdateDTO));
        }

        [Theory]
        [AutoData]
        public async Task DeleteUserAsync_WhenSuccess_CallsRepositoryDelete(int userid)
        {
            //Act
            await _userService.DeleteUserAsync(userid);

            //Assert
            _userRepository.Verify(x => x.DeleteAsync(It.IsAny<User>()), Times.Once());
        }

        [Theory]
        [AutoData]
        public async Task DeleteUserAsync_WhenUserDoesNotExist_ThrowsUserNotFoundException(int userid)
        {
            //Arrange
            _userRepository
                .Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<User, bool>>>(), CancellationToken.None))
                .ReturnsAsync((User)null!);

            //Act & Assert
            await Assert.ThrowsAsync<UserNotFoundException>(() => _userService.DeleteUserAsync(userid));
        }
    }
}
