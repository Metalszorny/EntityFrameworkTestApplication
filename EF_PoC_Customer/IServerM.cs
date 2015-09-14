using System;
using System.ServiceModel;

namespace EF_PoC_Customer
{
    /// <summary>
    /// Interaction logic for IServerM.
    /// </summary>
    [ServiceContract()]
    public interface IServerM
    {
        #region Methods

        /// <summary>
        /// Server status.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        string Login(string input);

        #region Add

        /// <summary>
        /// Adds both.
        /// </summary>
        /// <param name="input">The Address with Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool AddBoth(Address input);

        /// <summary>
        /// Adds a Customer.
        /// </summary>
        /// <param name="input">The Customer to add.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool AddCustomer(Customer input);

        /// <summary>
        /// Adds an Address.
        /// </summary>
        /// <param name="input">The Address to add.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool AddAddress(Address input);

        #endregion Add

        #region List

        /// <summary>
        /// Lists both.
        /// </summary>
        /// <returns>The list of Addresses with Customers.</returns>
        [OperationContract()]
        Addresses ListBoth();

        /// <summary>
        /// Lists the Customers.
        /// </summary>
        /// <returns>The list of Customers.</returns>
        [OperationContract()]
        Customers ListCustomer();

        /// <summary>
        /// Lists the Addresses.
        /// </summary>
        /// <returns>The list of Addresses.</returns>
        [OperationContract()]
        Addresses ListAddress();

        #endregion List

        #region Delete

        /// <summary>
        /// Deletes both.
        /// </summary>
        /// <param name="input">The Address with Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool DeleteBoth(Guid input);

        /// <summary>
        /// Deletes a Customer.
        /// </summary>
        /// <param name="input">The Customer to delete.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool DeleteCustomer(Guid input);

        /// <summary>
        /// Deletes an Address.
        /// </summary>
        /// <param name="input">The Address to delete.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool DeleteAddress(Guid input);

        #endregion Delete

        #region Modify

        /// <summary>
        /// Modifies both.
        /// </summary>
        /// <param name="oldinputAddress">The Address to edit.</param>
        /// <param name="oldinputCustomer">The Customer to edit.</param>
        /// <param name="newinput">The Address with Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool ModifyBoth(Guid oldinputAddress, Guid oldinputCustomer, Address newinput);

        /// <summary>
        /// Modifies a Customer.
        /// </summary>
        /// <param name="oldinput">The Customer to edit.</param>
        /// <param name="newinput">The Customer to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool ModifyCustomer(Guid oldinput, Customer newinput);

        /// <summary>
        /// Modifies an Address.
        /// </summary>
        /// <param name="oldinput">The Address to edit.</param>
        /// <param name="newinput">The Address to edit with.</param>
        /// <returns>The outcome of the method.</returns>
        [OperationContract()]
        bool ModifyAddress(Guid oldinput, Address newinput);

        #endregion Modify

        #endregion Methods
    }
}