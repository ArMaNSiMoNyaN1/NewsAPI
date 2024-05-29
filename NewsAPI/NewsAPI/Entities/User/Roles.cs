using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]

public enum Roles
{
    User,
    Journalist,
    Editor,
    Admin,
}