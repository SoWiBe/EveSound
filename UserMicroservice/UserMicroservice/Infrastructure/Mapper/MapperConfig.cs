using AutoMapper;

namespace UserMicroservice.Infrastructure.Mapper;

public class MapperConfig
{
    public static AutoMapper.Mapper InitializeAutomapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Models.User, UserEntity>().ReverseMap();
        });

        var mapper = new AutoMapper.Mapper(config);
        return mapper;
    }
}