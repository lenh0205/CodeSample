
// "role-based Authorization" is built up out of "policies" and "claims" (ta có thể thấy nó nếu đọc code của "UseAuthorization" middleware)

// vậy nên ta sẽ cần 2 thứ khi login:
// -> First, a claim which is going to represent a role 
// -> Second, the "role claim type" which is going to look for this specific claim

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddCookie("cookie");
builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
    
app.Run();


// ---------> Running:
// go to "/secret" will ge 404, because we haven't authorize so we will get redirected