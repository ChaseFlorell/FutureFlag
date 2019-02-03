using System;
using FutureFlag.Base;

namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag for when the current time falls on or after a defined date
    /// </summary>
    public class OnOrAfterDateFutureFlag : DateFutureFlag
    {
        /// <summary>
        /// The date by which the Future Flag is to be enabled
        /// </summary>
        public string Date { get; set; }
        
        /// <inheritdoc cref="IFutureFlag"/>
        /// <returns><c>true</c> if the <see cref="P:Date"/> less than or equal to Now, otherwise <c>false</c></returns>
        public override bool IsEnabled => (UseUtc? UtcNow : Now) >= DateTime.Parse(Date, CultureInfo.DateTimeFormat);
    }
}