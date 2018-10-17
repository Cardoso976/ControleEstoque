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
            Mapper.CreateMap<Estado, EstadoViewModel>();
            Mapper.CreateMap<Cidade, CidadeViewModel>();

            Mapper.CreateMap<GrupoProduto, GrupoProdutoViewModel>();
            Mapper.CreateMap<UnidadeMedida, UnidadeMedidaViewModel>();
            Mapper.CreateMap<MarcaProduto, MarcaProdutoViewModel>();
            Mapper.CreateMap<LocalArmazenamento, LocalArmazenamentoViewModel>();
        } 
    }
}