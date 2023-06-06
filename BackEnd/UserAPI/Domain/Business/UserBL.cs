using Domain.Interfaces;
using Domain.Models;
using Domain.ValueObjects;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Business
{
    public class UserBL : IUsersBL<UsersModel>
    {
        private IUsers users;
        //private UsersModel usersModel;
        public EntityState State { private get; set; }

        public UserBL(IConfiguration config)
        {
            users = new UsersRepository(config);
        }

        //public string SaveChanges()
        //{
        //    string message = "";
        //    try
        //    {
        //        var userMod = new Users
        //        {
        //            Email = usersModel.Email,
        //            IDIdentifier = usersModel.IDIdentifier,
        //            Name = usersModel.Name,
        //            LastName = usersModel.LastName,
        //            PhoneNumber = usersModel.PhoneNumber,
        //            DateOfBirthday = usersModel.DateOfBirthday
        //        };

        //        switch (State)
        //        {
        //            case EntityState.Added:
        //                users.Add(userMod);
        //                message = "Successfully record";
        //                break;
        //            case EntityState.Modified:
        //                users.Update(userMod);
        //                message = "Successfully edited";
        //                break;
        //            case EntityState.Deleted:
        //                users.Delete(userMod.IDIdentifier);
        //                message = "Successfully deleted";
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
        //        {
        //            message = "Duplicated register";
        //        }
        //        else
        //        {
        //            message = ex.ToString();
        //        }

        //    }
        //    return message;
        //}

        public async Task<IEnumerable<UsersModel>> GetAll()
        {
            var usersDataModel = await users.GetAllUsers();
            var listUserModel = new List<UsersModel>();
            foreach (Users user in usersDataModel)
            {
                var birthDay = user.DateOfBirthday;
                listUserModel.Add(new UsersModel
                {
                    IDIdentifier = user.IDIdentifier,
                    Name = user.Name,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    DateOfBirthday = user.DateOfBirthday,
                    Email = user.Email,
                    Age = CalculateAge(birthDay)
                });
            }
            return listUserModel;
        }

        public async Task<string> Insert(UsersModel userM)
        {
            string message;
            try
            {
                var userMod = new Users
                {
                    Email = userM.Email,
                    IDIdentifier = userM.IDIdentifier,
                    Name = userM.Name,
                    LastName = userM.LastName,
                    PhoneNumber = userM.PhoneNumber,
                    DateOfBirthday = userM.DateOfBirthday
                };
                _ = await users.Add(userMod);
                message = "Successfully record";
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                {
                    message = "Duplicated register";
                }
                else
                {
                    message = ex.ToString();
                }
            }
            return message;
        }

        public async Task<string> Update(UsersModel userM)
        {
            string message;
            try
            {
                var userMod = new Users
                {
                    Email = userM.Email,
                    IDIdentifier = userM.IDIdentifier,
                    Name = userM.Name,
                    LastName = userM.LastName,
                    PhoneNumber = userM.PhoneNumber,
                    DateOfBirthday = userM.DateOfBirthday
                };
                _ = await users.Update(userMod);
                message = "Successfully edited";
            }
            catch (Exception ex)
            {
                if (ex is System.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 2627)
                {
                    message = "Duplicated register";
                }
                else
                {
                    message = ex.ToString();
                }
            }
            return message;
        }

        public async Task<string> Delete(long id)
        {
            string message;
            var userMod = new Users
            {                
                IDIdentifier = id,                
            };
            _ = await users.Delete(userMod.IDIdentifier);
            message = "Successfully deleted";
            return message;
        }

        private static int CalculateAge(DateTime date)
        {
            DateTime dateNow = DateTime.Now;
            return dateNow.Year - date.Year;
        }
    }
}
