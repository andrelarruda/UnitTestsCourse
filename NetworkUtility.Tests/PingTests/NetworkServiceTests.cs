using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;

        public NetworkServiceTests()
        {
            // SUT (System Under Test)
            _networkService = new NetworkService();
        }

        // Testing strings
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange
            string expectedMessage = "Success: Ping Sent!";

            // Act
            string result = _networkService.SendPing();

            // Assert
            // Assert.Equal(expectedMessage, result);
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be(expectedMessage); // fluentAssertions
            result.Should().Contain("Success", Exactly.Once());
        }

        // Testing ints and passing arguments
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(5, 6, 11)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange

            // Act
            int result = _networkService.PingTimeout(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        // Testing DateTime
        [Fact]
        public void NetworkService_LastPingDate_ReturnDate()
        {
            // Arrange

            // Act
            var result = _networkService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        // Testing objects
        [Fact]
        public void NetworkService_GetPingOptions_ReturnDate()
        {
            // Arrange
            var expected = new PingOptions() { DontFragment = true, Ttl = 1};

            // Act
            var result = _networkService.GetPingOptions();

            // Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnIEnumerables()
        {
            // Arrange
            var expected = new PingOptions() { DontFragment = true, Ttl = 1 };

            // Act
            var result = _networkService.MostRecentPings();

            // Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions[]>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
