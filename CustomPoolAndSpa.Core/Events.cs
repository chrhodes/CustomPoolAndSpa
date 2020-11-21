using Prism.Events;

namespace CustomPoolAndSpa.Core
{
    // Removed in Prism6
    //public class PersonUpdatedEvent : CompositePresentationEvent<string> { }
    public class PersonUpdatedEvent : PubSubEvent<string> { }
}
