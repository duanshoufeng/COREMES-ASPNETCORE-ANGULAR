using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Controllers.Resources;
using Persistence;
using Core.Models;

namespace Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API 
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValueResource>();
            CreateMap<Model, KeyValueResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(v => v.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(fv => new KeyValueResource { Id = fv.FeatureId, Name = fv.Feature.Name })));

            //API to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    // Remove unselected features
                    var removedFeatures = new List<FeatureVehicle>();
                    foreach (var f in v.Features)
                        if (!vr.Features.Contains(f.FeatureId))
                            removedFeatures.Add(f);
                    foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                    // Add new features
                    foreach (var id in vr.Features)
                        if (!v.Features.Any(f => f.FeatureId == id))
                            v.Features.Add(new FeatureVehicle { FeatureId = id });

                });
        }
    }
}