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

                return ("User loaded Successfully", true, userDto);

            }
            catch(Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(GetUserAsync)}: Error -> : {ex.Message}", false, new List<UserDto>());
            }
        }

        public async Task<(string Message, bool Status)> UserDeleteAsync(int Id)
        {
            try
            {

                var user = await _connection.User.FindAsync(Id);

                if (user == null)
                {
                    return ("User not found", false);
                }

                _connection.User.Remove(user);
                await _connection.SaveChangesAsync();

                return ("User Delete Successfully", true);

            }
            catch (Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(UserDeleteAsync)}: Error -> : {ex.Message}", false);
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

        public async Task<(string Message, bool Status, List<RoleDto> role_list)> GetRoleAsync()
        {
            try
            {

                var roles = await _connection.Role.ToListAsync();

                var userRoles = await (
                    from ur in _connection.UserWiseRolePermission
                    join u in _connection.User on ur.UserId equals u.UserId
                    select new
                    {
                        ur.RoleId,
                        u.UserId,
                        u.UserName
                    }
                ).ToListAsync();

                var result = roles.Select(r => new RoleDto
                {
                    RoleId = r.Id,
                    RoleName = r.RoleName,
                    IsActive = r.IsActive,
                    userlist = userRoles
                        .Where(x => x.RoleId == r.Id)
                        .Select(x => new UserAssignRoleDto
                        {
                            UserId = x.UserId,
                            UserName = x.UserName
                        }).ToList()
                }).ToList();



                return ("Role loaded Successfully", true, result);

            }
            catch (Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(GetRoleAsync)}: Error -> : {ex.Message}", false, new List<RoleDto>());
            }
        }

        public async Task<(string Message, bool Status)> RoleSaveAsync(RoleDto roleDto)
        {
            try
            {
                if (roleDto == null)
                    return ("Invalid Role data", false);


                if (roleDto.RoleId == 0)
                {

                    var newRole = new Role
                    {
                        Id = roleDto.RoleId,
                        RoleName = roleDto.RoleName??"",                       
                        IsActive = roleDto.IsActive,
                        CreatedDate = DateTime.Now
                    };

                    await _connection.Role.AddRangeAsync(newRole);
                }
                else
                {

                    var existingRole = await _connection.Role.FindAsync(roleDto.RoleId);
                    if (existingRole == null)
                        return ("User not found", false);

                    existingRole.RoleName = roleDto.RoleName??"";                 
                   
                    existingRole.IsActive = roleDto.IsActive;
                }

                await _connection.SaveChangesAsync();

                return ($"{roleDto.RoleName} save successfully", true);

            }
            catch (Exception ex)
            {
                return ($"Service ->{nameof(UserService)}: Method ->:{nameof(RoleSaveAsync)}: Error -> : {ex.Message}", false);
            }
        }
    }
}
