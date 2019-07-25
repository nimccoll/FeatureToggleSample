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
using System.Collections.Generic;

namespace Pubs.Data.Models
{
    public static class State
    {
        private static Dictionary<string, string> _stateList = new Dictionary<string, string>();

        public static Dictionary<string, string> List
        {
            get
            {
                if (_stateList.Count == 0)
                {
                    _stateList.Add("", "Choose a state");
                    _stateList.Add("AL", "Alabama");
                    _stateList.Add("AK", "Alaska");
                    _stateList.Add("AZ", "Arizona");
                    _stateList.Add("AR", "Arkansas");
                    _stateList.Add("CA", "California");
                    _stateList.Add("CO", "Colorado");
                    _stateList.Add("CT", "Connecticut");
                    _stateList.Add("DE", "Delaware");
                    _stateList.Add("FL", "Florida");
                    _stateList.Add("GA", "Georgia");
                    _stateList.Add("HI", "Hawaii");
                    _stateList.Add("ID", "Idaho");
                    _stateList.Add("IL", "Illinois");
                    _stateList.Add("IN", "Indiana");
                    _stateList.Add("IA", "Iowa");
                    _stateList.Add("KS", "Kansas");
                    _stateList.Add("KY", "Kentucky");
                    _stateList.Add("LA", "Louisiana");
                    _stateList.Add("ME", "Maine");
                    _stateList.Add("MD", "Maryland");
                    _stateList.Add("MA", "Massachusetts");
                    _stateList.Add("MI", "Michigan");
                    _stateList.Add("MN", "Minnesota");
                    _stateList.Add("MS", "Mississippi");
                    _stateList.Add("MO", "Missouri");
                    _stateList.Add("MT", "Montana");
                    _stateList.Add("NE", "Nebraska");
                    _stateList.Add("NV", "Nevada");
                    _stateList.Add("NH", "New Hampshire");
                    _stateList.Add("NJ", "New Jersey");
                    _stateList.Add("NM", "New Mexico");
                    _stateList.Add("NY", "New York");
                    _stateList.Add("NC", "North Carolina");
                    _stateList.Add("ND", "North Dakota");
                    _stateList.Add("OH", "Ohio");
                    _stateList.Add("OK", "Oklahoma");
                    _stateList.Add("OR", "Oregon");
                    _stateList.Add("PA", "Pennsylvania");
                    _stateList.Add("RI", "Rhode Island");
                    _stateList.Add("SC", "South Carolina");
                    _stateList.Add("SD", "South Dakota");
                    _stateList.Add("TN", "Tennessee");
                    _stateList.Add("TX", "Texas");
                    _stateList.Add("UT", "Utah");
                    _stateList.Add("VT", "Vermont");
                    _stateList.Add("VA", "Virginia");
                    _stateList.Add("WA", "Washington");
                    _stateList.Add("WV", "West Virginia");
                    _stateList.Add("WI", "Wisconsin");
                    _stateList.Add("WY", "Wyoming");
                }

                return _stateList;
            }
        }
    }
}
