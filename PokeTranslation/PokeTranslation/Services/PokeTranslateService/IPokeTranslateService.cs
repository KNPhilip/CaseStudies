namespace PokeTranslation.Services.PokeTranslateService
{
    /// <summary>
    /// Interface for Pokemon translation services.
    /// </summary>
    public interface IPokeTranslateService
    {
        /// <summary>
        /// Translates a given Pokemon's description by name.
        /// </summary>
        /// <param name="request">Name of the requested pokemon</param>
        /// <returns>A normal description and with shakespear translation of the pokemon.</returns>
        public Task<ResponseDto<string>> TranslatePokemonAsync(string request);
    }
}