using SampleApi.Data;

namespace SampleApi.Endpoints;

public static class UserEndpoints
{
    public static void MapPersonEndpoints(this WebApplication app)
    {
        app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUserById);
    }

    private static IResult GetUsers(CourseData data, string search)
    {
        // var results = data.Users;
        var results = data.Users.Where(x => x.Name.First.Contains(search, StringComparison.OrdinalIgnoreCase)
                                       || x.Name.Last.Contains(search, StringComparison.OrdinalIgnoreCase));

        if (results is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(results);
    }

    private static IResult GetUserById(CourseData data, string id)
    {
        var results = data.Users.FirstOrDefault(x => x.Id.Value == id);

        if (results is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(results);
    }
}
