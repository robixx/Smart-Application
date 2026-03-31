using Microsoft.EntityFrameworkCore;
using SmartInventory.Applycation.Interface;
using SmartInventory.Applycation.ModelView;
using SmartInventory.Domain.Entity;
using SmartInventory.Infrastructure.DataConnect;
using SmartInventory.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure.Services
{
    public class UserService : IUser
    {

        private readonly DatabaseConnection _connection;

        public UserService(DatabaseConnection connection)
        {
            _connection = connection;
        }
        public async Task<(string Message, bool Status, List<UserDto> user_list)> GetUserAsync()
        {
            try
            {
                var user = await _connection.User
                  .ToListAsync(); // materialize entities first

                var userDto = user.Select(e => new UserDto
                {
                    UserId = e.UserId,
                    UserName = e.UserName,
                    LoginUserName = e.LoginUserName,
                    IsActive = e.IsActive,
                    Email = e.Email
                }).ToList();

                return ("User loaded successfully", true, userDto);

            }
            catch(Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(GetUserAsync)}: Error -> : {ex.Message}", false, new List<UserDto>());
            }
        }

        public async Task<(string Message, bool Status)> UserSaveAsync( UserDto userDto)
        {
            try
            {
                if (userDto == null)
                    return ("Invalid user data", false);

                
                if (userDto.UserId == 0)
                {
                   
                    var newUser = new User
                    {
                        UserName = userDto.UserName,
                        LoginUserName = userDto.LoginUserName,
                        PasswordHash = HashHelper.ComputeSha256Hash(userDto.PasswordHash), 
                        Email = userDto.Email,
                        IsActive = userDto.IsActive,
                        CreatedDate = DateTime.Now
                    };
                   
                    await  _connection.User.AddRangeAsync(newUser);
                }
                else
                {
                    
                    var existingUser = await _connection.User.FindAsync(userDto.UserId);
                    if (existingUser == null)
                        return ("User not found",false);

                    existingUser.UserName = userDto.UserName;
                    existingUser.LoginUserName = userDto.LoginUserName;
                    if (!string.IsNullOrWhiteSpace(userDto.PasswordHash))
                        existingUser.PasswordHash = HashHelper.ComputeSha256Hash(userDto.PasswordHash); 
                    existingUser.Email = userDto.Email;
                    existingUser.IsActive = userDto.IsActive;
                }

                await _connection.SaveChangesAsync();

                return ($"{userDto.UserName} save successfully", true);

            }
            catch (Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(UserSaveAsync)}: Error -> : {ex.Message}", false);
            }
        }
    }
}
