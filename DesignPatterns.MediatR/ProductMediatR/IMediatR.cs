namespace DesignPatterns.MediatR.ProductMediatR
{
    // The mediator interface declares a method used by components
    // to notify the mediator about various events. The mediator may
    // react to these events and pass the execution to other
    // components.
    public interface IMediatR
    {
        void Notify(object sender, object data, EventType eventType);   
    }
}
    