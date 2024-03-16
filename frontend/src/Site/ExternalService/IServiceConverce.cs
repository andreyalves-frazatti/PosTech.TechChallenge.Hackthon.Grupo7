using Site.Pages.Model;

namespace Site.ExternalService
{
    public interface IServiceConverce
    {
        List<Processamentos> GetProcessamentos();
        void PostUploadVideoModel(PostUploadVideoModel video);
    }
}
