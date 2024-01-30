namespace PokeTranslation.Models
{
    /// <summary>
    /// The ResponseDto class is a class for handling potential errors, successes, and data.
    /// This is useful for a controller to easily respond with the appropriate status code.
    /// In my case here, I am using it to avoid fat controllers.
    /// </summary>
    /// <typeparam name="T">Represents the type of data the Service Response contains.</typeparam>
    public class ResponseDto<T>
    {
        /// <summary>
        /// The Data property is a nullable type of T.
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Represents the error message if the request was unsuccessful.
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// Represents whether or not the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Sends a successful response back to the controller.
        /// </summary>
        /// <param name="data">Represents the given data to be set within the ResponseDto.</param>
        /// <returns>Successful response to the controller.</returns>
        public static ResponseDto<T> SuccessResponse(T? data) =>
            data is null ? new() { Success = true } : new() { Data = data, Success = true };
        
        /// <summary>
        /// Sends an error response back to the controller.
        /// </summary>
        /// <param name="error">Represents the error message to send back.</param>
        /// <returns>Failure response to the controller.</returns>
        public static ResponseDto<T> ErrorResponse(string error) =>
            new() { Message = error };
    }
}