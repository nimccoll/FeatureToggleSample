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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Pubs.Data.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Publisher
    {
        #region Properties

        [DisplayName("Publisher ID")]
        [Required(ErrorMessage="Enter a publisher ID")]
        [MaxLength(4, ErrorMessage="Publisher ID cannot be longer than 4 characters")]
        [DataMember]
        public string PublisherID { get; set; }

        [Required(ErrorMessage="Enter a publisher name")]
        [MaxLength(40, ErrorMessage="Publisher name cannot be longer than 40 characters")]
        [DataMember]
        public string Name { get; set; }

        [Required(ErrorMessage="Enter a city")]
        [MaxLength(20, ErrorMessage = "City cannot be longer than 20 characters")]
        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [Required(ErrorMessage="Enter a country")]
        [MaxLength(30, ErrorMessage = "Country cannot be longer than 30 characters")]
        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public virtual ICollection<Title> Titles { get; set; }

        [DisplayName("YTD Sales")]
        [DataMember]
        public int YearToDateSales { get; set; }

        #endregion
    }
}