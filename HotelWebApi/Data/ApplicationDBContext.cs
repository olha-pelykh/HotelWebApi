using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Data
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Entities.Hotel> Hotels { get; set; }
    }
}
