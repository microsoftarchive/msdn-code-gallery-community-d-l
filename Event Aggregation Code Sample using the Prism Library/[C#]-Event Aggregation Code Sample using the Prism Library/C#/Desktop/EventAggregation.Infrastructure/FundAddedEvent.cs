// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.Prism.PubSubEvents;

namespace EventAggregation.Infrastructure
{
    public class FundAddedEvent : PubSubEvent<FundOrder>
    {
    }
}
