using AutoMapper;
using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_;

public class FilmProfile:Profile{
    public FilmProfile(){
        //builder da dto a model
         CreateMap<FilmDTO, Film>();
        //builder da model a dto
         CreateMap<Film, FilmDTO>();
    }
}