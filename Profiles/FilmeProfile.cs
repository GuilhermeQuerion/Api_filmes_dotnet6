using AutoMapper;
using Curso_Api6.Dtos;
using Curso_Api6.Models;

namespace Curso_Api6.Profiles {
    public class FilmeProfile: Profile {

        public FilmeProfile() { 
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
