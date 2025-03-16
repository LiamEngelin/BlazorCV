using BlazorCV.Models;

namespace BlazorCV.Services
{
    public class ProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _httpClient.GetFromJsonAsync<List<Project>>("api/project") ?? new List<Project>();
        }

        public async Task<bool> AddProject(Project project)
        {
            var response = await _httpClient.PostAsJsonAsync("api/projects", project);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditProject(Project project)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/project/{project.Id}", project);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveProject(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/project/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
