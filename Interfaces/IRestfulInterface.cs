// -------------------------------------------------------------------------
// Copyright (c) Mecalc (Pty) Limited. All rights reserved.
// -------------------------------------------------------------------------

using System;

namespace QProtocol.Interfaces
{
    /// <summary>
    /// An interface describing the HTTP calls needed for the QProtocol communication to QServer.
    /// </summary>
    public interface IRestfulInterface : IDisposable
    {
        /// <summary>
        /// This method will PUT a HTTP request to the QServer without body text.
        /// </summary>
        /// <param name="endpoint">The endpoint as described in <see cref="EndPoints"/></param>
        /// <param name="parameters">A tuple with the request parameter name and value</param>
        void Put(string endpoint, params HttpParameter[] parameters);

        /// <summary>
        /// This method will PUT a HTTP request to the QServer with body text.
        /// </summary>
        /// <param name="endpoint">The endpoint as described in <see cref="EndPoints"/></param>
        /// <param name="parameters">A tuple with the request parameter name and value</param>
        void Put(string endpoint, object body, params HttpParameter[] parameters);

        /// <summary>
        /// This method will GET a HTTP response from the QServer with body text.
        /// </summary>
        /// <param name="endpoint">The endpoint as described in <see cref="EndPoints"/></param>
        /// <param name="parameters">A tuple with the request parameter name and value</param>
        T Get<T>(string endpoint, params HttpParameter[] parameters);

        /// <summary>
        /// This method will DELETE a HTTP request to the QServer.
        /// </summary>
        /// <param name="endpoint">The endpoint as described in <see cref="EndPoints"/>.</param>
        /// <param name="parameters">A tuple with the request parameter name and value</param>
        void Delete(string endpoint, params HttpParameter[] parameters);
    }
}
