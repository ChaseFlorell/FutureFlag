using System;
using System.Net.Http;
using System.Json;
#if XAMARIN_FORMS
using Xamarin.Forms;

#endif

namespace FutureFlag
{
    /// <summary>
    /// Defines a <see cref="IFutureFlag"/> that checks an API for <see cref="p:IFutureFlag.IsEnabled"/>
    /// </summary>
    /// <remarks>The result can return any json response, but MUST have a property called <c>isEnabled</c></remarks>
    /// <example>
    ///<![CDATA[
    /// {
    ///    "isEnabled": true
    /// }
    /// ]]>
    /// </example>
#if XAMARIN_FORMS
    public class JsonRestFutureFlag : BindableObject, IFutureFlag
#else
    public class JsonRestFutureFlag : IFutureFlag
#endif
    {
        private static HttpClient _client;
        private static HttpClient Client => _client ?? (_client = new HttpClient());
        
        private string _url;
        
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

        /// <summary>
        /// The API endpoint to check for <see cref="p:IFutureFlag.IsEnabled"/>
        /// </summary>
        /// <remarks><see cref="p:IFutureFlag.IsEnabled"/> is checked as soon as <see cref="Url"/> is set. Since the request is asynchronous, there will be a delay waiting for the response.</remarks>
        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                CheckIsEnabled(_url);
            }
        }

        protected virtual void HandleDeserializationException(Exception ex)
        {
        }

        protected virtual void HandleFailedResponse(HttpResponseMessage response)
        {
        }

        private void CheckIsEnabled(string url)
        {
            Client.GetAsync(url).ContinueWith(async t =>
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

        internal static void SetHttpHandler(DelegatingHandler handler) => _client = new HttpClient(handler);
    }
}