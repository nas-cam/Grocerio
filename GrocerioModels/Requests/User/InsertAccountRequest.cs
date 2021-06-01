using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace GrocerioModels.Requests.User
{
    public class InsertAccountRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[^\s\,]+$", ErrorMessage = "Username Cannot Have Spaces")]
        [Required]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Required]
        [RegularExpression(@"^[^\s\,]+$", ErrorMessage = "Username Cannot Have Spaces")]
        public string ConfirmPassword { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin, 
        User
    }
}
