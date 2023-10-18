using AutoMapper;
using PaperCastle.Core;
using PaperCastle.Core.Entity;
using PaperCastle.Infrastructure.Data.ViewModels;

namespace PaperCastle.Application.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<BookDto, Book>();

            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();

            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();

            CreateMap<Bookshelf, BookshelfDto>();
            CreateMap<BookshelfDto, Bookshelf>();

            CreateMap<BookVM, Book>()
            .ForMember(dest => dest.BookGenres, opt => opt.MapFrom(src => src.GenreIds.Select(genreId => new BookGenre { GenreId = genreId })));

            CreateMap<Book, BookVM>()
            .ForMember(dest => dest.GenreIds, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.GenreId).ToList()));
        }
    }
}
