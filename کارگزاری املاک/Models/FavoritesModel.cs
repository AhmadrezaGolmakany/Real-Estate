using System.ComponentModel.DataAnnotations.Schema;

namespace کارگزاری_املاک.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }

        public int? EstateId { get; set; }

        public string? userId { get; set; }


        #region Relation

        [ForeignKey(nameof(EstateId))]
        public EstateModel? Estate { get; set; }

        [ForeignKey(nameof(userId))]
        public UserModel? User { get; set; }

        #endregion
    }
}
