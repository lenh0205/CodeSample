using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;

// being able to authenticate with an application means that application can indentify you

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// make an "IDataProtectionProvider" available - use for "Encryption" đảm bảo security cho cookie
builder.Services.AddDataProtection();

// sử dụng "AuthService"
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthService>();

// implementation của ASP.NET Core cho Authentication (ta có thể AuthService và middleware ta tự viết đi)
// Authentication Schema <=> who is authenticating you (in this case we will use the default schema "cookie")
builder.Services.AddAuthentication("cookie")
    .AddCookie("cookie"); // responsible for Loading up the Cookie, writing back the cookie, validate, split if it too big,...
                          // .Add...() - we can have JWT, OAuth, ....

app.UseAuthentication();


// manual Middleware equivalent to UseAuthentication() to check if there's an authentication cookie before arriving handler, actions,...
app.Use((ctx, next) =>
{
    var idp = ctx.RequestServices.GetRequiredService<IDataProtectionProvider>();
    var protector = idp.CreateProtector("auth-cookie");

    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
    var protectedPayload = authCookie?.Split("=").Last();
    var payload = protector.Unprotect(protectedPayload);
    var parts = payload?.Split(":");
    var key = parts[0];
    var value = parts[1];

    var claims = new List<Claim>
    {
        new Claim(key, value)
    };
    var identity = new ClaimsIdentity(claims); // must have to construct ClaimsPrincipal
    ctx.User = new ClaimsPrincipal(identity); // carry information about user Identity: email, phone number,...

    return next();
});

// -----------> Authentication có 2 phần cơ bản:

// 1. creating an Authentication Session
// "sign in"  -> issue cookie
app.MapGet("/login", (HttpContext ctx, IDataProtectionProvider idp) =>
{
    var protector = idp.CreateProtector("auth-cookie"); // tên "Protector" ngẫu nhiên dựa trên scenarios hiện tại
    ctx.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:Lee")}";

    return "Ok";
});

// 2. recognizing an Authentication Session
app.MapGet("/username", (HttpContext ctx, IDataProtectionProvider idp) =>
{
    var protector = idp.CreateProtector("auth-cookie");

    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
    var protectedPayload = authCookie?.Split("=").Last();
    var payload = protector.Unprotect(protectedPayload);
    var parts = payload?.Split(":");
    var key = parts[0];
    var value = parts[1];

    return value; // Lee
});


// -------> sử dụng AuthService và middleware của ta 
app.MapGet("/login", (AuthService auth) =>
{
    auth.SignIn();
    return "Ok";
});
app.MapGet("/username", (HttpContext ctx, IDataProtectionProvider idp) =>
{

    // "FindFirst" method to extracts a claim based on its type
    return ctx.User.FindFirst("usr").Value; // Lee
});


// ---------> sử dụng implementation của ASP.NET Core
app.MapGet("/login", async (HttpContext ctx) =>
{
    var claims = new List<Claim>
    {
        new Claim("usr", "Lee")
    };
    var identity = new ClaimsIdentity(claims, "cookie");
    var user = new ClaimsPrincipal(identity);

    await ctx.SignInAsync("cookie", new ClaimsPrincipal()); // schema and ClaimsPrinciple
    return "Ok";
});


app.Run();

// -----> Running:
// dotnet watch --no-hot-reload
// khi truy cập vào URL "..../login", response trả về sẽ có "set-cookie" header với giá trị là "auth=usr:Lee"
// trong DevTook -> Application -> Cookies ta cũng sẽ thấy cookie có "Name" là "auth" và "Value" là "usr:Lee"
// if we make further request, this cookie will be appended automatically 
// ngay tại tab trình duyệt đó, nếu ta reload hoặc đổi đường dẫn thành ".../username" ta sẽ thấy Request Header sẽ có "cookie: auth=usr:Lee"
// nhưng thế này không bảo mật vậy nên ta cần sự hỗ trợ của "DataProtection"


// ta sẽ có rất nhiều endpoint, vậy nên ta sẽ viết logic Auth thành 1 service:
public class AuthService
{
    private readonly IDataProtectionProvider _idp;
    private readonly IHttpContextAccessor _accessor;

    public AuthService(IDataProtectionProvider idp, IHttpContextAccessor accessor)
    {
        _idp = idp;
        _accessor = accessor;
    }
    public void SignIn()
    {
        var protector = _idp.CreateProtector("auth-cookie");
        _accessor.HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:Lee")}";
    }
}