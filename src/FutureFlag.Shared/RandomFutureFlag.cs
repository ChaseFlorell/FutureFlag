using System;

namespace FutureFlag
{
    public class RandomFutureFlag : IFutureFlag
    {
        public bool IsEnabled => RandomGenerator.Next() % 2 == 0; 
        
        // Based on: http://blogs.msdn.com/b/pfxteam/archive/2009/02/19/9434171.aspx
        // Based on: https://github.com/jason-roberts/FeatureToggle/blob/master/src/FeatureToggle.Common/RandomFeatureToggle.cs
        private static class RandomGenerator
        {
            private static readonly Random _nonThreadLocalInstance = new Random();

            [ThreadStatic]
            private static Random _threadLocalInstance;

            public static int Next()
            {
                var rnd = _threadLocalInstance;

                if (rnd != null)
                {
                    return rnd.Next();
                }

                int seed;

                lock (_nonThreadLocalInstance) seed = _nonThreadLocalInstance.Next();

                _threadLocalInstance = rnd = new Random(seed);

                return rnd.Next();
            }
        }
    }
}