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
using Pubs.Data.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pubs.Web.ViewModels
{
    [Serializable]
    public class TitleEditViewModel
    {
        public List<Title> Titles { get; set; }
        public List<Author> Authors { get; set; }
        public SelectList PublisherSelectList { get; set; }
    }
}