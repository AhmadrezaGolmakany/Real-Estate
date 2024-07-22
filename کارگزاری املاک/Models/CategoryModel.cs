using System.ComponentModel.DataAnnotations;

namespace کارگزاری_املاک.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="لطفا دسته بندی را انتخاب کنید")]
        public string Title { get; set; }


        public string? Description { get; set; }

        


        #region relation


        public ICollection<EstateModel>? EstatesList { get; set; }

        #endregion
    }
}
