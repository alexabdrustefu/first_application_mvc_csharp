using AutoMapper;
using first_mvc_pattern_c_.Models;

namespace first_mvc_pattern_c_;

public class CinemaProfile:Profile{
    public CinemaProfile(){
        //builder da dto a model
         CreateMap<CinemaDto, Cinema>();
        //builder da model a dto
         CreateMap<Cinema, CinemaDto>();
    }
}