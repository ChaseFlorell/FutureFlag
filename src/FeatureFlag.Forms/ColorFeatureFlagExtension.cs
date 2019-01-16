using Xamarin.Forms;

namespace FeatureFlag
{
    [ContentProperty(nameof(Key))]
    public class ColorFeatureFlagExtension : ValueFeatureFlagExtension<Color> { }
}