using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

using var http = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7014")
};

http.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

foreach (var line in File.ReadLines("events.jsonl"))
{
    if (string.IsNullOrWhiteSpace(line))
        continue;

    var evt = JsonSerializer.Deserialize<JsonElement>(line, options);

    var type = evt.GetProperty("type").GetString();
    var eventId = evt.GetProperty("eventId").GetString();


    // TODO: route to handlers, insert into DB, etc
    if(type == "student_registrert")
    {


        using var content = new StringContent(
            line,
            Encoding.UTF8,
            "application/json");

        var response = await http.PostAsync("/api/events", content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"❌ Failed: {response.StatusCode} - {error}");
        }
    }
}
