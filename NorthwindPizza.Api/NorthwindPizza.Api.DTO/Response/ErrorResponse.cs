// <copyright file="ErrorResponse.cs" company="NY Tech">
// ©️ 2026. All Rights Reserved.
// </copyright>

namespace NorthwindPizza.Api.DTO.Response;

using Newtonsoft.Json;

/// <summary>
/// This class represents the relevant error response.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// This is the relevant status code.
    /// </summary>
    [JsonProperty("statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// The relevant message with the error response.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;
}
