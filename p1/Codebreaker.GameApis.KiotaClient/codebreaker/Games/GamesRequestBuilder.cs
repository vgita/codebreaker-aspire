// <auto-generated/>
using Codebreaker.Client.Games.Item;
using Codebreaker.Client.Models;
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace Codebreaker.Client.Games
{
    /// <summary>
    /// Builds and executes requests for operations under \games
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
    public partial class GamesRequestBuilder : BaseRequestBuilder
    {
        /// <summary>Gets an item from the Codebreaker.Client.games.item collection</summary>
        /// <param name="position">The id of the game to set a move</param>
        /// <returns>A <see cref="global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder"/></returns>
        public global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder this[Guid position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                urlTplParams.Add("id", position);
                return new global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>Gets an item from the Codebreaker.Client.games.item collection</summary>
        /// <param name="position">The id of the game to set a move</param>
        /// <returns>A <see cref="global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder"/></returns>
        [Obsolete("This indexer is deprecated and will be removed in the next major version. Use the one with the typed parameter instead.")]
        public global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder this[string position]
        {
            get
            {
                var urlTplParams = new Dictionary<string, object>(PathParameters);
                if (!string.IsNullOrWhiteSpace(position)) urlTplParams.Add("id", position);
                return new global::Codebreaker.Client.Games.Item.GamesItemRequestBuilder(urlTplParams, RequestAdapter);
            }
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Codebreaker.Client.Games.GamesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GamesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/games{?date*,ended*,gameType*,playerName*}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::Codebreaker.Client.Games.GamesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public GamesRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/games{?date*,ended*,gameType*,playerName*}", rawUrl)
        {
        }
        /// <summary>
        /// Get games based on query parameters
        /// </summary>
        /// <returns>A List&lt;global::Codebreaker.Client.Models.Game&gt;</returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<List<global::Codebreaker.Client.Models.Game>?> GetAsync(Action<RequestConfiguration<global::Codebreaker.Client.Games.GamesRequestBuilder.GamesRequestBuilderGetQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<List<global::Codebreaker.Client.Models.Game>> GetAsync(Action<RequestConfiguration<global::Codebreaker.Client.Games.GamesRequestBuilder.GamesRequestBuilderGetQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToGetRequestInformation(requestConfiguration);
            var collectionResult = await RequestAdapter.SendCollectionAsync<global::Codebreaker.Client.Models.Game>(requestInfo, global::Codebreaker.Client.Models.Game.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
            return collectionResult?.AsList();
        }
        /// <summary>
        /// Creates and starts a game
        /// </summary>
        /// <returns>A <see cref="global::Codebreaker.Client.Models.CreateGameResponse"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// <exception cref="global::Codebreaker.Client.Models.GameError">When receiving a 400 status code</exception>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::Codebreaker.Client.Models.CreateGameResponse?> PostAsync(global::Codebreaker.Client.Models.CreateGameRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::Codebreaker.Client.Models.CreateGameResponse> PostAsync(global::Codebreaker.Client.Models.CreateGameRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            var errorMapping = new Dictionary<string, ParsableFactory<IParsable>>
            {
                { "400", global::Codebreaker.Client.Models.GameError.CreateFromDiscriminatorValue },
            };
            return await RequestAdapter.SendAsync<global::Codebreaker.Client.Models.CreateGameResponse>(requestInfo, global::Codebreaker.Client.Models.CreateGameResponse.CreateFromDiscriminatorValue, errorMapping, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Get games based on query parameters
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Codebreaker.Client.Games.GamesRequestBuilder.GamesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<global::Codebreaker.Client.Games.GamesRequestBuilder.GamesRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Creates and starts a game
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::Codebreaker.Client.Models.CreateGameRequest body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::Codebreaker.Client.Models.CreateGameRequest body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::Codebreaker.Client.Games.GamesRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::Codebreaker.Client.Games.GamesRequestBuilder WithUrl(string rawUrl)
        {
            return new global::Codebreaker.Client.Games.GamesRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Get games based on query parameters
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
        public partial class GamesRequestBuilderGetQueryParameters 
        {
            /// <summary>The date to filter by</summary>
            [QueryParameter("date")]
            public Date? Date { get; set; }
            /// <summary>Whether to filter by ended games</summary>
            [QueryParameter("ended")]
            public bool? Ended { get; set; }
            /// <summary>The game type to filter by</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("gameType")]
            public string? GameType { get; set; }
#nullable restore
#else
            [QueryParameter("gameType")]
            public string GameType { get; set; }
#endif
            /// <summary>The player name to filter by</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("playerName")]
            public string? PlayerName { get; set; }
#nullable restore
#else
            [QueryParameter("playerName")]
            public string PlayerName { get; set; }
#endif
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
        public partial class GamesRequestBuilderGetRequestConfiguration : RequestConfiguration<global::Codebreaker.Client.Games.GamesRequestBuilder.GamesRequestBuilderGetQueryParameters>
        {
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.16.0")]
        public partial class GamesRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
