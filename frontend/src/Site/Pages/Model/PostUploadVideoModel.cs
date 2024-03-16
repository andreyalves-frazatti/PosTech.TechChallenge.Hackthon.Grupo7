namespace Site.Pages.Model
{
    public class PostUploadVideoModel
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public IFormFile UploadedVideo { get; set; }
    }
}
