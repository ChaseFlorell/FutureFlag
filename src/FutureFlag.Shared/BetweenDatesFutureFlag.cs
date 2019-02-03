using System;
using System.Globalization;

namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag for when the current time falls between two dates
    /// </summary>
    public class BetweenDatesFutureFlag : Base.DateFutureFlag
    {
        /// <summary>
        /// Date where the <see cref="p:IFutureFlag.IsEnabled"/> will begin to be <c>true</c>
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Date where the <see cref="p:IFutureFlag.IsEnabled"/> will stop being <c>true</c>
        /// </summary>
        public string EndDate { get; set; }

        /// <inheritdoc />
        /// <returns><c>true</c> if the current date falls between <see cref="StartDate"/> and <see cref="EndDate"/>, otherwise <c>false</c></returns>
        public override bool IsEnabled
        {
            get
            {
                var start = DateTime.Parse(StartDate, CultureInfo.DateTimeFormat);
                var end = DateTime.Parse(EndDate, CultureInfo.DateTimeFormat);
                var current = UseUtc ? UtcNow : Now;
                return current >= start && current <= end;
            }
        }
    }
}