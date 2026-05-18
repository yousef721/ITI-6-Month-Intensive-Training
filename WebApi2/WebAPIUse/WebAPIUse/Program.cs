using System.Net.Http.Json;

namespace WebAPIUse;

class Program
{
    static async Task Main(string[] args)
    {
        HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("http://localhost:5114/api/");

        // read
        HttpResponseMessage readResponse = await client.GetAsync("courses");

        if (readResponse.IsSuccessStatusCode)
        {
            List<Course>? courses =
                await readResponse.Content.ReadFromJsonAsync<List<Course>>();

            if (courses != null)
            {
                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.id} - {course.name}");
                }
            }
        }

        // Create
        var postCourse = new Course(){name = "Angular", desc = "Description Angular", duration = 0};
        HttpResponseMessage createResponse = await client.PostAsJsonAsync("courses", postCourse);
        if (createResponse.IsSuccessStatusCode)
        {
            Uri uri = createResponse.Headers.Location!;
        }

        // Update
        postCourse.duration = 50;
        HttpResponseMessage updateResponse = await client.PutAsJsonAsync("courses", postCourse);

        // delete
        HttpResponseMessage deleteResponse = await client.DeleteAsync("courses/1003");
    }
}
