namespace NestSharp.Api.Responses.Authorization
{
    using Newtonsoft.Json;

    /// <summary>
    /// Response from the authorization server
    /// </summary>
    internal class AuthorizationResponse
    {
        /// <summary>
        /// Gets or sets the authorization code
        /// </summary>
        [JsonProperty("access_token")]
        public string AuthorizationCode { get; internal set; }

        /// <summary>
        /// Gets or sets the expire time for the code
        /// </summary>
        [JsonProperty("excpires_in")]
        public int Expires { get; internal set; }

        /// <summary>
        /// Gets or sets the error type
        /// </summary>
        public string Error { get; internal set; }

        /// <summary>
        /// Gets or sets the error description
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; internal set; }
    }
}
