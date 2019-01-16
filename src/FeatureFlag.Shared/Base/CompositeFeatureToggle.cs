using System;
using System.Collections.Generic;

namespace FeatureFlag.Base
{
    public abstract class CompositeFeatureFlag : IFeatureFlag
    {        
        private IList<IFeatureFlag> _toggles = new List<IFeatureFlag>();
        private bool _hasValue;
        
        public CompositeFeatureFlag() { }
        public CompositeFeatureFlag(params IFeatureFlag[] togglesToWrap)
        {
            Flags = togglesToWrap;
        }

        public IList<IFeatureFlag> Flags
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