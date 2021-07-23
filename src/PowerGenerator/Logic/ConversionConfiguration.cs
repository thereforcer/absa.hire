using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Absa.Hire.Newbies.PowerConverter.Logic
{
    public sealed class ConversionConfiguration
    {
        internal ConversionConfiguration()
        {
        }

        private readonly HashSet<ISimpleMapping> _maps = new();
        private readonly HashSet<ConversionMappingRoute> _cache = new();

        internal ConversionMappingRoute FindConversionPath(Unit source, Unit destination)
        {
            var existingRoute = _cache.FirstOrDefault(i => i.Source.Equals(source) && i.Destination.Equals(destination));
            if (existingRoute != null)
            {
                return existingRoute;
            }

            var sourceCategory = source.Category;
            var destinationCategory = destination.Category;
            if (!sourceCategory.Equals(destinationCategory))
            {
                throw new InvalidOperationException($"Cannot convert units in different categories ({sourceCategory} vs {destinationCategory}).");
            }

            var route = InternalFindMappingRoute(source, destination);
            _cache.Add(route);

            return route;
        }

        private ConversionMappingRoute InternalFindMappingRoute(Unit source, Unit destination)
        {
            var mappings = new List<ISimpleMapping>();
            var lastMapping = InternalFindMappingRoute(mappings, null, source, destination);
            if (lastMapping != null)
            {
                mappings.Insert(0, lastMapping);
            }

            if (!mappings.Any())
            {
                throw new MappingNotFoundException(source.UnitName, destination.UnitName);
            }

            return ConversionMappingRoute.Create(mappings.AsReadOnly());
        }

        private ISimpleMapping InternalFindMappingRoute(IList<ISimpleMapping> mappings, List<ISimpleMapping> alreadyUsedMappings, Unit source, Unit destination)
        {
            alreadyUsedMappings ??= new List<ISimpleMapping>();

            var availableMaps = _maps.Where(i => i.Source.Equals(source)).Where(i => alreadyUsedMappings.All(j => !i.Equals(j))).ToList();
            foreach (var mapping in availableMaps)
            {
                if (mapping.Destination.Equals(destination))
                {
                    return mapping;
                }

                var copyAlreadyUsedMapping = alreadyUsedMappings.ToList();
                copyAlreadyUsedMapping.Add(mapping);
                var internalValue = InternalFindMappingRoute(mappings, copyAlreadyUsedMapping, mapping.Destination, destination);
                if (internalValue == null)
                {
                    continue;
                }

                mappings.Insert(0, internalValue);
                return mapping;
            }

            return null;
        }

        public void AddMapping([NotNull]IMapping mapping)
        {
            if (mapping == null)
            {
                throw new ArgumentNullException(nameof(mapping));
            }

            if (mapping.Left == null)
            {
                throw new ArgumentNullException(nameof(mapping.Left), "Left unit not specified.");
            }

            if (mapping.Right == null)
            {
                throw new ArgumentNullException(nameof(mapping.Right), "Right unit not specified.");
            }

            if (mapping.Left.Equals(mapping.Right))
            {
                throw new InvalidOperationException("Cannot convert from/to same unit.");
            }

            var leftCategory = mapping.Left.Category;
            var rightCategory = mapping.Right.Category;
            if (!leftCategory.Equals(rightCategory))
            {
                throw new InvalidOperationException($"Cannot convert units in different categories ({leftCategory} vs {rightCategory}).");
            }

            _maps.Add(new SimplifiedMapping(mapping.Left, mapping.Right, mapping.ConvertToRight));
            _maps.Add(new SimplifiedMapping(mapping.Right, mapping.Left, mapping.ConvertToLeft));
        }
    }
}
