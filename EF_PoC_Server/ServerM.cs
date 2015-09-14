using System;
using System.ServiceModel;
using EF_PoC_Customer;

namespace EF_PoC_Server
{
    /// <summary>
    /// Interaction logic for ServerM.
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ServerM : IServerM
    {
        #region Fields

        // Connect to BusineccLogic.
        private EF_PoC_BusinessLogic.Customers businessLogic = new EF_PoC_BusinessLogic.Customers();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Event report.
        /// </summary>
        /// <param name="reportMessage">The report message.</param>
        public void Report(string reportMessage)
        {
            Console.WriteLine("[" + DateTime.Now.Year.ToString("0000") + "." + DateTime.Now.Month.ToString("00") + "." + DateTime.Now.Day.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00") + "] " + reportMessage);
        }

        /// <summary>
        /// Server status.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The outcome of the method.</returns>
        public string Login(string input)
        {
            // React only for test input.
            if (input == "test")
            {
                Report(input + " user successfully logged in.");
                return "test";
            }

            Report("Unsuccessful login from user: " + input + ".");
            return "";
        }

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
                if (businessLogic.AddCustomer(input))
                {
                    Report("Add succeeded.");
                    return true;
                }

                Report("Add failed.");
                return false;
            }
            catch
            {
                Report("Add failed.");
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
                if (businessLogic.AddAddress(input))
                {
                    Report("Add succeeded.");
                    return true;
                }

                Report("Add failed.");
                return false;
            }
            catch
            {
                Report("Add failed.");
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
                if (businessLogic.AddBoth(input))
                {
                    Report("Add succeeded.");
                    return true;
                }

                Report("Add failed.");
                return false;
            }
            catch
            {
                Report("Add failed.");
                return false;
            }
        }

        #endregion Add

        #region List

        /// <summary>
        /// Lists the Addresses.
        /// </summary>
        /// <returns>The list of Addresses or null.</returns>
        public Addresses ListAddress()
        {
            try
            {
                Addresses retVal = businessLogic.ListAddress();

                if (retVal != null)
                {
                    Report("List succeeded.");
                    return retVal;
                }

                Report("List failed.");
                return null;
            }
            catch
            {
                Report("List failed.");
                return null;
            }
        }

        /// <summary>
        /// Lists both.
        /// </summary>
        /// <returns>The list of Addresses with Customers or null.</returns>
        public Addresses ListBoth()
        {
            try
            {
                Addresses retVal = businessLogic.ListBoth();

                if (retVal != null)
                {
                    Report("List succeeded.");
                    return retVal;
                }

                Report("List failed.");
                return null;
            }
            catch
            {
                Report("List failed.");
                return null;
            }
        }

        /// <summary>
        /// Lists the Customers.
        /// </summary>
        /// <returns>The list of Customers or null</returns>
        public Customers ListCustomer()
        {
            try
            {
                Customers retVal = businessLogic.ListCustomer();

                if (retVal != null)
                {
                    Report("List succeeded.");
                    return retVal;
                }

                Report("List failed.");
                return null;
            }
            catch
            {
                Report("List failed.");
                return null;
            }
        }

        #endregion List

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
                if (businessLogic.DeleteCustomer(input))
                {
                    Report("Delete succeeded.");
                    return true;
                }

                Report("Delete failed.");
                return false;
            }
            catch
            {
                Report("Delete failed.");
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
                if (businessLogic.DeleteAddress(input))
                {
                    Report("Delete succeeded.");
                    return true;
                }

                Report("Delete failed.");
                return false;
            }
            catch
            {
                Report("Delete failed.");
                return false;
            }
        }

        /// <summary>
        /// Deletes both.
        /// </summary>
        /// <param name="input">The Address with Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        public bool DeleteBoth(Guid input)
        {
            try
            {
                if (businessLogic.DeleteBoth(input))
                {
                    Report("Delete succeeded.");
                    return true;
                }

                Report("Delete failed.");
                return false;
            }
            catch
            {
                Report("Delete failed.");
                return false;
            }
        }

        #endregion Delete

        #region Modify

        /// <summary>
        /// Modifies a Customer.
        /// </summary>
        /// <param name="oldinput">The Customer to edit.</param>
        /// <param name="newinput">The Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyCustomer(Guid oldinput, Customer newinput)
        {
            try
            {
                if (businessLogic.ModifyCustomer(oldinput, newinput))
                {
                    Report("Modify succeeded.");
                    return true;
                }

                Report("Modify failed.");
                return false;
            }
            catch
            {
                Report("Modify failed.");
                return false;
            }
        }

        /// <summary>
        /// Modifies an Address.
        /// </summary>
        /// <param name="oldinput">The Address to edit.</param>
        /// <param name="newinput">The Address to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyAddress(Guid oldinput, Address newinput)
        {
            try
            {
                if (businessLogic.ModifyAddress(oldinput, newinput))
                {
                    Report("Modify succeeded.");
                    return true;
                }

                Report("Modify failed.");
                return false;
            }
            catch
            {
                Report("Modify failed.");
                return false;
            }
        }

        /// <summary>
        /// Modifies both.
        /// </summary>
        /// <param name="oldinputAddress">The Address to edit.</param>
        /// <param name="oldinputCustomer">The Customer to edit.</param>
        /// <param name="newinput">The Address with Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        public bool ModifyBoth(Guid oldinputAddress, Guid oldinputCustomer, Address newinput)
        {
            try
            {
                if (businessLogic.ModifyBoth(oldinputAddress, oldinputCustomer, newinput))
                {
                    Report("Modify succeeded.");
                    return true;
                }

                Report("Modify failed.");
                return false;
            }
            catch
            {
                Report("Modify failed.");
                return false;
            }
        }

        #endregion Modify

        #endregion Methods
    }
}
