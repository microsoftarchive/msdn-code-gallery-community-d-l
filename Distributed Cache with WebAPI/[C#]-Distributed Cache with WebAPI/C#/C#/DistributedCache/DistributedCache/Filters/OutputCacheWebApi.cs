using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DistributedCache.Cache;

namespace DistributedCache.Filters
{
    /// <summary>
    /// Output cache attribute
    /// </summary>
    /// <remarks>
    /// Dependency with StackExchange.Redis package
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method)]
    public class OutputCacheWebApi : ActionFilterAttribute
    {
        #region Variables
        private readonly bool _allowAnonymous;
        private readonly TimeSpan _serverTimeSpan;
        private readonly TimeSpan _clientTimeSpan;
        private string _cacheKey;
        private readonly bool _forceOverWrite;
        private static ICache _cache;
        #endregion

        #region Properties

        private static ICache Cache
        {
            get
            {
                return _cache ?? (_cache = new RedisCache(ConfigurationManager.AppSettings.Get("redisIpAddress")));
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputCacheWebApi" /> class.
        /// </summary>
        /// <param name="serverCacheSecond">The server cache second.</param>
        /// <param name="clientCacheSeconds">The client cache seconds.</param>
        /// <param name="allowAnonymous">if set to <c>true</c> [anonymous only].</param>
        /// <param name="forceOverWrite">if set to <c>true</c> [force over write].</param>
        public OutputCacheWebApi(long serverCacheSecond = 60, long clientCacheSeconds = 60, bool allowAnonymous = false, bool forceOverWrite = false)
        {
            _serverTimeSpan = TimeSpan.FromSeconds(serverCacheSecond);
            _clientTimeSpan = TimeSpan.FromSeconds(clientCacheSeconds);
            _allowAnonymous = allowAnonymous;
            _forceOverWrite = forceOverWrite;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <exception cref="ArgumentNullException">actionContext</exception>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!this.IsCacheable(actionContext)) return;

            var accept = actionContext.Request.Headers.Accept.FirstOrDefault() ?? new MediaTypeHeaderValue("application/json");
            this.SetCacheKey(actionContext, accept);

            if (Cache.Exists(this._cacheKey))
            {
                var cachedHttpResponseContent = Cache.Get<WebApiCacheItem>(this._cacheKey);
                if (cachedHttpResponseContent == null) return;

                actionContext.Response = actionContext.Request.CreateResponse();
                actionContext.Response.StatusCode = (HttpStatusCode)cachedHttpResponseContent.StatusCode;
                actionContext.Response.Content = new ByteArrayContent(cachedHttpResponseContent.Content);
                actionContext.Response.Content.Headers.ContentType = new MediaTypeHeaderValue(cachedHttpResponseContent.MediaType);

                if (_clientTimeSpan != TimeSpan.Zero) actionContext.Response.Headers.CacheControl = this.SetClientCache();
            }
        }

        /// <summary>
        /// Occurs after the action method is invoked.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null) return;

            if (!this.IsCacheable(actionExecutedContext.ActionContext)) return;

            if (!Cache.Exists(this._cacheKey))
            {
                var cachedHttpResponseContent = new WebApiCacheItem();
                cachedHttpResponseContent.Content = actionExecutedContext.Response.Content.ReadAsByteArrayAsync().Result;
                cachedHttpResponseContent.MediaType = actionExecutedContext.Response.Content.Headers.ContentType.MediaType;
                cachedHttpResponseContent.StatusCode = actionExecutedContext.Response.StatusCode.GetHashCode();

                Cache.Add(this._cacheKey, cachedHttpResponseContent, this._serverTimeSpan, this._forceOverWrite);

                actionExecutedContext.ActionContext.Response.Headers.CacheControl = this.SetClientCache();
            }
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Determines whether the specified action context is cacheable.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        private bool IsCacheable(HttpActionContext actionContext)
        {
            if (this._allowAnonymous == false)
            {
                var user = actionContext.ControllerContext.RequestContext.Principal;
                return (user != null && user.Identity.IsAuthenticated);
            }

            return actionContext.Request.Method == HttpMethod.Get || actionContext.Request.Method == HttpMethod.Head;
        }

        /// <summary>
        /// Sets the cache key.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="accept">The accept.</param>
        private void SetCacheKey(HttpActionContext actionContext, MediaTypeHeaderValue accept)
        {
            this._cacheKey = String.Format("{0}|{1}", actionContext.Request.RequestUri.PathAndQuery, accept);
        }

        /// <summary>
        /// Sets the client cache.
        /// </summary>
        private CacheControlHeaderValue SetClientCache()
        {
            return new CacheControlHeaderValue { MaxAge = _clientTimeSpan, MustRevalidate = true };
        }
        #endregion

        #region Internal class

        [Serializable]
        private class WebApiCacheItem
        {
            public int StatusCode { get; set; }
            public string MediaType { get; set; }
            public byte[] Content { get; set; }
        }

        #endregion
    }
}