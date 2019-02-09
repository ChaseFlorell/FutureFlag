using System;
using System.Net.Http;
using System.Json;
#if XAMARIN_FORMS
using Xamarin.Forms;

#endif

namespace FutureFlag
{
#if XAMARIN_FORMS
    public class JsonRestFutureFlag : BindableObject, IFutureFlag
#else
    public class JsonRestFutureFlag : IFutureFlag
#endif
    {
#if XAMARIN_FORMS
        public static readonly BindablePropertyKey IsEnabledProperty = BindableProperty.CreateReadOnly(nameof(IsEnabled),
            typeof(bool),
            typeof(JsonRestFutureFlag),
            default(bool));

        /// <inheritdoc cref="p:IFutureFlag.IsEnabled"/>
        public bool IsEnabled
        {
            get => (bool) GetValue(IsEnabledProperty.BindableProperty);
            private set => SetValue(IsEnabledProperty, value);
        }

#else
        public bool IsEnabled { get; private set; }
#endif

        public string Url { get; }

        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Defines a <see cref="IFutureFlag"/> that checks an API for <see cref="p:IFutureFlag.IsEnabled"/>
        /// </summary>
        /// <param name="url">The url to check feature availability</param>
        /// <remarks>The result can return any json response, but MUST have a property called <c>isEnabled</c></remarks>
        /// <example>
        ///<![CDATA[
        /// {
        ///    "isEnabled": true
        /// }
        /// ]]>
        /// </example>
        public JsonRestFutureFlag(string url)
        {
            Url = url;
            CheckIsEnabled(Url);
        }

        private void CheckIsEnabled(string url)
        {
            _client.GetAsync(url).ContinueWith(async t =>
            {
                var response = t.Result;

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var value = JsonValue.Parse(jsonString);
                        IsEnabled = (bool) value["isEnabled"];
                    }
                    catch (Exception ex)
                    {
                        HandleDeserializationException(ex);
                    }
                }
                else
                {
                    HandleFailedResponse(response);
                }
            });
        }

        protected virtual void HandleDeserializationException(Exception ex)
        {
        }

        protected virtual void HandleFailedResponse(HttpResponseMessage response)
        {
        }
    }
}