using System.Threading.Tasks;

namespace NestSharp.Api
{
    /// <summary>
    /// Performs the actual requests to the NEST api
    /// </summary>
    interface IRestClient
    {
        /// <summary>
        /// Gets or sets the authorization code from NEST
        /// </summary>
        string AccessToken { get; set; }

        /// <summary>
        /// Gets an object from the API
        /// </summary>
        /// <typeparam name="R">Type of the object being received</typeparam>
        /// <param name="url">URL to get</param>
        /// <returns>Response object</returns>
        Task<R> GetRequest<R>(string url);

        /// <summary>
        /// Puts a given object to the API
        /// </summary>
        /// <typeparam name="T">Type of the object being sent</typeparam>
        /// <typeparam name="R">Type of the object being received</typeparam>
        /// <param name="url">URL to post to</param>
        /// <param name="contents">Object to put</param>
        /// <returns>Response object</returns>
        Task<R> PutRequest<T, R>(string url, T contents);
    }
}