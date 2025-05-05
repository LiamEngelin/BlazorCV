using BlazorCV.Models;

namespace BlazorCV.Services
{
    public class SkillService
    {
        private readonly HttpClient _http;

        public SkillService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Skill>> GetSkills()
        {
            return await _http.GetFromJsonAsync<List<Skill>>("api/skill") ?? new();
        }

        public async Task<bool> AddSkill(Skill skill)
        {
            var response = await _http.PostAsJsonAsync("api/skill", skill);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EditSkill(Skill skill)
        {
            var response = await _http.PutAsJsonAsync($"api/skill/{skill.Id}", skill);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveSkill(int id)
        {
            var response = await _http.DeleteAsync($"api/skill/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}