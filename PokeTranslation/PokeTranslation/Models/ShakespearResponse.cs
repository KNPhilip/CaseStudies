namespace PokeTranslation.Models
{
    /// <summary>
    /// Class representing the response from the Shakespear API.
    /// This is not made by me, credits goes to: https://json2csharp.com
    /// </summary>
    public class ShakespearRoot
    {
        public Success? success { get; set; }
        public Contents? contents { get; set; }
        public Error? error { get; set; }
    } 

    public class Contents
    {
        public string? translated { get; set; }
        public string? text { get; set; }
        public string? translation { get; set; }
    }

    public class Success
    {
        public int total { get; set; }
    }

    public class Error
    {
        public int code { get; set; }
        public string? message { get; set; }
    }
}