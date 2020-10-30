using System.ComponentModel.DataAnnotations;

namespace CatCards.Models
{
    public class CatCard
    {
        public int CatCardId { get; set; }
        public string CatFact { get; set; }
        public string ImgUrl { get; set; }
        [Required]
        public string Caption { get; set; }
    }
}
