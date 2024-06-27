
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// compare to the past, the main difference Authorization in .NET 7 is using "claim" instead of "role"
// to be authorize, must "authenticated" with expected "scheme" first
// then we add "additional claims" onto "users" and then check those claims (check "claim principle") on "specific endpoint"

const string AuthScheme = "cookie";
const string AuthScheme2 = "cookie2";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(AuthScheme)
    .AddCookie(AuthScheme)
    .AddCookie(AuthScheme2);

var app = builder.Build();

app.UseAuthentication();

// -----------> basic authorize:
app.MapGet("/unsecure", (HttpContext ctx) =>
{
    return ctx.User.FindFirst("usr")?.Value ?? "empty";
});
app.MapGet("/sweden", (HttpContext ctx) =>
{
    if (!ctx.User.Identities.Any(x => x.AuthenticationType == AuthScheme))
    {
        ctx.Response.StatusCode = 401;
        return "";
    }
    if (!ctx.User.HasClaim("passport_type", "eur"))
    {
        ctx.Response.StatusCode = 403;
        return "";
    }
    return "allowed";
});
app.MapGet("/login", async (HttpContext ctx) =>
{
    var claims = new List<Claim>();
    claims.Add(new Claim("usr", "Lee"));
    claims.Add(new Claim("passport_type", "eur"));

    var identity = new ClaimsIdentity(claims, AuthScheme);
    var user = new ClaimsPrincipal(identity);
    await ctx.SignInAsync(AuthScheme, user);
});


// ----------> Running:
// first, visit "/sweden we will get the "401" response - not authenticated
// then, visit "/login" for website to have "authenticated" cookie
// Now, visit "/sweden" we will get "allowed" on UI


// ----------> extend: many combinations
app.MapGet("/norway", (HttpContext ctx) =>
{
    if (!ctx.User.Identities.Any(x => x.AuthenticationType == AuthScheme)) // same authen
    {
        ctx.Response.StatusCode = 401;
        return "";
    }
    if (!ctx.User.HasClaim("passport_type", "NOR")) // different author
    {
        ctx.Response.StatusCode = 403;
        return "";
    }
    return "allowed";
});
app.MapGet("/denmark", (HttpContext ctx) =>
{
    if (!ctx.User.Identities.Any(x => x.AuthenticationType == AuthScheme2)) // different authen
    {
        ctx.Response.StatusCode = 401;
        return "";
    }
    if (!ctx.User.HasClaim("passport_type", "eur")) // same author
    {
        ctx.Response.StatusCode = 403;
        return "";
    }
    return "allowed";
});


// -----------> create "authorization" middleware for one time check
// check if the "claim" in request against the required one in endpoint atrribute
app.Use((ctx, next) =>
{
    if (ctx.Request.Path.StartsWithSegments("/login"))
    {
        return next();
    }
    if (!ctx.User.Identities.Any(x => x.AuthenticationType == AuthScheme2))
    {
        ctx.Response.StatusCode = 401;
        return Task.CompletedTask;
    }
    if (!ctx.User.HasClaim("passport_type", "eur")) // same author
    {
        ctx.Response.StatusCode = 403;
        return Task.CompletedTask;
    }
    return next();
});

// -----------> create a service will understand if endpoint require a specific "authentication sheme"
// through "reflection" - at application startup to validate "claim":
// [AuthScheme(AuthScheme2)] -----> attribute using reflection to require specific "scheme" (VD: AuthScheme2 in this case)
// [AuthClaim("passport_type", "eur")] ------> attribute using reflection to require author
app.MapGet("/denmark", (HttpContext ctx) =>
{
    return "allowed";
});

// ----------> Running:
// first navigate to "/denmark", we will get 401
// navigate to "/login" than navigate to "/denmark", we get "allowed"


// -----------> using built-in middleware of ASP.NET

// configuration layer to defines rules for building up "policy"
// a policy - describes what a user should look like to reach 
builder.Services.AddAuthorization(builder =>
{
    // specify policies
    builder.AddPolicy("eu passport", pb => // define a "eu passport" policy
    { // policy builder implements a fluent API allow us to build up the rules which we want for this policy
        pb.RequireAuthenticatedUser()
        .AddAuthenticationSchemes(AuthScheme)
        .AddRequirements()// for custom flow of authorization process: asynchronous; communicate with database, cache; ....
        .RequireClaim("passport_type", "eur");
    });
});

// middleware
app.UseAuthorization();

// Usage
app.MapGet("/unsecure", (HttpContext ctx) =>
{
    return ctx.User.FindFirst("usr")?.Value ?? "empty";
}).RequireAuthorization("eu passport");
// khi request chạy tới "UseAuthorization" middleware sẽ được invoke
// nó sẽ sử dụng reflection để lấy những require authorization, register policy trên endpoint này 

app.MapGet("/sweden", async (HttpContext ctx) =>
{
    return "allowed";
}).AllowAnonymous(); // this endpoint can always be reach by unauthenticated users

// ----------> Running:



app.Run();


// Marking a class to parameterize our authentication handler
public class MyRequirement : IAuthorizationRequirement { }

public class MyRequirementHandler : AuthorizationHandler<MyRequirement>
{
    public MyRequirementHandler()
    {
        // DI some service
        // to communicate with database, cache,...
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
    {
        // context.User -----> reach the user
        // context.Success(new MyRequirement()); -----> for notify sucess
        return Task.CompletedTask;
    }
}