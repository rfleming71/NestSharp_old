namespace Nest.Api.Responses.Auth
{
    using Newtonsoft.Json;

    /// <summary>
    /// Response from the authorization server
    /// </summary>
    internal class AuthResponse
    {
        /// <summary>
        /// Gets or sets the authorization code
        /// </summary>
        [JsonProperty("auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// Gets or sets the expire time for the code
        /// </summary>
        public int Expires { get; set; }

        /// <summary>
        /// Gets or sets the error type
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets the error description
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
