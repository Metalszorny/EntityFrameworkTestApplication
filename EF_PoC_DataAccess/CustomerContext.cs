using System;
using System.Data.Entity;
using EF_PoC_Customer;

namespace EF_PoC_DataAccess
{
    /// <summary>
    /// Interaction logic for CustomerContext.
    /// </summary>
    public class CustomerContext : DbContext
    {
        #region Fields

        private volatile Type _dependency;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the Customers.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Addresses.
        /// </summary>
        public virtual DbSet<Address> Addresses { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerContext"/> class.
        /// </summary>
        public CustomerContext()
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        public CustomerContext(string connectionString)
            : base(connectionString)
        {
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// On model creating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region FluentAPI

            #region MapEntityToTable

            // Map Customer entity to Customers table.
            modelBuilder.Entity<Customer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
            });

            // Map Address entity to Addresses table.
            modelBuilder.Entity<Address>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Addresses");
            });

            #endregion MapEntityToTable

            #region ConfigurePrimaryKey

            // Configure Customer primary key.
            modelBuilder.Entity<Customer>().HasKey<Guid>(s => s.Id);

            // Configure Address primary key.
            modelBuilder.Entity<Address>().HasKey<Guid>(s => s.Id);

            #endregion ConfigurePrimaryKey

            #region ConfigureForeignKey

            // Configure foreign key fpr one-to-many relationship.
            //modelBuilder.Entity<Address>()
            //            .HasOptional<Customer>(s => s.Customer)
            //            .WithMany(s => s.CustomerAddresses)
            //            .HasForeignKey(s => s.CustomerId);

            #endregion ConfigureForeignKey

            #region ConfigureColumns

            #region ConfigureCustomersColumns

            // Configure Customers columns
            modelBuilder.Entity<Customer>()
                .Property(p => p.Id)
                .HasColumnName("CustomerId")
                .HasColumnOrder(1)
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            modelBuilder.Entity<Customer>()
                .Property(p => p.CustomerName)
                .HasColumnName("CustomerName")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();
            modelBuilder.Entity<Customer>()
                .Property(p => p.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnOrder(3)
                .HasColumnType("bit");
            modelBuilder.Entity<Customer>()
                .Property(p => p.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnOrder(4)
                .HasColumnType("datetime");
            modelBuilder.Entity<Customer>()
                .Property(p => p.ModificationDate)
                .HasColumnName("ModificationDate")
                .HasColumnOrder(5)
                .HasColumnType("datetime");
            modelBuilder.Entity<Customer>()
                .Property(p => p.RowId)
                .HasColumnName("RowId")
                .HasColumnOrder(6)
                .HasColumnType("int");

            #endregion ConfigureCustomerColumns

            #region ConfigureAddressesColumns

            // Configure Addresses columns
            modelBuilder.Entity<Address>()
                .Property(p => p.Id)
                .HasColumnName("AddressId")
                .HasColumnOrder(1)
                .HasColumnType("uniqueidentifier")
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(p => p.CountryName)
                .HasColumnName("CountryName")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();
            modelBuilder.Entity<Address>()
                .Property(p => p.ZipCode)
                .HasColumnName("ZipCode")
                .HasColumnOrder(3)
                .HasColumnType("int");
            modelBuilder.Entity<Address>()
                .Property(p => p.CityName)
                .HasColumnName("CityName")
                .HasColumnOrder(4)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();
            modelBuilder.Entity<Address>()
                .Property(p => p.DistrictNumber)
                .HasColumnName("DistrictNumber")
                .HasColumnOrder(5)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();
            modelBuilder.Entity<Address>()
                .Property(p => p.StreetName)
                .HasColumnName("StreetName")
                .HasColumnOrder(6)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();
            modelBuilder.Entity<Address>()
                .Property(p => p.HouseNumber)
                .HasColumnName("HouseNumber")
                .HasColumnOrder(7)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();
            modelBuilder.Entity<Address>()
                .Property(p => p.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnOrder(8)
                .HasColumnType("bit");
            modelBuilder.Entity<Address>()
                .Property(p => p.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnOrder(9)
                .HasColumnType("datetime");
            modelBuilder.Entity<Address>()
                .Property(p => p.ModificationDate)
                .HasColumnName("ModificationDate")
                .HasColumnOrder(10)
                .HasColumnType("datetime");
            modelBuilder.Entity<Address>()
                .Property(p => p.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnOrder(11)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            #endregion ConfigureAddressColumns

            #endregion ConfigureColumns

            #endregion FluentAPI
        }

        #endregion Methods

        #region Comment

        // Your context has been configured to use a 'CustomerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EF_PoC_DataAccess.CustomerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomerContext' 
        // connection string in the application configuration file.
        //public CustomerContext()
        //    : base("name=CustomerContext.cs")
        //{
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        #endregion Comment
    }

    #region Comment

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    #endregion Comment
}