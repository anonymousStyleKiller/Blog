using AutoMapper;
using Blog.Common.Mapping;

namespace Blog.Extensions;

public class ConventionalMappingProfile : Profile
{
    public ConventionalMappingProfile()
    {
        var mapFromType = typeof(IMapFrom<>);
        var mapToType = typeof(IMapTo<>);
        var explicitMapType = typeof(IMapTo<>);
        AppDomain
            .CurrentDomain
            .GetAssemblies()
            .Where(a =>
            {
                var name = a.GetName().Name;
                return name != null && name.StartsWith("Blog.");
            })
            .SelectMany(a => a.GetExportedTypes())
            .Where(t => t.IsClass && !t.IsAbstract)
            .Select(t => new
            {
                Type = t,
                MapFrom = GetMappingModal(t, mapFromType),
                MapTo = GetMappingModal(t, mapToType),
                ExplicitMap = t
                    .GetInterfaces()
                    .Where(i => i == explicitMapType)
                    .Select(t => (IMapExplicitly)Activator.CreateInstance(t)!)
                    .FirstOrDefault()
            });
    }

    private Type? GetMappingModal(Type type, Type mappingInterface) =>
        type.GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == mappingInterface)?
            .GetGenericArguments()
            .First();

}