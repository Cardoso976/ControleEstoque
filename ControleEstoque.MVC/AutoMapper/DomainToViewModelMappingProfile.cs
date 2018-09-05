using AutoMapper;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<Pais, PaisViewModel>();
        } 
    }
}