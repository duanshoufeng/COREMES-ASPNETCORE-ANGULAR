using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    [Table("Vehicle")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<FeatureVehicle> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<FeatureVehicle>();
        }
    }
}