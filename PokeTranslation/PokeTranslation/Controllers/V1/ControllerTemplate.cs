namespace PokeTranslation.Controllers.V1
{
    /// <summary>
    /// Controller Template - Contains the common definition for all controllers
    /// as well as methods for handling common Controller logic. Derives from the ControllerBase class.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ControllerTemplate : ControllerBase
    {
        /// <summary>
        /// Handles a response in the ResponseDto format and
        /// gives back the appropriate status code and potential data or error message.
        /// </summary>
        /// <typeparam name="T">Represents the data.</typeparam>
        /// <returns>Status code (depending on the result), and with that either the data,
        /// or a proper error message.</returns>
        protected IActionResult HandleResult<T>(ResponseDto<T> response) =>
            response.Success
                ? response.Data is null
                    ? NotFound()
                    : Ok(response.Data)
                : BadRequest(response.Message);
    }
}