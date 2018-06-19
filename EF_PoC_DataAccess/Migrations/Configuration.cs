using System.Data.Entity.Migrations;

namespace EF_PoC_DataAccess.Migrations
{
	/// <summary>
    /// Interaction logic for Configuration.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CustomerContext>
    {
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Configuration"/> class.
		/// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
		
		/// <summary>
		/// Destroys the instance of the <see cref="Configuration"/> class.
		/// </summary>
        ~Configuration()
        { }
		
		#endregion Constructors

		#region Methods
		
		/// <summary>
		/// Inserts seed data to the database.
		/// </summary>
		/// <param name="context">The database context.</param>
        protected override void Seed(CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
		
		#endregion Methods
    }
}