using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AssetJson { get; set; }
    }
}
