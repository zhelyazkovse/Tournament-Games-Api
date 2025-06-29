using Tournament.Api.Data;
using Tournament.Core.Entities;

namespace Tournament.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TournamentApiContext>();

            if (!context.TournamentDetails.Any())
            {
                var tournament1 = new TournamentDetails {
                    Title = "DreamHack Masters",
                    Location = "Jönköping",
                    StartDate = DateTime.UtcNow,
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Counter-Strike: GO",
                            Time = DateTime.UtcNow.AddHours(1),
                            MaxPlayers = 10
                        }
                    }
                };

                var tournament2 = new TournamentDetails {
                    Title = "The International",
                    Location = "Seattle",
                    StartDate = DateTime.UtcNow,
                    Games = new List<Game>
                    {
                        new Game
                        {
                            Title = "Dota 2",
                            Time = DateTime.UtcNow.AddHours(2),
                            MaxPlayers = 10
                        }
                    }
                };

                await context.TournamentDetails.AddRangeAsync(tournament1, tournament2);
                await context.SaveChangesAsync();
            }
        }
    }
}
