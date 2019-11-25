using AutoMapper;
using KiksApp.Core.Entities;
using KiksApp.Web.References;
using System;
using System.Globalization;
using System.Linq;

namespace KiksApp.Web.Mapping
{
    public class MappingDefinitions
    {
        public void Initialise()
        {
            _autoRegistrations();
        }

        private void _autoRegistrations()
        {
            var dataEntities =
                ReferencedAssemblies.Domain.
                    GetTypes().Where(x => typeof(IEntity).IsAssignableFrom(x)).ToList();
          
            var dtos =
                ReferencedAssemblies.Dto.
                GetTypes().Where(x => x.Name.EndsWith("Dto", true, CultureInfo.InvariantCulture)).ToList();

            foreach (var entity in dataEntities)
            {
                if (Mapper.GetAllTypeMaps().FirstOrDefault(m => m.DestinationType == entity || m.SourceType == entity) == null)
                {
                    var matchingDto =
                        dtos.FirstOrDefault(x => x.Name.Replace("Dto", string.Empty).Equals(entity.Name, StringComparison.InvariantCultureIgnoreCase));

                    if (matchingDto != null)
                    {
                        Mapper.CreateMap(entity, matchingDto);
                        Mapper.CreateMap(matchingDto, entity);
                    }
                }
            }

        }

    }
}