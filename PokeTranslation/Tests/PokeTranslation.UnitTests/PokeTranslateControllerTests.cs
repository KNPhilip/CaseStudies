namespace PokeTranslation.UnitTests;

public class PokeTranslateControllerTests
{
    private readonly PokeTranslateController _pokeTranslateController;
    private readonly Mock<IPokeTranslateService> _pokeTranslateService;
    private readonly Fixture _fixture;

    public PokeTranslateControllerTests()
    {
        _pokeTranslateService = new Mock<IPokeTranslateService>();
        _pokeTranslateController = new PokeTranslateController(_pokeTranslateService.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task TranslatePokemonAsync_ValidPokemonResponse_Returns200Ok()
    {
        // Arrange
        _pokeTranslateService.Setup(service => service.TranslatePokemonAsync(It.IsAny<string>()))
            .ReturnsAsync(ResponseDto<string>.SuccessResponse(_fixture.Create<string>()));

        // Act
        IActionResult result = await _pokeTranslateController.TranslatePokemonAsync("charmander");

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task TranslatePokemonAsync_NonValidPokemonResponse_Returns404NotFound()
    {
        // Arrange
        _pokeTranslateService.Setup(service => service.TranslatePokemonAsync(It.IsAny<string>()))
            .ReturnsAsync(ResponseDto<string>.SuccessResponse(null));

        // Act
        IActionResult result = await _pokeTranslateController.TranslatePokemonAsync("charmander");

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task TranslatePokemonAsync_WithAPIError_Returns400BadRequest()
    {
        // Arrange
        _pokeTranslateService.Setup(service => service.TranslatePokemonAsync(It.IsAny<string>()))
            .ReturnsAsync(ResponseDto<string>.ErrorResponse("Something went wrong in the Pokemon API!"));

        // Act
        IActionResult result = await _pokeTranslateController.TranslatePokemonAsync("charmander");

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}