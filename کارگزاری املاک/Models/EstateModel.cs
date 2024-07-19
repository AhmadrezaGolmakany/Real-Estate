using System.ComponentModel.DataAnnotations;

namespace کارگزاری_املاک.Models
{
    public class EstateModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}نمیتواند خالی وارد شود.")]
        [Display(Name = "عنوان")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "{0}نمیتواند خالی وارد شود.")]
        [Display(Name = "متراژ")]
        [MaxLength(10)]
        public int Metrage { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "{0}نمیتواند خالی وارد شود.")]
        [Display(Name = "قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0}نمیتواند خالی وارد شود.")]
        [Display(Name = "آدرس")]
        [MaxLength(900)]
        public string Address { get; set; }


        
    }
}
