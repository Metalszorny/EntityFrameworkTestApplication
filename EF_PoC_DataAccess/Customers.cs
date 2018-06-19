using System;
using System.Collections.Generic;
using System.Linq;
using EF_PoC_Customer;
using System.Data.Entity.Core.Objects;

namespace EF_PoC_DataAccess
{
    /// <summary>
    /// Interaction logic for Customers.
    /// </summary>
    public class Customers
    {
        #region Fields

        // The database connectionString.
        private const string connectionString = @"Server=(LocalDb)\v11.0;Database=CustomerDatabase;integrated security=True;data source=SNQL-WORK\;initial catalog=EF_PoC_DataAccess;user=SNQL-WORK\Admin;password=";

        // Connect to customerContext.
        private CustomerContext customerContext = new CustomerContext(connectionString);

        #endregion Fields

        #region Methods

        #region Add

        /// <summary>
        /// Adds a Customer.
        /// </summary>
        /// <param name="input">The Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddCustomer(Customer input)
        {
            try
            {
                // Create Customer and set times.
                Customer customer = new Customer(input.CustomerName, false);
                customer.CreationDate = DateTime.Now;
                customer.ModificationDate = DateTime.Now;

                // Add the new record.
                customerContext.Customers.Add(customer);

                // Update table.
                customerContext.SaveChanges();

                return true;
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
        public bool AddAddress(Address input)
        {
            try
            {
                // Create Address and set times.
                Address address = new Address(input.CountryName, input.ZipCode, input.CityName, input.DistrictNumber, input.StreetName, input.HouseNumber, false, input.Customer);
                address.CreationDate = DateTime.Now;
                address.ModificationDate = DateTime.Now;

                // Add the new record.
                customerContext.Addresses.Add(address);

                // Update table.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds both.
        /// </summary>
        /// <param name="input">The Address with Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        public bool AddBoth(Address input)
        {
            try
            {
                // Create Customer and set times.
                Customer customer = new Customer(input.Customer.CustomerName, false);
                customer.CreationDate = DateTime.Now;
                customer.ModificationDate = DateTime.Now;

                // Create Address and set times.
                Address address = new Address(input.CountryName, input.ZipCode, input.CityName, input.DistrictNumber, input.StreetName, input.HouseNumber, false, customer);
                address.CreationDate = DateTime.Now;
                address.ModificationDate = DateTime.Now;

                // Add the new records.
                customerContext.Customers.Add(customer);
                customerContext.Addresses.Add(address);

                // Update the tables.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Adds seed data.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool AddSeed()
        {
            try
            {
                // Create Customer seed data.
                Customer customer1 = new Customer("Géza", false);
                Customer customer2 = new Customer("Éva", false);
                Customer customer3 = new Customer("Béla", true);

                // Set Customer seed data times.
                customer1.CreationDate = DateTime.Now;
                customer1.ModificationDate = DateTime.Now;
                customer1.RowId = Customer.RowType.User;
                customer2.CreationDate = DateTime.Now;
                customer2.ModificationDate = DateTime.Now;
                customer2.RowId = Customer.RowType.Operator;
                customer3.CreationDate = DateTime.Now;
                customer3.ModificationDate = DateTime.Now;
                customer3.RowId = Customer.RowType.VIP;

                // Create Address seed data.
                Address address1 = new Address("Hungary", 1142, "Budapest", "14", "Erzsébet királynő útja", "125/3.303", false, customer1);
                Address address2 = new Address("Hungary", 1142, "Budapest", "14", "Erzsébet királynő útja", "125/3.302-304", false, customer2);

                // Set Address seed data times.
                address1.CreationDate = DateTime.Now;
                address1.ModificationDate = DateTime.Now;
                address2.CreationDate = DateTime.Now;
                address2.ModificationDate = DateTime.Now;

                // Add seed to Customers table if no records were found.
                if (customerContext.Customers.Local.Count == 0)
                {
                    customerContext.Customers.Add(customer1);
                    customerContext.Customers.Add(customer2);
                    customerContext.Customers.Add(customer3);
                }

                // Add seed to Addresses table if no records were found.
                if (customerContext.Addresses.Local.Count == 0)
                {
                    customerContext.Addresses.Add(address1);
                    customerContext.Addresses.Add(address2);
                }

                // Update the tables.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Add

        #region Delete

        /// <summary>
        /// Deletes a Customer.
        /// </summary>
        /// <param name="input">The Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteCustomer(Guid input)
        {
            try
            {
                // Find the Customer.
                Customer customer = customerContext.Customers.FirstOrDefault(x => x.Id == input);

                // Edit the IsDeleted to true.
                customer.IsDeleted = true;
                customer.ModificationDate = DateTime.Now;

                // Update the table.
                customerContext.SaveChanges();

                return true;
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
                // Find the Address.
                Address address = customerContext.Addresses.FirstOrDefault(x => x.Id == input);

                // Edit the IsDeleted to true.
                address.IsDeleted = true;
                address.ModificationDate = DateTime.Now;

                // Update the table.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes both.
        /// </summary>
        /// <param name="input">The Address to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteBoth(Guid input)
        {
            try
            {
                // Find the Address.
                Address address = customerContext.Addresses.FirstOrDefault(x => x.Id == input);

                // Edit the IsDeleted to true.
                address.IsDeleted = true;
                address.ModificationDate = DateTime.Now;

                // Update the table.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Delete

        #region List

        /// <summary>
        /// Lists the Customers table.
        /// </summary>
        /// <returns>The list of Customers or null.</returns>
        public EF_PoC_Customer.Customers ListCustomer()
        {
            try
            {
                // Turn off proxy creation.
                customerContext.Configuration.ProxyCreationEnabled = false;

                // List table.
                EF_PoC_Customer.Customers retVal = new EF_PoC_Customer.Customers();
                foreach (var oneItem in customerContext.Customers.ToList())
                {
                    retVal.Items.Add(oneItem);
                }

                return retVal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lists the Addresses table.
        /// </summary>
        /// <returns>The list of Addresses or null.</returns>
        public Addresses ListAddress()
        {
            try
            {
                // Turn off proxy creation.
                customerContext.Configuration.ProxyCreationEnabled = false;

                // List table.
                Addresses retVal = new Addresses();
                foreach (var oneItem in customerContext.Addresses.ToList())
                {
                    retVal.Items.Add(oneItem);
                }

                return retVal;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Lists both.
        /// </summary>
        /// <returns>The list of Addresses with Customers.</returns>
        public Addresses ListBoth()
        {
            try
            {
                // Turn off proxy creation.
                customerContext.Configuration.ProxyCreationEnabled = false;

                // List tables.
                List<Address> addressList = customerContext.Addresses.ToList();
                List<Customer> customerList = customerContext.Customers.ToList();
                Addresses addressCollction = new Addresses();

                // Link lists in one list.
                foreach (var oneItem in addressList)
                {
                    Address newAddress = new Address();

                    if (oneItem.Customer == null)
                    {
                        for (int i = 0; i < customerList.Count; i++)
                        {
                            if (customerList[i].Id == oneItem.CustomerId)
                            {
                                newAddress = new Address(oneItem.CountryName, oneItem.ZipCode, oneItem.CityName, oneItem.DistrictNumber, oneItem.StreetName, oneItem.HouseNumber, oneItem.IsDeleted, customerList[i]);
                            }
                        }
                    }
                    else
                    {
                        newAddress = new Address(oneItem.CountryName, oneItem.ZipCode, oneItem.CityName, oneItem.DistrictNumber, oneItem.StreetName, oneItem.HouseNumber, oneItem.IsDeleted, oneItem.Customer);
                    }

                    addressCollction.Add(newAddress);
                }

                return addressCollction;
            }
            catch
            {
                return null;
            }
        }

        #endregion List

        #region Modify

        /// <summary>
        /// Edits a Customer.
        /// </summary>
        /// <param name="oldinput">The Customer to edit.</param>
        /// <param name="newinput">The Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyCustomer(Guid oldinput, Customer newinput)
        {
            try
            {
                // Find the Customer.
                Customer customer = customerContext.Customers.FirstOrDefault(x => x.Id == oldinput);

                // Edit the culomns.
                customer.CustomerName = newinput.CustomerName;
                customer.ModificationDate = DateTime.Now;

                // Update the table.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits an Address.
        /// </summary>
        /// <param name="oldinput">The Address ti edit.</param>
        /// <param name="newinput">The Address to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyAddress(Guid oldinput, Address newinput)
        {
            try
            {
                // Find the Address.
                Address address = customerContext.Addresses.FirstOrDefault(x => x.Id == oldinput);

                // Edit the culomns.
                address.CountryName = newinput.CountryName;
                address.ZipCode = newinput.ZipCode;
                address.CityName = newinput.CityName;
                address.DistrictNumber = newinput.DistrictNumber;
                address.StreetName = newinput.StreetName;
                address.HouseNumber = newinput.HouseNumber;
                address.CustomerId = newinput.CustomerId;
                address.ModificationDate = DateTime.Now;

                // Update the table.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Edits both.
        /// </summary>
        /// <param name="oldinputAddress">The Address to edit.</param>
        /// <param name="oldinputCustomer">The Customer to edit.</param>
        /// <param name="newinput">The Address with Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyBoth(Guid oldinputAddress, Guid oldinputCustomer, Address newinput)
        {
            try
            {
                // Find the Customer.
                Customer customer = customerContext.Customers.FirstOrDefault(x => x.Id == oldinputCustomer);

                // Edit the culomns.
                customer.CustomerName = newinput.Customer.CustomerName;
                customer.ModificationDate = DateTime.Now;

                // Find the Address.
                Address address = customerContext.Addresses.FirstOrDefault(x => x.Id == oldinputAddress);

                // Edit the culomns.
                address.CountryName = newinput.CountryName;
                address.ZipCode = newinput.ZipCode;
                address.CityName = newinput.CityName;
                address.DistrictNumber = newinput.DistrictNumber;
                address.StreetName = newinput.StreetName;
                address.HouseNumber = newinput.HouseNumber;
                address.CustomerId = newinput.Customer.Id;
                address.ModificationDate = DateTime.Now;

                // Update the tables.
                customerContext.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Modify

        #region Create

        /// <summary>
        /// Creates the Customers table.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CreateCustomer()
        {
            try
            {
                customerContext.Customers.Create();
                return true;
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
                customerContext.Addresses.Create();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool CreateDatabase()
        {
            try
            {
                customerContext.Database.Create();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Create

        #region Find

        /// <summary>
        /// Finds a single Customer.
        /// </summary>
        /// <param name="primarykey">The Customer to find.</param>
        /// <returns>A Customer object or null.</returns>
        public Customer FindSingleCustomer(Guid primarykey)
        {
            try
            {
                customerContext.Configuration.AutoDetectChangesEnabled = false;
                Customer query = customerContext.Customers.Find(primarykey);
                customerContext.Configuration.AutoDetectChangesEnabled = true;

                if (query != null)
                {
                    return query;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Finds a single Address.
        /// </summary>
        /// <param name="primarykey">The Address to find.</param>
        /// <returns>An Address object or null.</returns>
        public Address FindSingleAddress(Guid primarykey)
        {
            try
            {
                customerContext.Configuration.AutoDetectChangesEnabled = false;
                Address query = customerContext.Addresses.Find(primarykey);
                customerContext.Configuration.AutoDetectChangesEnabled = true;

                if (query != null)
                {
                    return query;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion Find

        /// <summary>
        /// Database exists.
        /// </summary>
        /// <returns>The outcome of the method.</returns>
        public bool DatabaseExists()
        {
            try
            {
                if (customerContext.Database.Exists())
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods
    }
}
