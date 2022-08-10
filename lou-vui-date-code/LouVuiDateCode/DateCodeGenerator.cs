using System;
using System.Globalization;

namespace LouVuiDateCode
{
    public static class DateCodeGenerator
    {
        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(uint manufacturingYear, uint manufacturingMonth)
        {
            if (manufacturingYear < 1980 || manufacturingYear > 1989)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 0 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            var year = manufacturingYear.ToString(CultureInfo.InvariantCulture);
            var month = manufacturingMonth.ToString(CultureInfo.InvariantCulture);
            return string.Concat(year[^2..], month);
        }

        /// <summary>
        /// Generates a date code using rules from early 1980s.
        /// </summary>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateEarly1980Code(DateTime manufacturingDate)
        {
            uint year = (uint)manufacturingDate.Year;
            uint month = (uint)manufacturingDate.Month;
            return GenerateEarly1980Code(year, month);
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            foreach (var c in factoryLocationCode)
            {
                if (char.IsDigit(c) || factoryLocationCode.Length != 2)
                {
                    throw new ArgumentException("Wrong value in factoryLocationCode", nameof(factoryLocationCode));
                }
            }

            var yearAndMonth = GenerateEarly1980Code(manufacturingYear, manufacturingMonth);
            return string.Concat(yearAndMonth, factoryLocationCode.ToUpper(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Generates a date code using rules from late 1980s.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string GenerateLate1980Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            foreach (var c in factoryLocationCode)
            {
                if (char.IsDigit(c) || factoryLocationCode.Length != 2)
                {
                    throw new ArgumentException("Wrong value in factoryLocationCode", nameof(factoryLocationCode));
                }
            }

            var yearAndMonth = GenerateEarly1980Code(manufacturingDate);
            return string.Concat(yearAndMonth, factoryLocationCode.ToUpper(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingMonth">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingMonth)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            if (manufacturingYear < 1990 || manufacturingYear > 2006)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingMonth < 0 || manufacturingMonth > 12)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingMonth));
            }

            foreach (var c in factoryLocationCode)
            {
                if (char.IsDigit(c) || factoryLocationCode.Length != 2)
                {
                    throw new ArgumentException("Wrong value in factoryLocationCode", nameof(factoryLocationCode));
                }
            }

            var monthAndYear = string.Concat(manufacturingYear.ToString(CultureInfo.InvariantCulture)[^2..], manufacturingMonth.ToString(CultureInfo.InvariantCulture));
            if (monthAndYear.Length == 3)
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), '0', monthAndYear[0], monthAndYear[2], monthAndYear[1]);
            }
            else
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), monthAndYear[2], monthAndYear[0], monthAndYear[3], monthAndYear[1]);
            }
        }

        /// <summary>
        /// Generates a date code using rules from 1990 to 2006 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate1990Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            uint year = (uint)manufacturingDate.Year;
            uint month = (uint)manufacturingDate.Month;
            return Generate1990Code(factoryLocationCode, year, month);
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingYear">A manufacturing year.</param>
        /// <param name="manufacturingWeek">A manufacturing week number.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, uint manufacturingYear, uint manufacturingWeek)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            var calendar = CultureInfo.CurrentCulture.Calendar;
            DateTime date = new DateTime((int)manufacturingYear, 12, 29);
            var weekNum = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (manufacturingYear < 2007)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingYear));
            }

            if (manufacturingWeek <= 0 || manufacturingWeek > weekNum)
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingWeek));
            }

            foreach (var c in factoryLocationCode)
            {
                if (char.IsDigit(c) || factoryLocationCode.Length != 2)
                {
                    throw new ArgumentException("Wrong value in factoryLocationCode", nameof(factoryLocationCode));
                }
            }

            var weekAndYear = string.Concat(manufacturingYear.ToString(CultureInfo.InvariantCulture)[^2..], manufacturingWeek.ToString(CultureInfo.InvariantCulture));
            if (weekAndYear.Length == 3)
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), '0', weekAndYear[0], weekAndYear[2], weekAndYear[1]);
            }
            else
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), weekAndYear[2], weekAndYear[0], weekAndYear[3], weekAndYear[1]);
            }
        }

        /// <summary>
        /// Generates a date code using rules from post 2007 period.
        /// </summary>
        /// <param name="factoryLocationCode">A two-letter factory location code.</param>
        /// <param name="manufacturingDate">A manufacturing date.</param>
        /// <returns>A generated date code.</returns>
        public static string Generate2007Code(string factoryLocationCode, DateTime manufacturingDate)
        {
            if (string.IsNullOrEmpty(factoryLocationCode))
            {
                throw new ArgumentNullException(nameof(factoryLocationCode));
            }

            var calendar = CultureInfo.CurrentCulture.Calendar;
            var weekNum = calendar.GetWeekOfYear(manufacturingDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (manufacturingDate.Month == 1 && weekNum > 51)
            {
                manufacturingDate = manufacturingDate.AddYears(-1);
            }

            if (manufacturingDate < new DateTime(2007, 1, 1))
            {
                throw new ArgumentOutOfRangeException(nameof(manufacturingDate));
            }

            foreach (var c in factoryLocationCode)
            {
                if (char.IsDigit(c) || factoryLocationCode.Length != 2)
                {
                    throw new ArgumentException("Wrong value in factoryLocationCode", nameof(factoryLocationCode));
                }
            }

            var weekAndYear = string.Concat(manufacturingDate.Year.ToString(CultureInfo.InvariantCulture)[^2..], weekNum.ToString(CultureInfo.InvariantCulture));
            if (weekAndYear.Length == 3)
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), '0', weekAndYear[0], weekAndYear[2], weekAndYear[1]);
            }
            else
            {
                return string.Concat(factoryLocationCode.ToUpper(CultureInfo.InvariantCulture), weekAndYear[2], weekAndYear[0], weekAndYear[3], weekAndYear[1]);
            }
        }
    }
}
