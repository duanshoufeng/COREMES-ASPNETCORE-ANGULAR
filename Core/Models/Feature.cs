using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("Feature")]
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<FeatureVehicle> Vehicles { get; set; }
        public Feature()
        {
            Vehicles = new Collection<FeatureVehicle>();
        }
    }
}