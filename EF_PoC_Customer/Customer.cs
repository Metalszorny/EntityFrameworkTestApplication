using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EF_PoC_Customer
{
    /// <summary>
    /// Base class for Customer.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Customer", Namespace = "net.tcp://localhost/EFPoCAppService")]
    public class Customer : BaseObject
    {
        #region Fields

        // The customerName field of the Customer class.
        private string customerName;

        // The rowId field of the Customer class.
        private RowType rowId;

        // The isDeleted field of the Customer class.
        private bool isDeleted;

        // The customerAddresses field of the Customer class.
        private Addresses customerAddresses;

        // The RowType enum of the Customer class.
        public enum RowType
        {
            User = 1,
            Operator = 2,
            Admin = 3,
            VIP = 4
        }

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the rowId.
        /// </summary>
        /// <value>
        /// The rowId.
        /// </value>
        [DataMember]
        public RowType RowId
        {
            get { return rowId; }
            set { rowId = value; }
        }

        /// <summary>
        /// Gets or sets the customerName.
        /// </summary>
        /// <value>
        /// The customerName.
        /// </value>
        [DataMember]
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        /// <summary>
        /// Gets or sets the isDeleted.
        /// </summary>
        /// <value>
        /// The isDeleted.
        /// </value>
        [DataMember]
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        /// <summary>
        /// Gets or sets the CustomerAddresses.
        /// </summary>
        /// <value>
        /// The CustomerAddresses.
        /// </value>
        public virtual Addresses CustomerAddresses
        {
            get { return customerAddresses; }
            set { customerAddresses = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="customername">The input value of the customerName field.</param>
        /// <param name="isdeleted">The input value of the isDeleted field.</param>
        public Customer(string customername, bool isdeleted)
        {
            customerName = customername;
            isDeleted = isdeleted;
        }
		
		/// <summary>
        /// Destroys the instance of the <see cref="Customer"/> class.
        /// </summary>
        ~Customer()
        { }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }

    /// <summary>
    /// Base class for Customers.
    /// </summary>
    [Serializable]
    public class Customers : List<Customer>
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public List<Customer> Items
		{ get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customers"/> class.
        /// </summary>
        public Customers()
        {
            Items = new List<Customer>();
        }
		
		/// <summary>
        /// Destroys the instance of the <see cref="Customers"/> class.
        /// </summary>
        ~Customers()
        { }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
