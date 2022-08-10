using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeParser
    {
        /// <summary>
        /// Parses a date code and returns a <see cref="manufacturingYear"/> and <see cref="manufacturingMonth"/>.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseEarly1980Code(string dateCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 3 || dateCode.Length > 4)
            {
                throw new ArgumentException("Wrong length datecode", nameof(dateCode));
            }

            manufacturingYear = 1900;
            manufacturingMonth = 0;
            for (int i = 0; i < dateCode.Length; i++)
            {
                if (i == 0)
                {
                    manufacturingYear += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 1)
                {
                    manufacturingYear += (uint)(dateCode[i] - '0');
                }

                if (i == 2 && dateCode.Length == 3)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0');
                }

                if (i == 2 && dateCode.Length == 4)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0') * 10;
                }

                if (i == 3)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0');
                }
            }

            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentException("Wrong year", nameof(manufacturingYear));
            }

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Wrong month", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A three or four number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void ParseLate1980Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length < 5 || dateCode.Length > 6)
            {
                throw new ArgumentException("Wrong length datecode", nameof(dateCode));
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[^2..]);
            factoryLocationCode = dateCode[^2..];
            dateCode = dateCode[..^2];
            manufacturingMonth = 0;
            manufacturingYear = 1900;
            for (int i = 0; i < dateCode.Length; i++)
            {
                if (i == 0)
                {
                    manufacturingYear += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 1)
                {
                    manufacturingYear += (uint)(dateCode[i] - '0');
                }

                if (i == 2 && dateCode.Length == 3)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0');
                }

                if (i == 2 && dateCode.Length == 4)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0') * 10;
                }

                if (i == 3)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0');
                }
            }

            if (factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Empty factoryLocationCountry", nameof(manufacturingYear));
            }

            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentException("Wrong year", nameof(manufacturingYear));
            }

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Wrong month", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingMonth"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingMonth">A manufacturing month to return.</param>
        public static void Parse1990Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Wrong length datecode", nameof(dateCode));
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[..2]);
            factoryLocationCode = dateCode[..2];
            dateCode = dateCode[2..];
            manufacturingMonth = 0;
            manufacturingYear = 0;
            for (int i = 0; i < dateCode.Length; i++)
            {
                if (i == 0)
                {
                    manufacturingMonth += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 1)
                {
                    manufacturingYear += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 2)
                {
                    manufacturingMonth += (uint)(dateCode[i] - '0');
                }

                if (i == 3)
                {
                    manufacturingYear += (uint)(dateCode[i] - '0');
                }
            }

            if (manufacturingYear > 22)
            {
                manufacturingYear += 1900;
            }
            else
            {
                manufacturingYear += 2000;
            }

            if (factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Empty factoryLocationCountry", nameof(manufacturingYear));
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentException("Wrong year", nameof(manufacturingYear));
            }

            if (manufacturingMonth <= 0 || manufacturingMonth > 12)
            {
                throw new ArgumentException("Wrong month", nameof(manufacturingMonth));
            }
        }

        /// <summary>
        /// Parses a date code and returns a <paramref name="factoryLocationCode"/>, <paramref name="manufacturingYear"/>, <paramref name="manufacturingWeek"/> and <paramref name="factoryLocationCountry"/> array.
        /// </summary>
        /// <param name="dateCode">A six number date code.</param>
        /// <param name="factoryLocationCountry">A factory location country array.</param>
        /// <param name="factoryLocationCode">A factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year to return.</param>
        /// <param name="manufacturingWeek">A manufacturing week to return.</param>
        public static void Parse2007Code(string dateCode, out Country[] factoryLocationCountry, out string factoryLocationCode, out uint manufacturingYear, out uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(dateCode))
            {
                throw new ArgumentNullException(nameof(dateCode));
            }

            if (dateCode.Length != 6)
            {
                throw new ArgumentException("Wrong length datecode", nameof(dateCode));
            }

            factoryLocationCountry = CountryParser.GetCountry(dateCode[..2]);
            factoryLocationCode = dateCode[..2];
            dateCode = dateCode[2..];
            manufacturingYear = 2000;
            manufacturingWeek = 0;
            for (int i = 0; i < dateCode.Length; i++)
            {
                if (i == 0)
                {
                    manufacturingWeek += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 1)
                {
                    manufacturingYear += (uint)((dateCode[i] - '0') * 10);
                }

                if (i == 2)
                {
                    manufacturingWeek += (uint)(dateCode[i] - '0');
                }

                if (i == 3)
                {
                    manufacturingYear += (uint)(dateCode[i] - '0');
                }
            }

            var calendar = CultureInfo.CurrentCulture.Calendar;
            DateTime date = new DateTime((int)manufacturingYear, 12, 29);
            var weekNum = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (factoryLocationCountry.Length == 0)
            {
                throw new ArgumentException("Empty factoryLocationCountry", nameof(manufacturingYear));
            }

            if (manufacturingYear < 2007)
            {
                throw new ArgumentException("Wrong year", nameof(manufacturingYear));
            }

            if (manufacturingWeek <= 0 || manufacturingWeek > weekNum)
            {
                throw new ArgumentException("Wrong month", nameof(manufacturingWeek));
            }
        }
    }
}
