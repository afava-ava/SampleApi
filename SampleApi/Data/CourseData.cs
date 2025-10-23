using SampleApi.Model;
using System.Text.Json;

namespace SampleApi.Data
{
    public class CourseData
    {
        public List<User> Users { get; private set; }

        public CourseData()
        {
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Data",
                "coursedata.json");

            string json = File.ReadAllText(filePath);

            Users = JsonSerializer.Deserialize<List<User>>(json, jsonOptions) ?? [];
        }
    }
}
