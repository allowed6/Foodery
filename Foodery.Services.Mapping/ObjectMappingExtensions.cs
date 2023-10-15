using AutoMapper;

namespace Foodery.Services.Mapping
{
    public static class ObjectMappingExtensions
    {
        public static T To<T>(this object origin, IMapper mapper)
        {
            if (origin == null)
            {
                throw new ArgumentNullException(nameof(origin));
            }

            return mapper.Map<T>(origin);
        }
    }
}
