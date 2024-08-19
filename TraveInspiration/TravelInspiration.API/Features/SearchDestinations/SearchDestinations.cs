using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelInspiration.API.Shared.Networking;

namespace TravelInspiration.API.Features.SearchDestinations
{
    public static class SearchDestinations
    {
        public static void AddEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/destinations", async (String? searchFor,
                ILoggerFactory logger,
                IDestinationSearchApiClient destinationSearchApiClient,
                CancellationToken? cancellationToken) =>
            {
                logger.CreateLogger("EndpointHandlers")
                    .LogInformation("Searching for destinations with search term {SearchFor}", searchFor);

                var destinations = await destinationSearchApiClient
                    .GetDestinationsAsync(searchFor, cancellationToken);

                var dto = destinations.Select(d => new
                {
                    d.Name,
                    d.Description,
                    d.ImageUri,
                });

                return Results.Ok(destinations);
            });
        }
    }
}