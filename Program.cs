
using CSharpest.Classes;
using CSharpest.Services;

namespace CSharpest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Storefront.DisplayItems();
            System.Diagnostics.Debug.WriteLine("writing:");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRazorPages();

            //services must be defined here
            builder.Services.AddScoped<ItemService, ItemService>();
            builder.Services.AddScoped<CartService, CartService>();
            builder.Services.AddScoped<CardService, CardService>();
            builder.Services.AddScoped<CheckoutService, CheckoutService>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();


        }
    }
}