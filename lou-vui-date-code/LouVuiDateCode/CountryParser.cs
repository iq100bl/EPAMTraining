using System;

namespace LouVuiDateCode
{
    public static class CountryParser
    {
        /// <summary>
        /// Gets a an array of <see cref="Country"/> enumeration values for a specified factory location code. One location code can belong to many countries.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <returns>An array of <see cref="Country"/> enumeration values.</returns>
        public static Country[] GetCountry(string factoryLocationCode)
        {
            // TODO #5. Analyze unit tests for the method, and add the method implementation.
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            var france = new string[] { "A0", "A1", "A2", "AA", "AH", "AN", "AR", "AS", "BA", "BJ", "BU", "DR", "DU", "DR", "DT", "CO", "CT", "CX", "ET", "FL", "LW", "MB", "MI", "NO", "RA", "RI", "SD", "SF", "SL", "SN", "SP", "SR", "TJ", "TH", "TR", "TS", "VI", "VX" };
            var germany = new string[] { "LP", "OL" };
            var italy = new string[] { "BC", "BO", "CE", "FO", "MA", "OB", "RC", "RE", "SA", "TD" };
            var spain = new string[] { "LW", "LM", "GI", "CA", "LB", "LO" };
            var switzerland = new string[] { "DI", "FA" };
            var usa = new string[] { "FL", "SD", "FC", "FH", "LA", "OS" };
            Country[] countries = Array.Empty<Country>();
            if (Array.Exists(france, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.France;
            }

            if (Array.Exists(germany, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.Germany;
            }

            if (Array.Exists(italy, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.Italy;
            }

            if (Array.Exists(spain, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.Spain;
            }

            if (Array.Exists(switzerland, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.Switzerland;
            }

            if (Array.Exists(usa, x => x == factoryLocationCode))
            {
                Array.Resize(ref countries, countries.Length + 1);
                countries[^1] = Country.USA;
            }

            return countries;
        }
    }
}
