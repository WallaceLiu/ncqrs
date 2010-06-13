﻿using System;
using System.Collections.Generic;
using Ncqrs.Eventing.Sourcing;

namespace Ncqrs.Eventing
{
    /// <summary>
    /// An object that represents all his state changes via a sequence of events.
    /// </summary>
    public interface IEventSource
    {
        /// <summary>
        /// Gets the globally unique identifier.
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// Gets the current version of the instance as it is known in the event store.
        /// </summary>
        /// <value>An <see cref="long"/> representing the current version of this aggregate root.</value>
        long Version
        { 
            get;
        }

        /// <summary>
        /// Gets the initial version.
        /// <para>
        /// This represents the current version of this instance. When this instance was retrieved
        /// via history, it contains the version as it was at that time. For new instances this value is always 0.
        /// </para>
        /// <para>
        /// The version does not change until changes are accepted via the <see cref="AcceptChanges"/> method.
        /// </para>
        /// </summary>
        /// <value>The initial version.</value>
        long InitialVersion
        { 
            get;
        }

        /// <summary>
        /// Gets the uncommitted events.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISourcedEvent> GetUncommittedEvents();

        /// <summary>
        /// Commits the events.
        /// </summary>
        void AcceptChanges();
    }
}