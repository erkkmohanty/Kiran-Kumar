using System.ComponentModel.DataAnnotations;

namespace Data_Layer.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population01 { get; set; }
        public int Population05 { get; set; }
        public int Population10 { get; set; }
        public int Population15 { get; set; }
    }
}
