using AspNetGame.Controllers.Game.Core;
using AspNetGame.Models.Game;
using AspNetGame.Models.Game.Units;
using AspNetGame.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetGame.Controllers.Game
{
    [Authorize(Roles = "Player")]
    public class PlanetController : GameController<Planet>
    {
        private readonly PlayerRepository _players;
        private readonly UnitTemplateRepository _unitTemplates;

        public PlanetController() : base(new PlanetRepository())
        {
            _players = IoC.Resolve<PlayerRepository>();
            _unitTemplates = IoC.Resolve<UnitTemplateRepository>();
        }

        private async Task<IEnumerable<Planet>> GetPlayerPlanets()
        {
            return (await Repository.GetAllIncluding(p => p.Player))
                .Where(p => p.Player.Id == Player.Id)
                .ToList();
        }

        private async Task CreatePlanet(Player player, string planetName)
        {
            Planet planet = new Planet()
            {
                Name = planetName,
                PlayerId = player.Id
                // ImagePath = ?
            };
            Repository.Insert(planet);
            await Repository.Save();
        }

        private async Task<Player> UpdatePlayer(string nickname)
        {
            Player.Nickname = nickname;
            _players.Update(Player);
            await _players.Save();

            return _players.Attach(Player);
        }

        public override async Task<ActionResult> Index()
        {

            IEnumerable<Planet> planets = await GetPlayerPlanets();

            if (planets.Count() == 0)
            {
                ViewBag.PlanetImageNo = new Random().Next(1, 9);
                return RedirectToAction("Create");
            }
            else
            {
                return View(planets);
            }
        }

        public override ActionResult Create()
        {
            return View(new NewPlanetModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNew([Bind]NewPlanetModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var player = await UpdatePlayer(model.Nickname);
                    await CreatePlanet(player, model.PlanetName);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View("Create", model);
        }

        public override async Task<ActionResult> Create([Bind] Planet entity)
        {
            return new HttpStatusCodeResult(501);
        }

        public override async Task<ActionResult> Details(long Id)
        {
            Planet planet = await (Repository.Find(Id));

            Dictionary<UnitTemplate, int> templateNumber = new Dictionary<UnitTemplate, int>();

            var activeUnitTemplate = (await _unitTemplates.GetAll()).Where(u => u.isActive == true).ToList();
        
            foreach (UnitTemplate unitTemplate in activeUnitTemplate)
            {
                templateNumber.Add(unitTemplate, 0);               
            }

            foreach (UnitTemplate pUnitTemplate in planet.Units)
            {
                if (activeUnitTemplate.Contains(pUnitTemplate))
                {
                    var a = templateNumber[pUnitTemplate];
                    templateNumber[pUnitTemplate] = ++a;
                }
            }

            ViewBag.templateNumber = templateNumber;
            return View(planet);
        }

    }
}
