namespace DesignPatterns.MediatR.ProductMediatR
{
    // Components communicate with a mediator using the mediator
    // interface. Thanks to that, you can use the same components in
    // other contexts by linking them with different mediator
    // objects.
    public class ServiceBase
    {
        protected IMediatR _mediator;

        // Could be set when initializing the service
        public ServiceBase(IMediatR mediator = null)
        {
            _mediator = mediator;
        }   
            
        // Could be changed on runtime
        public void SetMediator(IMediatR mediator)
        {
            _mediator = mediator; 
        }
    }
}
