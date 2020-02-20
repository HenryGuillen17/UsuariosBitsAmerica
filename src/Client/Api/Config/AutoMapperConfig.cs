using System.Collections.Generic;
using AutoMapper;
using Models.Dao;
using Models.Dto;
using Models.Forms;

namespace Api.Config
{
    public class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UsuarioDto, Usuario>().ReverseMap();
                cfg.CreateMap<UsuarioForm, Usuario>();
                cfg.CreateMap<ICollection<UsuarioDto>, ICollection<Usuario>>();
            });
        }
    }
}
