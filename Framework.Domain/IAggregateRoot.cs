namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        void ClearUncommittedEvents();
        IReadOnlyList<DomainEvent> GetUncommittedEvents();
    }
}
