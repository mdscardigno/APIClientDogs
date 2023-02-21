using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIClientDogs
{
    internal class Response
    {
        [JsonPropertyName("message")]
        public string[] Message { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}