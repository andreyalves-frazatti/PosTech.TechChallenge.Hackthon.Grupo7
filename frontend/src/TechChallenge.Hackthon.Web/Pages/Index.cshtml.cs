using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Site.Pages.Model;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Site.Pages
{
    public class CadastroModel : PageModel
    {

        [BindProperty]
        public IFormFile video { get; set; }

        private readonly IConfiguration _configuration;
        public CadastroModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //string apiUrl = _configuration.GetSection("ApiSettings:ApiUrl").Value;


            //var UrlImage = apiUrl + "/imagem/" + CadastroRealizado.Id;
            //using (var form = new MultipartFormDataContent())
            //{
            //    using (var fileStream = Imagem.OpenReadStream())
            //    {
            //        //form.Add(new StringContent(CadastroRealizado.Id.ToString()), "CadastroId");
            //        form.Add(new StreamContent(fileStream), "file", Imagem.FileName);

            //        //Console.WriteLine(form);
            //        using (var response = await httpClient.PostAsync(UrlImage, form))
            //        {
            //            // Trate a resposta da chamada REST como desejado
            //            if (response.IsSuccessStatusCode)
            //            {
            //                TempData["SucessoMensagem"] = "Gravação realizada com sucesso!";
            //                return RedirectToPage("/Index");
            //                //return Page();
            //            }
            //            else
            //            {
            //                TempData["ErroMensagem"] = response.RequestMessage.ToString();
            //                return Page();
            //            }
            //        }
            //    }
            //}
            return Page();
        }
    }
}