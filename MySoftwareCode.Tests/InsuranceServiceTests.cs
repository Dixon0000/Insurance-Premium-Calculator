using MySoftwareCode;
using Moq;
using NUnit.Framework;

[TestFixture]
public class InsuranceServiceTests
{
    private Mock<IDiscountService> _discountServiceMock;
    private InsuranceService _insuranceService;

    [SetUp]
    public void Setup()
    {
        _discountServiceMock = new Mock<IDiscountService>();
        _insuranceService = new InsuranceService(_discountServiceMock.Object);
    }

    [TestCase(25, "rural", 5.0)]
    [TestCase(32, "rural", 3.5)]
    [TestCase(17, "rural", 0.0)]
    [TestCase(25, "urban", 6.0)]
    [TestCase(40, "urban", 5.0)]
    [TestCase(17, "urban", 0.0)]
    [TestCase(25, "unknown", 0.0)]
    public void CalcPremium_ValidCases_ReturnsExpectedPremium(int age, string location, double expectedPremium)
    {
        // Arrange
        _discountServiceMock.Setup(x => x.GetDiscount()).Returns(0.9);

        // Act
        double premium = _insuranceService.CalcPremium(age, location);

        // Assert
        Assert.AreEqual(expectedPremium, premium);
    }

    [Test]
    public void CalcPremium_AgeOver50WithDiscount_ReturnsDiscountedPremium()
    {
        // Arrange
        int age = 55;
        string location = "rural";
        double expectedPremium = 3.5 * 0.9;
        _discountServiceMock.Setup(x => x.GetDiscount()).Returns(0.9);

        // Act
        double premium = _insuranceService.CalcPremium(age, location);

        // Assert
        Assert.AreEqual(expectedPremium, premium);
    }
}
