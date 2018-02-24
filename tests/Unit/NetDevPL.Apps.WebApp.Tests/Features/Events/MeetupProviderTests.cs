using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NetDevPL.Features.Events;
using NetDevPL.Features.Events.Meetup;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Events
{
    public class MeetupProviderTests
    {
        [Fact]
        public async Task GetsEventsFromMeetup()
        {
            // Arrange
            IEventProvider provider = new MeetupEventProvider();

            // Act
            var events = await provider.GetEventsAsync();

            events.Should().HaveCountGreaterThan(0);
            var @event = events.First();
            @event.City.Should().NotBeNullOrEmpty();
            @event.StartDate.Should().NotBe(default(DateTime));
            @event.EndDate.Should().BeNull();
            @event.Title.Should().NotBeNullOrEmpty();
            @event.Url.Should().NotBeNullOrEmpty();
        }
    }
}
