using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EF_PoC_Customer
{
    /// <summary>
    /// Base class for Address.
    /// </summary>
    [Serializable]
    [DataContract(Name = "Address", Namespace = "net.tcp://localhost/EFPoCAppService")]
    public class Address : BaseObject
    {
        #region Fields

        // The zipCode filed of the Address class.
        private int zipCode;

        // The countryName filed of the Address class.
        private string countryName;

        // The streetName filed of the Address class.
        private string streetName;

        // The houseNumber filed of the Address class.
        private string houseNumber;

        // The cityName filed of the Address class.
        private string cityName;

        // The districtNumber filed of the Address class.
        private string districtNumber;

        // The isDeleted filed of the Address class.
        private bool isDeleted;

        // The customerId filed of the Address class.
        private Guid customerId;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the countryName.
        /// </summary>
        /// <value>
        /// The countryName.
        /// </value>
        [DataMember]
        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        /// <summary>
        /// Gets or sets the zipCode.
        /// </summary>
        /// <value>
        /// The zipCode.
        /// </value>
        [DataMember]
        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        /// <summary>
        /// Gets or sets the cityName.
        /// </summary>
        /// <value>
        /// The cityName.
        /// </value>
        [DataMember]
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        /// <summary>
        /// Gets or sets the districtNumber.
        /// </summary>
        /// <value>
        /// The districtNumber.
        /// </value>
        [DataMember]
        public string DistrictNumber
        {
            get { return districtNumber; }
            set { districtNumber = value; }
        }

        /// <summary>
        /// Gets or sets the streetName.
        /// </summary>
        /// <value>
        /// The streetName.
        /// </value>
        [DataMember]
        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        /// <summary>
        /// Gets or sets the houseNumber.
        /// </summary>
        /// <value>
        /// The houseNumber.
        /// </value>
        [DataMember]
        public string HouseNumber
        {
            get { return houseNumber; }
            set { houseNumber = value; }
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
        /// Gets or sets the customerId.
        /// </summary>
        /// <value>
        /// The customerId.
        /// </value>
        [DataMember]
        public Guid CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        /// <summary>
        /// Gets or sets the Customer.
        /// </summary>
        [DataMember]
        public virtual Customer Customer
		{ get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="countryname">The input value of the countryName value.</param>
        /// <param name="zipcode">The input value of the zipCode value.</param>
        /// <param name="cityname">The input value of the cityName value.</param>
        /// <param name="districtnumber">The input value of the districtNumber value.</param>
        /// <param name="streetname">The input value of the streetName value.</param>
        /// <param name="housenumber">The input value of the houseNumber value.</param>
        /// <param name="isdeleted">The input value of the isDeleted value.</param>
        /// <param name="customerid">The input value of the customerId value.</param>
        public Address(string countryname, int zipcode, string cityname, string districtnumber, string streetname, string housenumber, bool isdeleted, Guid customerid)
        {
            countryName = countryname;
            zipCode = zipcode;
            cityName = cityname;
            districtNumber = districtnumber;
            streetName = streetname;
            houseNumber = housenumber;
            isDeleted = isdeleted;
            customerId = customerid;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="countryname">The input value of the countryName value.</param>
        /// <param name="zipcode">The input value of the zipCode value.</param>
        /// <param name="cityname">The input value of the cityName value.</param>
        /// <param name="districtnumber">The input value of the districtNumber value.</param>
        /// <param name="streetname">The input value of the streetName value.</param>
        /// <param name="housenumber">The input value of the houseNumber value.</param>
        /// <param name="isdeleted">The input value of the isDeleted value.</param>
        /// <param name="customer">The input value of the Customer propertie.</param>
        public Address(string countryname, int zipcode, string cityname, string districtnumber, string streetname, string housenumber, bool isdeleted, Customer customer)
        {
            countryName = countryname;
            zipCode = zipcode;
            cityName = cityname;
            districtNumber = districtnumber;
            streetName = streetname;
            houseNumber = housenumber;
            isDeleted = isdeleted;
            Customer = customer;
            customerId = customer.Id;
        }
		
		/// <summary>
        /// Destroys the instance of the <see cref="Address"/> class.
        /// </summary>
        ~Address()
        { }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }

    /// <summary>
    /// Base class for Addresses.
    /// </summary>
    [Serializable]
    public class Addresses : List<Address>
    {
        #region Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the Items.
        /// </summary>
        public List<Address> Items
		{ get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Addresses"/> class.
        /// </summary>
        public Addresses()
        {
            Items = new List<Address>();
        }
		
		/// <summary>
        /// Destroys the instance of the <see cref="Addresses"/> class.
        /// </summary>
        ~Addresses()
        { }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
