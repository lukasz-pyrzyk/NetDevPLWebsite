using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NetDevPL.Features.Events;
using NetDevPL.Features.Events.LocalFile;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Events
{
    public class LocalFileProviderTests
    {
        [Fact]
        public async Task GetsEventsFromFile()
        {
            // Arrange
            IEventProvider provider = new LocalFileProvider();

            // Act
            var events = await provider.GetEventsAsync();

            events.Should().HaveCountGreaterThan(0);
            var @event = events.First();
            @event.City.Should().NotBeNullOrEmpty();
            @event.StartDate.Should().NotBe(default(DateTime));
            @event.EndDate.Should().NotBeNull();
            @event.Title.Should().NotBeNullOrEmpty();
            @event.Url.Should().NotBeNullOrEmpty();
        }
    }
}
