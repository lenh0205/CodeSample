using DataInfastructure;
using DataInfastructure.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace UnitTestApi
{
    //public class SchoolControllerTest
    //{
    //    [Fact]
    //    //public void CreateClass_Succeed()
    //    //{
    //    //    // Arrange
    //    //    var options = new DbContextOptionsBuilder<SchoolDBContext>()
    //    //    .UseInMemoryDatabase(databaseName: "SchoolDB")
    //    //    .Options;

    //    //    // Insert seed data into the database using one instance of the context
    //    //    using (var context = new SchoolDBContext(options))
    //    //    {
    //    //        context.Classes.Add(new Class { Name = "zed" });
    //    //        context.Classes.Add(new Class { Name = "lee" });
    //    //        context.Classes.Add(new Class { Name = "yi" });
    //    //        context.SaveChanges();
    //    //    }
    //    //    var schoolController = new SchoolController(new SchoolUnitOfWork(new SchoolDBContext(options)));

    //    //    // Act
    //    //    var createResult = schoolController.CreateClass(new Class { Name = "vi" });

    //    //    // Assert
    //    //    var result = createResult as StatusCodeResult;
    //    //    Assert.NotNull(result);
    //    //    Assert.Equal(200, result.StatusCode);
    //    //}

    //    [Fact]
    //    //public void CreateClass_Success1()
    //    //{
    //    //    // Arrange
    //    //    var mockUnitOfWork = new Mock<ISchoolUnitOfWork>();
    //    //    var mockClassRepository = new Mock<IClassRepository>();
    //    //    mockUnitOfWork.Setup(uow => uow.ClassRepository).Returns(mockClassRepository.Object);
    //    //    var schoolController = new SchoolController(mockUnitOfWork.Object);
    //    //    var newClass = new Class { Name = "vi" };

    //    //    // Act

    //    //    var createResult = schoolController.CreateClass(newClass);

    //    //    // Assert
    //    //    var okResult = createResult as OkObjectResult;
    //    //    Assert.NotNull(okResult);
    //    //    Assert.Equal((okResult.Value as Class).Name, newClass.Name);
    //    //    Assert.Equal(200, okResult.StatusCode);

    //    //}

    //    [Theory]
    //    [InlineData("Lenh")]
    //    [InlineData("vi")]
    //    //public void CreateClass_Success(string name)
    //    //{
    //    //    // Arrange
    //    //    var mockUnitOfWork = new Mock<ISchoolUnitOfWork>();
    //    //    var mockClassRepository = new Mock<IClassRepository>();
    //    //    mockUnitOfWork.Setup(uow => uow.ClassRepository).Returns(mockClassRepository.Object);
    //    //    var schoolController = new SchoolController(mockUnitOfWork.Object);
    //    //    var newClass = new Class { Name = name };

    //    //    // Act

    //    //    var createResult = schoolController.CreateClass(newClass);

    //    //    // Assert
    //    //    var okResult = createResult as OkObjectResult;
    //    //    Assert.NotNull(okResult);
    //    //    Assert.Equal((okResult.Value as Class).Name, newClass.Name);
    //    //    Assert.Equal(200, okResult.StatusCode);
    //    //}
        
    //    //public static IEnumerable<object[]> NewClass()
    //    //{
    //    //    yield return new object[] {
    //    //        new Class
    //    //        {
    //    //         Name = "abc",
    //    //        }
    //    //    };
    //    //    yield return new object[] {
    //    //        new Class
    //    //        {
    //    //         Name = "bcd",
    //    //        }
    //    //    };
    //    //}

    //    [Theory]
    //    //[MemberData(nameof(NewClass))]
    //    //public void CreateClass_Success2(Class newClass)
    //    //{
    //    //    // Arrange
    //    //    var mockUnitOfWork = new Mock<ISchoolUnitOfWork>();
    //    //    var mockClassRepository = new Mock<IClassRepository>();
    //    //    mockUnitOfWork.Setup(uow => uow.ClassRepository).Returns(mockClassRepository.Object);
    //    //    var schoolController = new SchoolController(mockUnitOfWork.Object);
    //    //    //var newClass = new Class { Name = name };

    //    //    // Act
    //    //    var createResult = schoolController.CreateClass(newClass);

    //    //    // Assert
    //    //    var okResult = createResult as OkObjectResult;
    //    //    Assert.NotNull(okResult);
    //    //    Assert.Equal((okResult.Value as Class).Name, newClass.Name);
    //    //    Assert.Equal(200, okResult.StatusCode);
    //    //}

    //    [Fact]
    //    //public void CreateClass_Exception()
    //    //{
    //    //    // Arrange
    //    //    var mockUnitOfWork = new Mock<ISchoolUnitOfWork>();
    //    //    var mockClassRepository = new Mock<IClassRepository>();
    //    //    mockUnitOfWork.Setup(uow => uow.ClassRepository).Returns(mockClassRepository.Object);
    //    //    var schoolController = new SchoolController(mockUnitOfWork.Object);
    //    //    var newClass = new Class { Name = "vi" };
    //    //    var exception = new Exception("abcd");
    //    //    mockUnitOfWork.Setup(uow => uow.Save()).Throws(exception);

    //    //    // Act

    //    //    var createResult = schoolController.CreateClass(newClass);

    //    //    // Assert
    //    //    var okResult = createResult as BadRequestObjectResult;
    //    //    Assert.NotNull(okResult);
    //    //    Assert.Equal(okResult.Value, exception.Message);
    //    //    Assert.Equal(400, okResult.StatusCode);

    //    //}
    //}
}
