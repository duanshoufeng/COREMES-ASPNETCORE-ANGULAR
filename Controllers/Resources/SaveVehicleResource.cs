using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Core.Models;

namespace Controllers.Resources
{
    public class SaveVehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public Contact Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public SaveVehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}