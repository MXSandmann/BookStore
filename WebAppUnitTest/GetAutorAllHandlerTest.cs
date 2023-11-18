using DataAccess.Contracts;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Autors.Queries.GetAutorQuery.All;
using UseCases.Common;
using UseCases.DTO.Responses;
using WebAppUnitTest.Mocks;
using Xunit;

namespace WebAppUnitTest
{
    public class GetAutorAllHandlerTest
    {
        private readonly Mock<IAutorRepository> _mockRepoNoFilter;
        private readonly Mock<IAutorRepository> _mockRepoWithFilter;

        public GetAutorAllHandlerTest()
        {
            _mockRepoNoFilter = MockAutorRepository.GetInstanceNoFilter();
            _mockRepoWithFilter = MockAutorRepository.GetInstanceWithFilter();
        }


        [Fact]
        public async Task GetAllAutorsNoFilter()
        {
            // Arrange
            var handler = new GetAutorAllHandler(_mockRepoNoFilter.Object);

            // Act
            var result = await handler.Handle(new GetAutorAllRequest(0, 0, null, null), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PaginationResponse<AutorWithBooksDTO>>();
            result.Count.ShouldBe(3);
        }

        [Fact]
        public async Task GetAllAutorsWithFilter()
        {
            // Arrange
            var handler = new GetAutorAllHandler(_mockRepoWithFilter.Object);

            // Act
            var result = await handler.Handle(new GetAutorAllRequest(0, 0, "Boris", null), CancellationToken.None);

            // Assert
            result.ShouldBeOfType<PaginationResponse<AutorWithBooksDTO>>();
            result.Count.ShouldBe(1);
        }
    }
}