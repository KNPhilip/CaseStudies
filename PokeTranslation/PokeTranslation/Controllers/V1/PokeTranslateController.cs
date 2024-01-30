namespace PokeTranslation.Controllers.V1
{
    /// <summary>
    /// Base of endpoints for the PokeTranslation API.
    /// </summary>
    /// <param name="pokeTranslateService">Injecting the PokeTranslateService through
    /// the IoC container in the prinmary constructor.</param>
    public class PokeTranslateController(IPokeTranslateService pokeTranslateService) : ControllerTemplate
    {
        private readonly IPokeTranslateService _pokeTranslateService = pokeTranslateService;

        /// <summary>
        /// Endpoint for translating a given Pokemon's description by name.
        /// </summary>
        /// <param name="pokemon">Name of the pokemon to look up</param>
        /// <returns>A normal and shakespear description of the requested pokemon.</returns>
        [HttpGet("{pokemon}")]
        public async Task<IActionResult> TranslatePokemonAsync(string pokemon) =>
            HandleResult(await _pokeTranslateService.TranslatePokemonAsync(pokemon));
    }
}