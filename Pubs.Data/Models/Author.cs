//===============================================================================
// Microsoft Premier Support for Developers
// FeatureToggle Sample
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Pubs.Data.Models
{
    /// <summary>
    /// Represents an author
    /// </summary>
    [Serializable]
    [DataContract(IsReference = true)]
    public class Author
    {
        #region Properties

        /// <summary>
        /// Unique author identifier
        /// </summary>
        [DisplayName("Author ID")]
        [DataMember]
        public string AuthorID { get; set; }
        [DisplayName("First Name")]
        [DataMember]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set
            {

            }
        }
        [DisplayName("Phone Number")]
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DisplayName("Zip Code")]
        [DataMember]
        public string PostalCode { get; set; }
        [DisplayName("Has Contract?")]
        [DataMember]
        public bool HasContract { get; set; }

        [DataMember]
        public virtual ICollection<Title> Titles { get; set; }

        /// <summary>
        /// Year to date sales
        /// </summary>
        [DisplayName("YTD Sales")]
        [DataMember]
        public int YearToDateSales { get; set; }

        #endregion
    }
}