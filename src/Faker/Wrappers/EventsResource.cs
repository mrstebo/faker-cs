namespace Faker.Wrappers
{
    public interface IEventsResource
    {
        string Activity { get; }
        string Season { get; }
    }

    internal class EventsResource : IEventsResource
    {
        public string Activity => Resources.Events.Activity;
        public string Season => Resources.Events.Season;
    }
}