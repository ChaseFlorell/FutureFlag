using System;
using FutureFlag.Base;

namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag for when the current time falls on or before a defined date
    /// </summary>
    public class OnOrBeforeDateFutureFlag : DateFutureFlag
    {
        /// <summary>
        /// The date by which the Future Flag is to be disabled
        /// </summary>
        public string Date { get; set; }
        
        /// <inheritdoc cref="IFutureFlag"/>
        /// <returns><c>true</c> if the <see cref="P:Date"/> greater than or equal to Now, otherwise <c>false</c></returns>
        public override bool IsEnabled =>(UseUtc? UtcNow : Now) <= DateTime.Parse(Date, CultureInfo.DateTimeFormat);
    }
}