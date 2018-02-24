using FluentAssertions;
using NetDevPLWeb.Features.Events;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Events
{
    public class EventsSourceTests
    {
        [Fact]
        public void DoesntReturnEventsFromPast()
        {
            // Arrange
            var source = new EventsSource();

            // Act
            var events = source.GetEvents();

            // Assert
            foreach (var @event in events)
            {
                @event.HasEnded().Should().BeFalse();
            }
        }
    }
}
