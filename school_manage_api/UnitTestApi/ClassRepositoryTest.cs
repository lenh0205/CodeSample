using DataInfastructure;
using DataInfastructure.Model;
using DataInfastructure.Responsitory;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTestApi
{
    public class ClassRepositoryTest
    {
        [Fact]
        public async void Add_Class_Success ()
        {
            // Arrange
           
            var options = new DbContextOptionsBuilder<SchoolDBContext>()
            .UseInMemoryDatabase(databaseName: "SchoolDB")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new SchoolDBContext(options))
            {
                context.Classes.Add(new Class { Name = "zed" });
                context.Classes.Add(new Class {Name = "lee" });
                context.Classes.Add(new Class {Name = "yi" });
                context.SaveChanges();
            }
            var classRepository = new ClassRepository(new SchoolDBContext(options));

            // Act
            var createdClass = await classRepository.Add(new Class() { Name = "zed" });

            // Assert
            Assert.NotNull(createdClass);
            Assert.Equal("zed", createdClass.Name);
        }

        [Fact]
        public void Add_Class_Fail()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<SchoolDBContext>()
            .UseInMemoryDatabase(databaseName: "SchoolDB")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new SchoolDBContext(options))
            {
                context.Classes.Add(new Class { Name = "zed" });
                context.Classes.Add(new Class { Name = "lee" });
                context.Classes.Add(new Class { Name = "yi" });
                context.SaveChanges();
            }
            var classRepository = new ClassRepository(new SchoolDBContext(options));

            // Act
            var createdClass = classRepository.Add(null);

            // Assert
            Assert.Null(createdClass);
        }
    }
}
