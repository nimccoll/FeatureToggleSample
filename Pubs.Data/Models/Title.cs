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
    public class Title
    {
        #region Properties

        [DisplayName("Title ID")]
        [Required]
        [DataMember]
        public string TitleID { get; set; }
        [DisplayName("Title")]
        [DataMember]
        public string BookTitle { get; set; }
        [DisplayName("Category")]
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public virtual Publisher Publisher { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal Advance { get; set; }
        [DataMember]
        public int Royalty { get; set; }
        [DisplayName("YTD Sales")]
        [DataMember]
        public int YearToDateSales { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DisplayName("Date Published")]
        [DataMember]
        public DateTime PublishDate { get; set; }
        [DataMember]
        public virtual ICollection<Author> Authors { get; set; }
        #endregion
    }
}