using Microsoft.AspNetCore.Mvc;
using Pokrocile_programovaci_prostredky.Api.Data;
using PptNemocnice.Shared;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Pokrocile_programovaci_prostredky.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VybaveniController : ControllerBase {

    private readonly NemocniceDbContext _db;
    private readonly IMapper _mapper;

    public VybaveniController(NemocniceDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<VybaveniModel>> GetAllVybaveni()
    {

        List<VybaveniModel> models = new();

        var ents = _db.Vybavenis.Include(x => x.Revizions);
        foreach (var ent in ents)
        {

            VybaveniModel vybaveni = _mapper.Map<VybaveniModel>(ent);
            ent.Revizions.OrderBy(d => d.DateTime);
            vybaveni.LastRevision = ent.Revizions.LastOrDefault()?.DateTime;

            models.Add(vybaveni);
        }


        return models;
    }

    [HttpGet("{Id}")]
    public ActionResult<VybaveniSRevizemaModel> GetVybaveniById(Guid Id)
    {
        var item = _db.Vybavenis.Include(x => x.Revizions).Include(x => x.Ukonis).SingleOrDefault(x => x.Id == Id);
        
        if (item == null) return NotFound(); 
        return _mapper.Map<VybaveniSRevizemaModel>(item);
    }
    

    [HttpPost]
    public ActionResult PostVybaveni(VybaveniModel prichoziModel)
    {
        prichoziModel.Id = Guid.Empty;//vynuluju id, db si idčka ošéfuje sama
        VybaveniData ent = _mapper.Map<VybaveniData>(prichoziModel);//mapovaná na "databázový" typ
        _db.Vybavenis.Add(ent);//přidání do db
        _db.SaveChanges();//uložení db (v tuto chvíli se vytvoří id)

        return Ok(ent.Id);
    }

    [HttpPut]
    public ActionResult PutVybaveni(VybaveniModel prichoziModel) 
    {
        var staryZaznam = _db.Vybavenis.SingleOrDefault(x => x.Id == prichoziModel.Id);
        if (staryZaznam == null) return NotFound();
        _mapper.Map(prichoziModel, staryZaznam);
        _db.SaveChanges();

        return Ok();
    }

    [HttpDelete("{Id}")]
    public ActionResult DeleteVybaveni(Guid Id)
    {
        var item = _db.Find<VybaveniData>(Id);
        if (item == null) return NotFound();
        VybaveniData ent = _mapper.Map<VybaveniData>(item);
        _db.Vybavenis.Remove(ent);
        _db.SaveChanges();
        return Ok();
    }

}

