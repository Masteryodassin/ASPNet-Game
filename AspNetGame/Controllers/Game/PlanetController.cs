﻿using AspNetGame.Controllers.Game.Core;
using AspNetGame.Models.Game;
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
        private readonly PlayerRepository PlayersRepo;

        public PlanetController() : base(new PlanetRepository())
        {
            PlayersRepo = IoC.Resolve<PlayerRepository>();
        }

        private async Task<IEnumerable<Planet>> GetPlayerPlanets()
        {
            var playerId = (await GetPlayer()).Id;
            return (await Repository.GetAllIncluding(p => p.Player))
                .Where(p => p.Player.Id == playerId)
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
            var username = (await GetPlayer()).Username;
            var player = await PlayersRepo.Find(p => p.Username.Equals(username));
                        
            player.Nickname = nickname;
            PlayersRepo.Update(player);
            await PlayersRepo.Save();

            return player;
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

        public override async Task<ActionResult> Create()
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
    }
}
