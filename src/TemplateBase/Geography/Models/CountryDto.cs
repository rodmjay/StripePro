﻿#region Header

// /*

// Author: Rod Johnson, Architect, rodmjay@gmail.com
// */

#endregion

using TemplateBase.Geography.Interfaces;

namespace TemplateBase.Geography.Models
{
    public class CountryDto : ICountry
    {
        public string Name { get; set; }

        public string Iso2 { get; set; }

        public string CapsName { get; set; }

        public string Iso3 { get; set; }

        public int? NumberCode { get; set; }

        public int PhoneCode { get; set; }
    }
}