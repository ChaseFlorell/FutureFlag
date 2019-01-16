using Xamarin.Forms;

namespace FeatureFlag
{
    [ContentProperty(nameof(Key))]
    public class TextFeatureFlagExtension : ValueFeatureFlagExtension<string> { }
}