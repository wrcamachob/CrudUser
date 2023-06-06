using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Interfaces;
using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domain.Models
{
    public class UsersModel
    {
        private long iDIdentifier;
        private string name;
        private string lastName;
        private string email;
        private long phoneNumber;
        private DateTime dateOfBirthday;
        private int age;

        //private IUsers users;
        //public EntityState State { private get; set; }

        [Required(ErrorMessage ="The Identification Number is required")]
        [RegularExpression("([0-9]*)", ErrorMessage ="Identifier Number must be only numbers")]
        //[StringLength(maximumLength:12, MinimumLength = 5, ErrorMessage = "Identification Number must be between 5 to 12 digits.")]
        public long IDIdentifier { get => iDIdentifier; set => iDIdentifier = value; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field name must be alphanumeric")]
        [StringLength(maximumLength:50, MinimumLength =2)]
        public string? Name { get => name; set => name = value; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "The field last name must be alphanumeric")]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string? LastName { get => lastName; set => lastName = value; }
        [Required]
        [EmailAddress]
        public string? Email { get => email; set => email = value; }

        [RegularExpression("([0-9]*)", ErrorMessage = "Phone Number must be only numbers")]
        public long PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime DateOfBirthday { get => dateOfBirthday; set => dateOfBirthday = value; }
        public int Age { get => age; set => age = value; }

        public UsersModel()
        {
        }

        //public string SaveChanges() {
        //    string message = "";
        //    try {
        //        var userModel = new Users();
        //        userModel.Email = Email;
        //        userModel.IDIdentifier = iDIdentifier;
        //        userModel.Name = name;
        //        userModel.LastName = lastName;
        //        userModel.PhoneNumber = phoneNumber;
        //        userModel.DateOfBirthday = dateOfBirthday;

        //        switch (State) {
        //            case EntityState.Added:
        //                users.Add(userModel);
        //                message = "Successfully record";
        //                break;
        //            case EntityState.Modified:
        //                users.Update(userModel);
        //                message = "Successfully edited";
        //                break;
        //            case EntityState.Deleted:
        //                users.Delete(userModel.IDIdentifier);
        //                message = "Successfully deleted";
        //                break;
        //        }
        //    }
        //    catch (Exception ex) {
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

        //public async Task<IEnumerable<UsersModel>> GetAll()
        //{
        //    var usersDataModel = users.GetAllUsers();
        //    var listUserModel = new List<UsersModel>().AsEnumerable();
        //    foreach (Users user in await usersDataModel)
        //    {
        //        var birthDay = user.DateOfBirthday;
        //        listUserModel.Add(new UsersModel 
        //        { 
        //            IDIdentifier = user.IDIdentifier,
        //            Name = user.Name,
        //            LastName = user.LastName,
        //            PhoneNumber = user.PhoneNumber,
        //            DateOfBirthday = user.DateOfBirthday,
        //            Email = user.Email,
        //            Age = CalculateAge(birthDay)
        //        });
        //    }
        //    return listUserModel;
        //}

        //private int CalculateAge(DateTime date) 
        //{
        //    DateTime dateNow = DateTime.Now;
        //    return dateNow.Year - date.Year;
        //}
    }
}
