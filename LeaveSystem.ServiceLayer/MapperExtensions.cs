using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace LeaveSystem.ServiceLayer
{
    public static class MapperExtensions
    {
        private static void IgnoreUnmappedProperties(TypeMap map, IMappingExpression expr)
        {
            foreach(string propname in map.GetUnmappedPropertyNames())
            {
                if (map.SourceType.GetProperty(propname) != null)
                {
                    expr.ForMember(propname, t => t.Ignore());
                }
                if (map.DestinationType.GetProperty(propname) != null)
                {
                    expr.ForMember(propname, t => t.Ignore());
                }
            }
        }
        public static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);
        }
    }
}
