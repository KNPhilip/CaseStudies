using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeTranslation.UnitTests;

public class PokeTranslateServiceTests
{
    private readonly PokeTranslateService _pokeTranslateService;
    private readonly Mock<HttpClient> _httpClient;
    private readonly Fixture _fixture;

    public PokeTranslateServiceTests()
    {
        _httpClient = new Mock<HttpClient>();
        _pokeTranslateService = new PokeTranslateService(_httpClient.Object);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task TranslatePokemonAsyncc_ValidPokemonResponse_TrueSuccess()
    {
        // Arrange
        HttpResponseMessage mockResponse = new()
        {
            Content = new StringContent("Your mock response content here"),
            StatusCode = System.Net.HttpStatusCode.OK
        };

        ShakespearRoot root = _fixture.Create<ShakespearRoot>();
        string jsonContent = JsonSerializer.Serialize(root);

        HttpResponseMessage secondMock = new()
        {
            Content = new StringContent(jsonContent),
            StatusCode = System.Net.HttpStatusCode.OK
        };
        
        _httpClient
            .Setup(client => client.GetAsync(It.IsAny<string>()))
            .ReturnsAsync(mockResponse);
        
        _httpClient
            .Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<FormUrlEncodedContent>()))
            .ReturnsAsync(secondMock);

        // Act
        ResponseDto<string> result = await _pokeTranslateService.TranslatePokemonAsync("charmander");

        // Assert
        Assert.True(result.Success);
    }
}