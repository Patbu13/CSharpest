using CSharpest.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Identity.Client;



public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<ItemModel> items { get; set; }

    public DbSet<BundleModel> bundles { get; set; }
    
    public DbSet<CartItemModel> cartItems { get; set; }
    
    public DbSet<CartModel> carts { get; set; }
    
    public DbSet<CustomerModel> customers { get; set; }
    
    public DbSet<OrderModel> orders { get; set; }
    
    public DbSet<OrderDetailModel> orderDetails { get; set; }
    
    public DbSet<CardModel> cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemModel>().HasKey(x => x.Id);
        modelBuilder.Entity<BundleModel>().HasKey(x => x.Id);
        modelBuilder.Entity<CartItemModel>().HasKey(x => x.Id);
        modelBuilder.Entity<CartModel>().HasKey(x => x.Id);
        modelBuilder.Entity<CustomerModel>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderDetailModel>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderModel>().HasKey(x => x.Id);
        modelBuilder.Entity<CardModel>().HasKey(x => x.Number);
        // Other configurations...
    }

}