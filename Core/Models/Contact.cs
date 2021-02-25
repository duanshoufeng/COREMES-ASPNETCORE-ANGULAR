using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Core.Models
{
    [Owned]
    public class Contact
    {
        [Column("ContactName")]
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Column("ContactEmail")]
        [StringLength(255)]
        public string Email { get; set; }
        [Column("ContactPhone")]
        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
    }
}