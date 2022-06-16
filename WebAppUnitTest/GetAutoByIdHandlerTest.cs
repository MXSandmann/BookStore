using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using UseCases.Autors.Queries.GetAutorQuery.ByID;
using Xunit;

namespace WebAppUnitTest
{
    public class GetAutoByIdHandlerTest
    {
        private readonly GetAutoByIdHandler _sut;
        //private readonly Mock<IApplicationDBContext> applicationDBContextMock = new Mock<IApplicationDBContext>();
        private readonly Mock<ApplicationDBContext> applicationDBContextMock = new Mock<ApplicationDBContext>();

        public GetAutoByIdHandlerTest()
        {
            _sut = new GetAutoByIdHandler(applicationDBContextMock.Object);
        }


        [Fact]
        public async void GetAutoById_AutorExist()
        {
            // Arrange
            var id = 1;
            var getAutorByIdRequest = new GetAutorByIdRequest(id);

            var mockDbSetAutor = new Mock<DbSet<Autor>>()
            {

            };

            var autor = new Autor("testname", "testsurname");

            applicationDBContextMock.Setup(x => x.Autors.FindAsync(It.IsAny<int>())).ReturnsAsync(autor);


            // Act
            var autorMocked = await _sut.HandleFind(getAutorByIdRequest, new CancellationToken());


            // Assert
            Assert.Equal(autorMocked.ID, id);

        }
    }
}