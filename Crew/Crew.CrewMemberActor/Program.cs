﻿using System;
using System.Threading;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace Crew.CrewMemberActor
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                ActorRuntime.RegisterActorAsync<CrewMemberActor>(
                   (context, actorType) => new ActorService(context, actorType))
                   .GetAwaiter()
                   .GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
