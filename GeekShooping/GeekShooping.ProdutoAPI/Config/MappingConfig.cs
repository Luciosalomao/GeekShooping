using AutoMapper;
using GeekShooping.ProdutoAPI.Data.ValueObjects;
using GeekShooping.ProdutoAPI.Model;

namespace GeekShooping.ProdutoAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoVO, Produto>();
                config.CreateMap<Produto, ProdutoVO>();
            });
            return mappingConfig;
        }
    }
}
