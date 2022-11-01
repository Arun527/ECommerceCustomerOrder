using ECommerceApi.RepositoryInterface;
using ECommerceApi.RepositoryService;
using ECommerceCustomerOrder.Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ECommmerceDbContext>(OPtions => OPtions.UseSqlServer(builder.Configuration.GetConnectionString("ConStr")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/CustomerMvc/Login";



            });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Cookies";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(3);
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ECommerceApi.RepositoryInterface.ICustomer, CustomerService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<IOrders, OrderService>();
builder.Services.AddScoped<IOrderDetail, OrderDetailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=CustomerMvc}/{action=Index}/{id?}");
});
app.MapRazorPages();

app.Run();
