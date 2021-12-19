using Microsoft.EntityFrameworkCore;
using Trainer.DAL.EntityTypeConfigurations;

namespace Trainer.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PvExampleConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());
            modelBuilder.ApplyConfiguration(new WordTrackConfigurtion());
            modelBuilder.ApplyConfiguration(new WordExampleConfiguration());
            modelBuilder.ApplyConfiguration(new PhrasalVerbConfiguration());
            modelBuilder.ApplyConfiguration(new PvTrackConfiguration());
        }
    }
}
