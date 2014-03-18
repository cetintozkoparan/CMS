using System.ComponentModel.DataAnnotations;

namespace CMS.Entities
{
    public class SampleEntity
    {
        public int SampleEntityId { get; set; }
        [Required(ErrorMessage = "Name is Mandatory")]
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters.")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

    }
}
