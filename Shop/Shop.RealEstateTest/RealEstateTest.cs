using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.RealEstateTest
{
    public class RealEstateTest : RealEstatetestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnresult()
        {
            RealEstateDto dto = new RealEstateDto();

            dto.Address = "Address";
            dto.SizeSqrM = 123;
            dto.RoomCount = 123;
            dto.Floor = 123;
            dto.BuildingType = "BuildingType";
            dto.BuiltInYear = DateTime.Now;
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            var result = await Svc<IRealEstatesServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            Guid guid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            //kuidas teha automaatselt guidi
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());

            //Act
            await Svc<IRealEstatesServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(guid, wrongGuid);
        }

        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            Guid databaseGuid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            Guid getGuid = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");

            //Act
            await Svc<IRealEstatesServices>().GetAsync(getGuid);

            //Assert
            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realestate = MockRealEstateData(); //teha mock for real estate

            //Act

            var addRealEstate = await Svc<IRealEstatesServices>().Create(realestate);
            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate.Id);
            //Assert

            Assert.Equal(result, addRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteTheWrightRealEstate()
        {
            RealEstateDto realestate = MockRealEstateData(); //mock!!!

            var addRealEstate = await Svc<IRealEstatesServices>().Create(realestate);
            var addRealEstate2 = await Svc<IRealEstatesServices>().Create(realestate);

            var result = await Svc<IRealEstatesServices>().Delete((Guid)addRealEstate2.Id);

            Assert.NotEqual(result.Id, addRealEstate.Id);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            var guid = new Guid("2b8b9080-60ef-442b-9822-f1ad47984736");
            //Arrange
            //old data from db
            RealEstate realestate = new RealEstate();

            //new data
            RealEstateDto dto = MockRealEstateData(); //mock!!!

            realestate.Id = Guid.Parse("2b8b9080-60ef-442b-9822-f1ad47984736");
            realestate.Address = "Address";
            realestate.SizeSqrM = 123;
            realestate.RoomCount = 123;
            realestate.Floor = 123;
            realestate.BuildingType = "BuildingType";
            realestate.BuiltInYear = DateTime.Now;
            realestate.CreatedAt = DateTime.Now.AddYears(1);
            realestate.UpdatedAt = DateTime.Now.AddYears(1);


            //Act
            await Svc<IRealEstatesServices>().Update(dto);

            //Assert
            Assert.Equal(realestate.Id, guid);
            Assert.NotEqual(realestate.RoomCount, dto.RoomCount);
            Assert.Equal(realestate.Floor, dto.Floor);
            Assert.DoesNotMatch(realestate.BuildingType.ToString(), dto.BuildingType.ToString());
        }


        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {
            RealEstateDto dto = MockRealEstateData(); 
            var createRealEstate = await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto update = MockUpdateRealEstateData();
            var updateRealEstate = await Svc<IRealEstatesServices>().Update(update);

            ///error korda teha
            Assert.Matches(updateRealEstate.Address, createRealEstate.Address);
            Assert.NotEqual(updateRealEstate.SizeSqrM, createRealEstate.SizeSqrM);
            Assert.NotEqual(updateRealEstate.RoomCount, createRealEstate.RoomCount);
            Assert.DoesNotMatch(updateRealEstate.Floor.ToString(), createRealEstate.Floor.ToString());
        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenNotUpdateDatata()
        {
            RealEstateDto dto = MockRealEstateData(); //mock!!!
            await Svc<IRealEstatesServices>().Create(dto);

            RealEstateDto nullUpdate = MockNullRealEstate(); //mock
            await Svc<IRealEstatesServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private RealEstateDto MockNullRealEstate()
        {
            RealEstateDto nullDto = new()
            {
                Id = null,
                Address = "Marika",
                SizeSqrM = 123,
                RoomCount = 5,
                Floor = 10,
                BuildingType = "Kivi",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now.AddYears(1),
                UpdatedAt = DateTime.Now.AddYears(1),
            
            };

            return nullDto;
        }

        private RealEstateDto MockUpdateRealEstateData()
        {
            RealEstateDto update = new()
            {
                Address = "Sõle",
                SizeSqrM = 45,
                RoomCount = 2,
                Floor = 1,
                BuildingType = "Kivikised",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            return update;
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realestate = new()
            {
                Address = "Sõle",
                SizeSqrM = 50,
                RoomCount = 3,
                Floor = 3,
                BuildingType = "-",
                BuiltInYear = DateTime.Now,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };

            return realestate;
        }
    }
}
