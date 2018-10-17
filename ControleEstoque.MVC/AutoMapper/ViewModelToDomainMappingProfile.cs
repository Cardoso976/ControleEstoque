using AutoMapper;
using ControleEstoque.Domain.Entities;
using ControleEstoque.MVC.ViewModels;

namespace ControleEstoque.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<PaisViewModel, Pais>();
            Mapper.CreateMap<EstadoViewModel, Estado>();
            Mapper.CreateMap<CidadeViewModel, Cidade>();

            Mapper.CreateMap<GrupoProdutoViewModel, GrupoProduto>();
            Mapper.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>();
            Mapper.CreateMap<MarcaProdutoViewModel, MarcaProduto>();
            Mapper.CreateMap<LocalArmazenamentoViewModel, LocalArmazenamento>();
        }
    }
}