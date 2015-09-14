using System;
using EF_PoC_DataAccess;

namespace EF_PoC_BusinessLogic
{
    /// <summary>
    /// Interaction logic for Customers.
    /// </summary>
    public class Customers
    {
        #region Fields

        // Connection to dataAccess.
        private EF_PoC_DataAccess.Customers dataAccess = new EF_PoC_DataAccess.Customers();

        // Connection to dataInitializer.
        private DatabaseInitializer dataInitializer = new DatabaseInitializer();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Checks the database.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool DbInitializer()
        {
            try
            {
                return dataInitializer.CheckDatabase();
            }
            catch
            {
                return false;
            }
        }

        #region Exists

        /// <summary>
        /// Database exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string DbExists()
        {
            try
            {
                return dataInitializer.DatabaseExists();
            }
            catch
            {
                return "no";
            }
        }

        /// <summary>
        /// Addresses table exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string AddressesExists()
        {
            try
            {
                return dataInitializer.AddressTableExists();
            }
            catch
            {
                return "no";
            }
        }

        /// <summary>
        /// Customers table exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public string CustomersExists()
        {
            try
            {
                return dataInitializer.CustomerTableExists();
            }
            catch
            {
                return "no";
            }
        }

        /// <summary>
        /// Database exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool DatabaseExists()
        {
            try
            {
                return dataAccess.DatabaseExists();
            }
            catch
            {
                return false;
            }
        }

        #endregion Exists

        #region Add

        /// <summary>
        /// Adds both.
        /// </summary>
        /// <param name="input">The Address with Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddBoth(EF_PoC_Customer.Address input)
        {
            try
            {
                return dataAccess.AddBoth(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds a Customer.
        /// </summary>
        /// <param name="input">The Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddCustomer(EF_PoC_Customer.Customer input)
        {
            try
            {
                return dataAccess.AddCustomer(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds an Address.
        /// </summary>
        /// <param name="input">The Address to add.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddAddress(EF_PoC_Customer.Address input)
        {
            try
            {
                return dataAccess.AddAddress(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds seed.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool AddSeed()
        {
            try
            {
                return dataAccess.AddSeed();
            }
            catch
            {
                return false;
            }
        }

        #endregion Add

        #region List

        /// <summary>
        /// Lists both.
        /// </summary>
        /// <returns>The list of Addresses with Customers or null.</returns>
        public EF_PoC_Customer.Addresses ListBoth()
        {
            try
            {
                return dataAccess.ListBoth();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lists the Customers.
        /// </summary>
        /// <returns>The list of Customers or null.</returns>
        public EF_PoC_Customer.Customers ListCustomer()
        {
            try
            {
                return dataAccess.ListCustomer();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lists the Addresses.
        /// </summary>
        /// <returns>The list of Address or null.</returns>
        public EF_PoC_Customer.Addresses ListAddress()
        {
            try
            {
                return dataAccess.ListAddress();
            }
            catch
            {
                return null;
            }
        }

        #endregion List

        #region Delete

        /// <summary>
        /// Deletes both.
        /// </summary>
        /// <param name="input">The Address with Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteBoth(Guid input)
        {
            try
            {
                return dataAccess.DeleteBoth(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a Customer.
        /// </summary>
        /// <param name="input">The Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteCustomer(Guid input)
        {
            try
            {
                return dataAccess.DeleteCustomer(input);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes an Address.
        /// </summary>
        /// <param name="input">The Address to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteAddress(Guid input)
        {
            try
            {
                return dataAccess.DeleteAddress(input);
            }
            catch
            {
                return false;
            }
        }

        #endregion Delete

        #region Modify

        /// <summary>
        /// Edits both.
        /// </summary>
        /// <param name="oldinputAddress">The Address with Customer to edit.</param>
        /// <param name="oldinputCustomer">The Address with Customer to edit with.</param>
        /// <param name="newinput"></param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyBoth(Guid oldinputAddress, Guid oldinputCustomer, EF_PoC_Customer.Address newinput)
        {
            try
            {
                return dataAccess.ModifyBoth(oldinputAddress, oldinputCustomer, newinput);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits a Customer.
        /// </summary>
        /// <param name="oldinput">The Customer to edit.</param>
        /// <param name="newinput">The Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyCustomer(Guid oldinput, EF_PoC_Customer.Customer newinput)
        {
            try
            {
                return dataAccess.ModifyCustomer(oldinput, newinput);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits an Address.
        /// </summary>
        /// <param name="oldinput">The Address to edit.</param>
        /// <param name="newinput">The Address to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyAddress(Guid oldinput, EF_PoC_Customer.Address newinput)
        {
            try
            {
                return dataAccess.ModifyAddress(oldinput, newinput);
            }
            catch
            {
                return false;
            }
        }

        #endregion Modify

        #region Create

        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CreateDatabase()
        {
            try
            {
                return dataAccess.CreateDatabase();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates the Addresses table.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CreateAddress()
        {
            try
            {
                return dataAccess.CreateAddress();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates the Customers table.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CreateCustomer()
        {
            try
            {
                return dataAccess.CreateCustomer();
            }
            catch
            {
                return false;
            }
        }

        #endregion Create

        #endregion Methods
    }
}
