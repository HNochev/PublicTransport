using Microsoft.EntityFrameworkCore;
using PublicTransport.Core.Services;
using PublicTransport.Infrastructure.Data;
using PublicTransport.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PublicTransport.Test
{
    public class VehicleServiceTests
    {
        [Fact]
        public void GetAllVehiclesReturnCorrectNumber()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("GetAllVehiclesReturnCorrectNumber").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "123", FactoryNumber = "123456789", Make = "Skoda", Model = "14Tr" });
            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "2421", FactoryNumber = "123456789", Make = "Skoda", Model = "24Tr" });

            dbContext.SaveChanges();
            var service = new VehicleService(dbContext);

            Assert.Equal(2, dbContext.Vehicles.Count());
        }

        [Fact]
        public void DeleteReduceCountOfVehicles()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("DeleteReduceCountOfVehicles").Options;
            var dbContext = new ApplicationDbContext(options);

            var firstAddGuid = Guid.NewGuid();

            dbContext.Vehicles.Add(new Vehicle { Id = firstAddGuid, InventoryNumber = "123", FactoryNumber = "123456789", Make = "Skoda", Model = "14Tr" });
            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "2421", FactoryNumber = "123456789", Make = "Skoda", Model = "24Tr" });

            dbContext.SaveChanges();
            var service = new VehicleService(dbContext);

            service.Delete(firstAddGuid, true);
            Assert.Single(dbContext.Vehicles.Where(x => !x.IsDeleted));
        }

        [Fact]
        public void DeleteDoesNotThrowIfIdIsInvalid()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("DeleteDoesNotThrowIfIdIsInvalid").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "123", FactoryNumber = "123456789", Make = "Skoda", Model = "14Tr" });
            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "2421", FactoryNumber = "123456789", Make = "Skoda", Model = "24Tr" });

            dbContext.SaveChanges();
            var service = new VehicleService(dbContext);

            var exception = Record.Exception(() => service.Delete(Guid.NewGuid(), true));
            Assert.Null(exception);
        }

        [Fact]
        public void EditChangesTheData()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("EditChangesTheData").Options;
            var dbContext = new ApplicationDbContext(options);

            var firstAddGuid = Guid.NewGuid();

            dbContext.Vehicles.Add(new Vehicle { Id = firstAddGuid, InventoryNumber = "123", FactoryNumber = "123456789", Make = "Skoda", Model = "14Tr" });
            dbContext.Vehicles.Add(new Vehicle { Id = Guid.NewGuid(), InventoryNumber = "2421", FactoryNumber = "123456789", Make = "Skoda", Model = "24Tr" });

            dbContext.SaveChanges();
            var service = new VehicleService(dbContext);

            service.Edit(firstAddGuid, "1010", "ZiU", "656", "10234", DateTime.Now, null, null, null, Guid.NewGuid(), 2001, "New ZiU");
            var editedData = service.EditViewData(firstAddGuid);
            Assert.Equal("1010", editedData.InventoryNumber);
            Assert.Equal("ZiU", editedData.Make);
            Assert.Equal("656", editedData.Model);
            Assert.Equal("10234", editedData.FactoryNumber);
            Assert.Equal(2001, editedData.YearBuilt);
            Assert.Equal("New ZiU", editedData.Description);
        }

        [Fact]
        public void CreateVehicleReturnNewGuid()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("CreateNewsReturnNewGuid").Options;
            var dbContext = new ApplicationDbContext(options);

            dbContext.SaveChanges();
            var service = new VehicleService(dbContext);

            var id = service.CreateVehicle("2419", "Skoda", "24Tr Citybus", "23234", DateTime.Now, null, null, null, Guid.NewGuid(), 2004, null, false);

            Assert.NotNull(id);
        }
    }
}
