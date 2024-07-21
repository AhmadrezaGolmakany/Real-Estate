using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace کارگزاری_املاک.Models
{
    public class EstateModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "عنوان ملک نمیتواند خالی باشد")]
        [Display(Name = "عنوان")]
        [MaxLength(200)]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(1500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "متراژ نمیتواند خالی باشد")]
        [Display(Name = "متراژ")]
        public int Metrage { get; set; }

        public string? Image { get; set; }

        [Required(ErrorMessage = "قیمت نمیتواند خالی باشد")]
        [Display(Name = "قیمت")]
        public double Price { get; set; }

        [Required(ErrorMessage = "آدرس نمیتواند خالی باشد")]
        [Display(Name = "آدرس")]
        [MaxLength(900)]
        public string? Address { get; set; }


        
        public int categoryId { get; set; }


        #region relation
        [ForeignKey("categoryId")]
        public CategoryModel? CategoryModel { get; set; }


        #endregion
    }
}
