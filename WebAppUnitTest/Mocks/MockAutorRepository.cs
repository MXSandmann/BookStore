using DataAccess.Contracts;
using Domain;
using Infrastructure.Specification.Autors;
using Moq;
using System.Collections.Generic;
using System.Threading;

namespace WebAppUnitTest.Mocks
{
    public static class MockAutorRepository
    {
        public static Mock<IAutorRepository> GetInstanceNoFilter()
        {
            var autors = GetAutors();

            var mockRepo = new Mock<IAutorRepository>();

            mockRepo.Setup(x => x.GetAll(It.IsAny<AutorFilterSpecification>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((AutorFilterSpecification specification, int offset, int limit, CancellationToken cancellationToken) =>
                {
                    return (autors, autors.Count);
                });
            return mockRepo;
        }

        public static Mock<IAutorRepository> GetInstanceWithFilter()
        {
            var autors = GetAutors();

            var mockRepo = new Mock<IAutorRepository>();

            mockRepo.Setup(x => x.GetAll(It.IsAny<AutorFilterSpecification>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((AutorFilterSpecification specification, int offset, int limit, CancellationToken cancellationToken) =>
                {
                    autors.RemoveRange(1, 2);
                    return (autors, autors.Count);
                });
            return mockRepo;
        }

        private static List<Autor> GetAutors()
        {
            return new List<Autor>
            {
                new Autor("Boris", "Johnson"),
                new Autor("Alessandro", "Volta"),
                new Autor("Karlos", "Santana")
            };
        }
    }
}
