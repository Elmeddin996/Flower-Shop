namespace Flowers.UI.Models
{
    public class SliderCreateRequest
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public IFormFile Image { get; set; }
    }
}
