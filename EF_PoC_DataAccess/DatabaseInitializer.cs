

namespace EF_PoC_DataAccess
{
    /// <summary>
    /// Interaction logic for DatabaseInitializer.
    /// </summary>
    public class DatabaseInitializer
    {
        #region Fields

        // The connectionString to the database.
        private const string connectionString = @"Server=(LocalDb)\v11.0;Database=CustomerDatabase;integrated security=True;data source=SNQL-WORK\;initial catalog=EF_PoC_DataAccess;user=SNQL-WORK\Admin;password=";

        // Connect to customerContext.
        CustomerContext customerContext = new CustomerContext(connectionString);

        #endregion Fields

        #region Methods

        /// <summary>
        /// Database exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string DatabaseExists()
        {
            if (!customerContext.Database.Exists())
            {
                try
                {
                    customerContext.Database.Create();
                    return "ok";
                }
                catch
                {
                    return "error";
                }
            }

            return "exists";
        }

        /// <summary>
        /// Address table exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string AddressTableExists()
        {
            try
            {
                var temp = customerContext.Addresses.SqlQuery("Select * from Addresses");

                if (temp == null)
                {
                    return "seed";
                }

                return "exists";
            }
            catch
            {
                return "error";
            }
        }

        /// <summary>
        /// Customer table exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string CustomerTableExists()
        {
            try
            {
                var temp = customerContext.Customers.SqlQuery("Select * from Customers");

                if (temp == null)
                {
                    return "seed";
                }

                return "exists";
            }
            catch
            {
                return "error";
            }
        }

        /// <summary>
        /// Check database.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CheckDatabase()
        {
            if (customerContext.Database.Exists())
            {
                // The database exists.
                if (customerContext.Addresses.Local.Count > 0)
                {
                    // The Address table exists.
                    if (customerContext.Customers.Local.Count > 0)
                    {
                        // The Customers table exists.
                        return true;
                    }
                    else
                    {
                        // The Customer table doesn't exist.
                        try
                        {
                            // Create the Customers table.
                            customerContext.Customers.Create();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    // The Addresses table doesn't exist.
                    try
                    {
                        // Create the Addresses table.
                        customerContext.Addresses.Create();

                        if (customerContext.Customers.Local.Count > 0)
                        {
                            // The Customers table exists.
                            return true;
                        }
                        else
                        {
                            // The Customers table doesn't exist.
                            try
                            {
                                // Create the Customers table.
                                customerContext.Customers.Create();
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            else
            {
                // The database doesn't exist.
                try
                {
                    // Create the database.
                    customerContext.Database.Create();

                    if (customerContext.Addresses.Local.Count > 0)
                    {
                        // The Addresses table exists.
                        if (customerContext.Customers.Local.Count > 0)
                        {
                            // The Customers table exists.
                            return true;
                        }
                        else
                        {
                            // The Customers table doesn't exist.
                            try
                            {
                                // Create the Customers table.
                                customerContext.Customers.Create();
                                return true;
                            }
                            catch
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // The Addresses table doesn't exist.
                        try
                        {
                            // Create the Addresses table.
                            customerContext.Addresses.Create();

                            if (customerContext.Customers.Local.Count > 0)
                            {
                                // The Customers table exists.
                                return true;
                            }
                            else
                            {
                                // The Customers table doesn't exists.
                                try
                                {
                                    // Create the Customers table.
                                    customerContext.Customers.Create();
                                    return true;
                                }
                                catch
                                {
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion Methods
    }
}
