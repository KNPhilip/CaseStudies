namespace PokeTranslation.Services.PokeTranslateService
{
    /// <summary>
    /// Implementation class of the IPokeTranslateService interface.
    /// </summary>
    /// <param name="httpClient">HttpClient injected through the primary constructur,
    /// used to call the external services.</param>
    public class PokeTranslateService(HttpClient httpClient) : IPokeTranslateService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<ResponseDto<string>> TranslatePokemonAsync(string request)
        {
            // Retrieves the pokemon's description from the PokeAPI.
            HttpResponseMessage pokemonResponse = await _httpClient
                .GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{request}");

            // Return NotFound if the pokemon is unavailable.
            if (pokemonResponse.StatusCode == HttpStatusCode.NotFound)
                return ResponseDto<string>.SuccessResponse(null);
            else if (pokemonResponse.IsSuccessStatusCode)
            {
                // Use the custom PokemonRoot class to represent the response.
                PokemonRoot? pokemonContent = await pokemonResponse.Content
                    .ReadFromJsonAsync<PokemonRoot>();

                // Retrieves the first flavor text entry in english.
                FlavorTextEntry? flavorTextEntry = pokemonContent?.flavor_text_entries!
                    .FirstOrDefault(entry => entry.language!.name == "en");

                if (flavorTextEntry is not null)
                {
                    // Puts the flavor text entry into a dictionary and modifies it.
                    Dictionary<string, string> formData = new()
                    {
                        { "text", flavorTextEntry.flavor_text!.Replace("\n", " ").Replace("\f", " ") }
                    };

                    // Retrieve the Shakespeare translation from the Shakespear API.
                    HttpResponseMessage shakespearResponse = await _httpClient
                        .PostAsync("https://api.funtranslations.com/translate/shakespeare.json", new FormUrlEncodedContent(formData));

                    // As before, we use a custom class for representing the response from the API.
                    ShakespearRoot? shakespearContent = await shakespearResponse.Content
                        .ReadFromJsonAsync<ShakespearRoot>();

                    // In case of at least one successful retrieval, and a success status code, we return the response.
                    if (shakespearResponse.IsSuccessStatusCode && shakespearContent?.success!.total > 0)
                        return ResponseDto<string>.SuccessResponse(
                            $"Congratulations! You got an available response in english from your input \"{request}\"! " +
                            $"Here's a description of your pokemon - {flavorTextEntry.flavor_text} " +
                            $"Ah! You're a fan of shakespear I heard? Well, another way of describing would be: {shakespearContent?.contents!.translated}"
                        );
                    // In case we used all of our API calls for the hour, we return an error response.
                    else if (shakespearContent?.error!.code == 429)
                        return ResponseDto<string>.ErrorResponse(
                            "You've exceeded the rate limit for the Shakespeare API. " +
                            "Please try again later."
                        );
                    else
                        throw new Exception("Something went wrong in the Shakespear API!");
                }
                else return ResponseDto<string>
                    .ErrorResponse("No flavor text entry found for English language.");

            }
            else return ResponseDto<string>
                .ErrorResponse("Something went wrong in the Pokemon API!");
        }
    }
}