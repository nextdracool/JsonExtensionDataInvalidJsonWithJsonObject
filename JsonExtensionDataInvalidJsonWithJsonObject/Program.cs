using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

var instance = new Extensible();

// output: {"Fixed":0,{}}
Console.WriteLine(JsonSerializer.Serialize(instance));

// still invalid when adding this
instance.Extension["foo"] = "bar";

// output: {"Fixed":0,{"foo":"bar"}}
Console.WriteLine(JsonSerializer.Serialize(instance));

class Extensible
{
	public int Fixed { get; set; }
	
	[JsonExtensionData]
	public JsonObject Extension { get; set; } = new();
}
