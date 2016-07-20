using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using chsakell_SPA.Models;
using HomeCinema.Entities.Entities;

namespace chsakell_SPA.Infrastructure.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            var movieConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieViewModel>()
                    .ForMember(vm => vm.Genre, map => map.MapFrom(m => m.Genre.Name))
                    .ForMember(vm => vm.GenreId, map => map.MapFrom(m => m.Genre.Id))
                    .ForMember(vm => vm.IsAvailable, map => map.MapFrom(m => m.Stocks.Any(s => s.IsAvailable)))
                    .ForMember(vm => vm.NumberOfStocks, map => map.MapFrom(m => m.Stocks.Count))
                    .ForMember(vm => vm.Image,
                        map => map.MapFrom(m => string.IsNullOrEmpty(m.Image) == true ? "unknown.jpg" : m.Image));
            });

            IMapper mapper = movieConfig.CreateMapper();
            var source = new Movie();
            var dest = mapper.Map<Movie, MovieViewModel>(source);



            var genreConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreViewModel>()
                    .ForMember(vm => vm.NumberOfMovies, map => map.MapFrom(g => g.Movies.Count()));
            });

            IMapper genreMapper = genreConfig.CreateMapper();
            var genreSource = new Genre();
            var genreDest = genreMapper.Map<Genre, GenreViewModel>(genreSource);

            var customerConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>();
            });

            IMapper customerMapper = customerConfig.CreateMapper();
            var customerSource = new Customer();
            var customerDest = customerMapper.Map<Customer, CustomerViewModel>(customerSource);


            var stockConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Stock, StockViewModel>();
            });

            IMapper stockMapper = stockConfig.CreateMapper();
            var stockSource = new Stock();
            var stockDest = stockMapper.Map<Stock, StockViewModel>(stockSource);


            var rentConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Rental, RentalViewModel>();
            });

            IMapper rentMapper = rentConfig.CreateMapper();
            var rentSource = new Rental();
            var rentDest = rentMapper.Map<Rental, RentalViewModel>(rentSource);

        }

    }
}