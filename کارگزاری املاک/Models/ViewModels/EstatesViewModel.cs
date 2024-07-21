using Microsoft.AspNetCore.Mvc.Rendering;

namespace کارگزاری_املاک.Models.ViewModels
{
    public class EstatesViewModel
    {
        public EstateModel? Estate{ get; set; }

        public IFormFile? ImgUp { get; set; }

        public SelectList? CategoryOptions { get; set; }

        public string? SelectedCategory { get; set; }
    }
}
