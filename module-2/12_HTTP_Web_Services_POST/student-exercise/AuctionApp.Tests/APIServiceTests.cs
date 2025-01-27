using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Moq;
using RestSharp;
using System.Net;

namespace AuctionApp.Tests
{
    [TestClass]
    public class APIServiceTests
    {
        [TestMethod]
        public void AddAuction_ExpectSuccess()
        {
            // Arrange
            Auction auction = new Auction() { Title = "Dragon Plush Toy", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.99 };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.POST))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new Auction { Id = 9, CurrentBid = 19.99, Description = "Not a real dragon", Title = "Dragon Plush Toy", User = "Bernice" },
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction newAuction = apiService.AddAuction(auction);

            // Assert
            newAuction.Id.Should().Be(9);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddAuction_ExpectFailureResponse()
        {
            // Arrange
            Auction auction = new Auction() { Title = "\\", Description = "Bad data" };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.POST))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction newAuction = apiService.AddAuction(auction);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void AddAuction_ExpectNoResponse()
        {
            // Arrange
            Auction auction = new Auction() { Title = "Dragon Plush Toy", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.99 };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.POST))
                .Returns(new RestResponse<Auction>
                {
                    ResponseStatus = ResponseStatus.Error
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction newAuction = apiService.AddAuction(auction);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        public void UpdateAuction_ExpectSuccess()
        {
            // Arrange
            Auction auction = new Auction() { Title = "Dragon Plush Toy", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.99 };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.PUT))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new Auction { Id = 4, CurrentBid = 19.99, Description = "I lied. It is a real dragon", Title = "Dragon Plush Toy", User = "Bernice" },
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction updatedAuction = apiService.UpdateAuction(auction);

            // Assert
            updatedAuction.Description.Should().Equals("I lied. It is a real dragon");
            updatedAuction.CurrentBid.Should().Be(19.99);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void UpdateAuction_ExpectFailureResponse()
        {
            // Arrange
            Auction auction = new Auction() { Title = "\\", Description = "Bad data" };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.PUT))
                .Returns(new RestResponse<Auction>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction updatedAuction = apiService.UpdateAuction(auction);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void UpdateAuction_ExpectNoResponse()
        {
            // Arrange
            Auction auction = new Auction() { Title = "Dragon Plush Toy", Description = "Not a real dragon", User = "Bernice", CurrentBid = 19.99 };
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute<Auction>(It.IsAny<IRestRequest>(), Method.PUT))
                .Returns(new RestResponse<Auction>
                {
                    ResponseStatus = ResponseStatus.Error
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            Auction updatedAuction = apiService.UpdateAuction(auction);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        public void DeleteAuction_ExpectSuccess()
        {
            // Arrange
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.DELETE))
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            bool deleteSuccess = apiService.DeleteAuction(1);

            // Assert
            deleteSuccess.Should().BeTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteAuction_ExpectFailureResponse()
        {
            // Arrange
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.DELETE))
                .Returns(new RestResponse
                {
                    StatusCode = HttpStatusCode.NotFound,
                    ResponseStatus = ResponseStatus.Completed
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            bool deleteSuccess = apiService.DeleteAuction(99);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void DeleteAuction_ExpectNoResponse()
        {
            // Arrange
            Mock<IRestClient> restClient = new Mock<IRestClient>();
            restClient.Setup(x => x.Execute(It.IsAny<IRestRequest>(), Method.DELETE))
                .Returns(new RestResponse
                {
                    ResponseStatus = ResponseStatus.Error
                });
            APIService apiService = new APIService(restClient.Object);

            // Act
            bool deleteSuccess = apiService.DeleteAuction(1);

            // Assert
            Assert.Fail("Exception should be thrown.");
        }
    }
}
