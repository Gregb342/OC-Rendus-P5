using Moq;
using OC_P5.Data.Repositories.Interfaces;
using OC_P5.Models;
using OC_P5.Services;
using OC_P5.ViewModels;
using OC_P5.Services.Interfaces;

namespace OC_P5.Tests.Services
{
    [TestClass]
    public class CarServiceTests
    {
        private Mock<ICarRepository> _mockCarRepository;
        private Mock<ICarModelRepository> _mockCarModelRepository;
        private Mock<ICarBrandRepository> _mockCarBrandRepository;
        private Mock<ICarTrimRepository> _mockCarTrimRepository;
        private Mock<IMediaRepository> _mockMediaRepository;
        private Mock<ISaleService> _mockSaleService;
        private Mock<IPurchaseService> _mockPurchaseService;
        private Mock<IRepairService> _mockRepairService;
        private CarService _carService;

        [TestInitialize]
        public void SetUp()
        {
            _mockCarRepository = new Mock<ICarRepository>();
            _mockCarModelRepository = new Mock<ICarModelRepository>();
            _mockCarBrandRepository = new Mock<ICarBrandRepository>();
            _mockCarTrimRepository = new Mock<ICarTrimRepository>();
            _mockMediaRepository = new Mock<IMediaRepository>();
            _mockSaleService = new Mock<ISaleService>();
            _mockPurchaseService = new Mock<IPurchaseService>();
            _mockRepairService = new Mock<IRepairService>();

            _carService = new CarService(
                _mockCarRepository.Object,
                _mockCarModelRepository.Object,
                _mockCarBrandRepository.Object,
                _mockCarTrimRepository.Object,
                _mockMediaRepository.Object,
                _mockSaleService.Object,
                _mockPurchaseService.Object,
                _mockRepairService.Object
            );
        }

        // Test pour GetAllCarsAsync
        [TestMethod]
        public async Task GetAllCarsAsync_ReturnsCarViewModels()
        {
            // Arrange
            var cars = new List<Car>
            {
                new Car { Id = 1, Label = "Car 1", CarBrandId = 1, CarModelId = 1, YearOfProductionId = 1},
                new Car { Id = 2, Label = "Car 2", CarBrandId = 1, CarModelId = 2, YearOfProductionId = 2 }
            };
            _mockCarRepository.Setup(r => r.GetAllCarsAsync()).ReturnsAsync(cars);

            _mockCarBrandRepository.Setup(r => r.GetCarBrandByIdAsync(It.IsAny<int>())).ReturnsAsync(new CarBrand { Id = 1, Brand = "Brand 1" });
            _mockCarModelRepository.Setup(r => r.GetCarModelByIdAsync(It.IsAny<int>())).ReturnsAsync(new CarModel { Id = 1, Model = "Model 1" });

            // Act
            var result = await _carService.GetAllCarsAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Car 1", result.First().Label);
        }

        // Test pour GetCarByIdAsync
        [TestMethod]
        public async Task GetCarByIdAsync_ReturnsCorrectCarViewModel()
        {
            // Arrange
            var car = new Car { Id = 1, Label = "Car 1", CarBrandId = 1, CarModelId = 1, YearOfProductionId = 1 };
            _mockCarRepository.Setup(r => r.GetCarByIdAsync(1)).ReturnsAsync(car);
            _mockCarBrandRepository.Setup(r => r.GetCarBrandByIdAsync(1)).ReturnsAsync(new CarBrand { Id = 1, Brand = "Brand 1" });
            _mockCarModelRepository.Setup(r => r.GetCarModelByIdAsync(1)).ReturnsAsync(new CarModel { Id = 1, Model = "Model 1" });

            // Act
            var result = await _carService.GetCarByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Car 1", result.Label);
            Assert.AreEqual("Brand 1", result.BrandName);
        }

        // Test pour AddCarAsync
        [TestMethod]
        public async Task AddCarAsync_CreatesNewCar()
        {
            // Arrange
            var carViewModel = new CarViewModel { Label = "New Car", CarBrandId = 1, CarModelId = 1, YearOfProductionId = 2020 };
            _mockCarModelRepository.Setup(r => r.GetCarModelByIdAsync(carViewModel.CarModelId)).ReturnsAsync(new CarModel { Id = 1, CarBrandId = 1 });

            // Act
            var result = await _carService.AddCarAsync(carViewModel);

            // Assert
            _mockCarRepository.Verify(r => r.AddCarAsync(It.IsAny<Car>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual("New Car", result.Label);
        }

        // Test pour UpdateCarAsync
        [TestMethod]
        public async Task UpdateCarAsync_UpdatesExistingCar()
        {
            // Arrange
            var carViewModel = new CarViewModel { Label = "Updated Car", CarBrandId = 1, CarModelId = 1, YearOfProductionId = 2020 };
            var car = new Car { Id = 1, Label = "Car 1", CarBrandId = 1, CarModelId = 1, YearOfProductionId = 1 };

            _mockCarRepository.Setup(r => r.GetCarByIdAsync(1)).ReturnsAsync(car);
            _mockCarModelRepository.Setup(r => r.GetCarModelByIdAsync(carViewModel.CarModelId)).ReturnsAsync(new CarModel { Id = 1, CarBrandId = 1 });

            // Act
            await _carService.UpdateCarAsync(1, carViewModel);

            // Assert
            _mockCarRepository.Verify(r => r.UpdateCarAsync(It.IsAny<Car>()), Times.Once);
            Assert.AreEqual("Updated Car", car.Label);
        }

        // Test pour DeleteCarAsync
        [TestMethod]
        public async Task DeleteCarAsync_DeletesCar()
        {
            // Act
            await _carService.DeleteCarAsync(1);

            // Assert
            _mockCarRepository.Verify(r => r.DeleteCarAsync(1), Times.Once);
        }

        // Test pour GetCarModelByBrandIdAsync
        [TestMethod]
        public async Task GetCarModelByBrandIdAsync_ReturnsCarModels()
        {
            // Arrange
            var carModels = new List<CarModel>
            {
                new CarModel { Id = 1, Model = "Model 1", CarBrandId = 1 },
                new CarModel { Id = 2, Model = "Model 2", CarBrandId = 1 }
            };
            _mockCarModelRepository.Setup(r => r.GetCarModelsByBrandIdAsync(1)).ReturnsAsync(carModels);

            // Act
            var result = await _carService.GetCarModelByBrandIdAsync(1);

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        // Test pour ValidateCarModelWithBrandAsync
        [TestMethod]
        public async Task ValidateCarModelWithBrandAsync_ValidatesCorrectly()
        {
            // Arrange
            _mockCarModelRepository.Setup(r => r.GetCarModelByIdAsync(1)).ReturnsAsync(new CarModel { Id = 1, CarBrandId = 1 });

            // Act
            var result = await _carService.ValidateCarModelWithBrandAsync(1, 1);

            // Assert
            Assert.IsTrue(result);
        }

        // Test pour GetCarMediaAsync
        [TestMethod]
        public async Task GetCarMediaAsync_ReturnsMedia()
        {
            // Arrange
            var media = new List<Media> { new Media { Id = 1, Path = "path.jpg"} };
            _mockMediaRepository.Setup(r => r.GetMediaByCarAsync(1)).ReturnsAsync(media);

            // Act
            var result = await _carService.GetCarMediaAsync(1);

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        // Test pour CarExistsAsync
        [TestMethod]
        public async Task CarExistsAsync_ReturnsTrueIfCarExists()
        {
            // Arrange
            _mockCarRepository.Setup(r => r.CarExistsAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _carService.CarExistsAsync(1);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
