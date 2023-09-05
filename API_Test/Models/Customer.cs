using System.Text.Json.Serialization;

namespace API_Test.Models;

public class Customer
{
    [JsonIgnore]
    public int Id { get; set; } //This is auto incremented

    public string FirstName { get; set; }

    public string LastName { get; set; }
}