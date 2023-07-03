using Flowers.UI.Filters;
using Flowers.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace Flowers.UI.Controllers
{
    [ServiceFilter(typeof(AuthFilter))]
    public class SliderController : Controller
    {
        HttpClient _client;
        public SliderController()
        {
            _client = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync("https://localhost:7128/api/Sliders/all"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<SliderGetAllResponse>>(content);

                    return View(data);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized || response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return RedirectToAction("login", "account");
            }
            return View("error");
        }

        public async Task<IActionResult> Create()
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateRequest slider)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            MultipartFormDataContent content = new MultipartFormDataContent();

            var fileContent = new StreamContent(slider.Image.OpenReadStream());
            fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(slider.Image.ContentType);

            content.Add(fileContent, "ImageFile", slider.Image.FileName);
            content.Add(new StringContent(slider.Title), "Title");
            content.Add(new StringContent(slider.Desc.ToString()), "Description");
            content.Add(new StringContent(slider.Order.ToString()), "Order");


            using (var respone = await _client.PostAsync("https://localhost:7128/api/Sliders", content))
            {
                if (respone.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                else if (respone.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(await respone.Content.ReadAsStringAsync());
                    foreach (var err in error.Errors) ModelState.AddModelError(err.Key, err.Message);

                    return View();
                }
            }

            return View("error");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            using (var response = await _client.GetAsync($"https://localhost:7128/api/Sliders/all/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    SliderGetResponse data = JsonConvert.DeserializeObject<SliderGetResponse>(responseContent);

                    var vm = new SliderGetResponse
                    {
                        Title = data.Title,
                        Desc = data.Desc,
                        Order = data.Order,
                        ImageName = data.ImageName
                    };

                    ViewBag.ImageName = data.ImageName;
                    return View(vm);
                }
            }
            return View("error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SliderUpdateRequest slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var token = Request.Cookies["auth_token"];
            _client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);

            MultipartFormDataContent content = new MultipartFormDataContent();

            if (slider.Image != null)
            {
                var fileContent = new StreamContent(slider.Image.OpenReadStream());
                fileContent.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(slider.Image.ContentType);
                content.Add(fileContent, "ImageFile", slider.Image.FileName);
            }

            content.Add(new StringContent(slider.Title), "Title");
            content.Add(new StringContent(slider.Desc.ToString()), "Description");
            content.Add(new StringContent(slider.Order.ToString()), "Order");

            using (var respone = await _client.PutAsync($"https://localhost:7128/api/Sliders/all/{id}", content))
            {
                if (respone.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                else if (respone.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var error = JsonConvert.DeserializeObject<ErrorResponseModel>(await respone.Content.ReadAsStringAsync());
                    foreach (var err in error.Errors) ModelState.AddModelError(err.Key, err.Message);


                    return View();
                }
            }

            return View("error");
        }
    }
}
