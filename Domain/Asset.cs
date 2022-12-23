using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter asset Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter asset properties")]
        public string? AssetJson { get; set; }
    }
}
