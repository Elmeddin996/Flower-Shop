using Flowers.UI.Filters;
using Flowers.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;


namespace Flowers.UI.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class CategoryController : Controller
    {
        private HttpClient _client;
        public CategoryController()
        {
            _client = new HttpClient();
           
        }
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync("https://localhost:7128/api/Categories/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<CategoryGetAllResponse>>(content);

                    return View(data);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateRequest category)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            if (!ModelState.IsValid) return View();

            StringContent content = new StringContent(JsonConvert.SerializeObject(category), System.Text.Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:7128/api/Categories", content))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);

                    foreach (var item in error.Errors)
                        ModelState.AddModelError(item.Key, item.Message);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }

            return View("error");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync($"https://localhost:7128/api/Categories/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<CategoryGetResponse>(responseContent);
                    var vm = new CategoryUpdateRequest { Name = data.Name };

                    return View(vm);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryUpdateRequest category)
        {
            if (!ModelState.IsValid) return View();

            StringContent content = new StringContent(JsonConvert.SerializeObject(category), System.Text.Encoding.UTF8, "application/json");

            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
            using (var response = await _client.PutAsync($"https://localhost:7128/api/Categories/{id}", content))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index");
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(responseContent);

                    foreach (var item in error.Errors)
                        ModelState.AddModelError(item.Key, item.Message);

                    return View();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
            using (var response = await _client.DeleteAsync($"https://localhost:7128/api/Categories/{id}"))
            {
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("index","category");
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return Unauthorized();
            }
            return NotFound();
        }
    }
}
