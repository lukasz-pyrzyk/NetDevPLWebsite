using System;
using FluentAssertions;
using NetDevPL.TestHelpers.Builders;
using Xunit;

namespace NetDevPL.Apps.WebApp.Tests.Features.Events
{
    public class EventTests
    {
        [Fact]
        public void HasEnded_ReturnsTrue_WhenStartTimeIsInPast()
        {
            // Arrange
            var startTime = DateTime.Now.AddHours(-2);
            var @event = new EventBuilder().WithStartDate(startTime).Build();

            // Act
            var result = @event.HasEnded();

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void HasEnded_ReturnsFalse_WhenStartTimeIsInFuture()
        {
            // Arrange
            var startTime = DateTime.Now.AddHours(2);
            var @event = new EventBuilder().WithStartDate(startTime).Build();

            // Act
            var result = @event.HasEnded();

            // Assert
            result.Should().BeFalse();
        }
    }
}
