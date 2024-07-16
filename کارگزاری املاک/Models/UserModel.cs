using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace کارگزاری_املاک.Models
{
    public class UserModel : IdentityUser
    {
        [Required(ErrorMessage = "لطفا نام خودرا وارد کنید")]
        [MaxLength(100,ErrorMessage = "نام شما نمیتواند بیشتر از 100 کاراکتر باشد")]
        public string FullName { get; set; }
    }
}
