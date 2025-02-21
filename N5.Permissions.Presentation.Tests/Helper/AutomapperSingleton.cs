using AutoMapper;

namespace N5.Permissions.Presentation.Tests.Helper
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 07/26/2024
    /// </summary>
    public class AutomapperSingleton
    {
        private static IMapper? _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddMaps(typeof(Program));
                    });
                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }
                return _mapper;
            }
        }
    }
}
