using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Get_StudentCase_Batch;

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
var studentError = true;
foreach (var line in File.ReadLines("events.jsonl"))
{
    if (string.IsNullOrWhiteSpace(line))
        continue;

    var evt = JsonSerializer.Deserialize<JsonElement>(line, options);

    var type = evt.GetProperty("type").GetString();
    var eventId = evt.GetProperty("eventId").GetString();
    
    string studentId = "";

    // TODO: route to handlers, insert into DB, etc
    if (type == "student_registrert")
    {

        using var content = new StringContent(
            line,
            Encoding.UTF8,
            "application/json");

        var response = await http.PostAsync("/Event", content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Feil ved student registrering: {response.StatusCode} - {error}");
            studentError = true;
            continue;
        }

        var result = await response.Content.ReadFromJsonAsync<CreateEventResponseDTO>();

      
        studentId = result!.StudentId;
        studentError = false;
        Console.WriteLine("Student registrert: " + studentId);
    }
    else 
    {
        if (studentError)
            continue;
        var node = JsonNode.Parse(line)!.AsObject();

        node["studentId"] = studentId; // your value

        var lineWithStudentId = node.ToJsonString();

        using var content = new StringContent(
            lineWithStudentId,
            Encoding.UTF8,
            "application/json");

        
        var response = await http.PostAsync("/Event", content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"❌ Feil ved kurs registrering: {response.StatusCode} - {error}");
            continue;
        }
 
        Console.WriteLine("Kurs registrert: " + node["course"]);
    }
}



Console.ReadLine();