using Tournament.Api.Data;
using Tournament.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Tournament.Data.Data
{
    public static class SeedData
    {
        public static async Task SeedAsync(TournamentApiContext context)
        {
            if (!context.Game.Any())
            {
                var games = new List<Game>
                {
                    new Game { Title = "StarCraft: Brood War", MaxPlayers = 2 },
                    new Game { Title = "StarCraft II", MaxPlayers = 2 },
                    new Game { Title = "Warcraft III", MaxPlayers = 2 }
                };
                await context.Game.AddRangeAsync(games);
                await context.SaveChangesAsync();
            }

            if (!context.TournamentDetails.Any())
            {
                var bw = await context.Game.FirstOrDefaultAsync(g => g.Title == "StarCraft: Brood War");
                var sc2 = await context.Game.FirstOrDefaultAsync(g => g.Title == "StarCraft II");
                var wc3 = await context.Game.FirstOrDefaultAsync(g => g.Title == "Warcraft III");

                var tournaments = new List<TournamentDetails>
                {
                    new TournamentDetails
                    {
                        Title = "Brood War Classic",
                        Location = "Seoul, South Korea",
                        Games = new List<Game> { bw }
                    },
                    new TournamentDetails
                    {
                        Title = "StarCraft II World Championship",
                        Location = "Katowice, Poland",
                        Games = new List<Game> { sc2 }
                    },
                    new TournamentDetails
                    {
                        Title = "Warcraft III Invitational",
                        Location = "Shanghai, China",
                        Games = new List<Game> { wc3 }
                    }
                };
                await context.TournamentDetails.AddRangeAsync(tournaments);
                await context.SaveChangesAsync();
            }
        }
    }
}
