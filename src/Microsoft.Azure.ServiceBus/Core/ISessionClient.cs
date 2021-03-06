﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Core
{
    using System;
    using System.Threading.Tasks;

    /// <summary> 
    /// Describes a Session client. A session client can be used to accept session objects which can be used to interact with all messages with the same sessionId. 
    /// </summary> 
    /// <remarks> 
    /// You can accept any session or a given session (identified by <see cref="IMessageSession.SessionId"/> using a session client. 
    /// Once you accept a session, you can use it as a <see cref="MessageReceiver"/> which receives only messages having the same session id.
    /// See <see cref="IMessageSession"/> for usage of session object.
    /// <example>
    /// To create a new SessionClient
    /// <code>
    /// ISessionClient sessionClient = new SessionClient(
    ///     namespaceConnectionString,
    ///     queueName,
    ///     ReceiveMode.PeekLock);
    /// </code>
    /// 
    /// To receive a session object for a given sessionId
    /// <code>
    /// IMessageSession session = await sessionClient.AcceptMessageSessionAsync(sessionId);
    /// </code>
    /// 
    /// To receive any session
    /// <code>
    /// IMessageSession session = await sessionClient.AcceptMessageSessionAsync();
    /// </code>
    /// </example>
    /// </remarks> 
    /// <seealso cref="IMessageSession"/>
    /// <seealso cref="SessionClient"/>
    public interface ISessionClient
    {
        /// <summary>
        /// Gets the path of the entity. This is either the name of the queue, or the full path of the subscription.
        /// </summary>
        string EntityPath { get; }

        /// <summary>
        /// Gets a session object of any <see cref="IMessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <returns>A session object.</returns>
        Task<IMessageSession> AcceptMessageSessionAsync();

        /// <summary>
        /// Gets a session object of any <see cref="IMessageSession.SessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="serverWaitTime">Amount of time for which the call should wait for to fetch the next session.</param>
        /// <returns>A session object.</returns>
        Task<IMessageSession> AcceptMessageSessionAsync(TimeSpan serverWaitTime);

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <returns>A session object.</returns>
        Task<IMessageSession> AcceptMessageSessionAsync(string sessionId);

        /// <summary>
        /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
        /// </summary>
        /// <param name="sessionId">The sessionId present in all its messages.</param>
        /// <param name="serverWaitTime">Amount of time for which the call should wait for to fetch the next session.</param>
        /// <returns>A session object.</returns>
        Task<IMessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan serverWaitTime);
    }
}