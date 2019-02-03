using System;
using System.Collections.Generic;

namespace FutureFlag.Base
{
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(Flags))]
#endif
    public abstract class CompositeFutureFlag : IFutureFlag
    {        
        private IList<IFutureFlag> _toggles = new List<IFutureFlag>();
        private bool _hasValue;
        
        public CompositeFutureFlag() { }
        public CompositeFutureFlag(params IFutureFlag[] togglesToWrap)
        {
            Flags = togglesToWrap;
        }

        public IList<IFutureFlag> Flags
        {
            get => _toggles;
            set
            {
                if(_hasValue) throw new InvalidOperationException("Value already set");
                _toggles = value;
                _hasValue = true;
            }
        }
        public abstract bool IsEnabled { get; }
    }
}