using AutoMapper;
using PptNemocnice.Shared;

namespace Pokrocile_programovaci_prostredky.Api.Data;

public class NemocniceMappig : Profile
{

    public NemocniceMappig()
    {
        CreateMap<VybaveniData, VybaveniModel>().ReverseMap();
    }

}