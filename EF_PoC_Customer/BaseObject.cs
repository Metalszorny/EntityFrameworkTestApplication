using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EF_PoC_Customer
{
    /// <summary>
    /// Base class for BaseObject.
    /// </summary>
    [Serializable]
    [DataContract(Name = "BaseObject", Namespace = "net.tcp://localhost/EFPoCAppService")]
    public abstract class BaseObject
    {
        #region Fields

        // The id field of the BaseObject class.
        private Guid id;

        // The creationDate field of the BaseObject class.
        private DateTime creationDate;

        // The modificationDate field of the BaseObject class.
        private DateTime modificationDate;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataMember]
        [Key]
        //[Column(Order = 1, TypeName = "uniqueidentifier")]
        //[Required]
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the creationDate.
        /// </summary>
        /// <value>
        /// The creationDate.
        /// </value>
        [DataMember]
        //[Column(TypeName = "datetime")]
        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        /// <summary>
        /// Gets or sets the modificationDate.
        /// </summary>
        /// <value>
        /// The modificationDate.
        /// </value>
        [DataMember]
        //[Column(TypeName = "datetime")]
        public DateTime ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseObject"/> class.
        /// </summary>
        public BaseObject()
        {
            id = Guid.NewGuid();
        }

        #endregion Constructors

        #region Methods

        #endregion Methods
    }
}
