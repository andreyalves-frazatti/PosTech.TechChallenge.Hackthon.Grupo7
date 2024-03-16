using Azure;
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
        public IFormFile Video { get; set; }

        public IFormFile Imagem { get; set; }

        public ListaDeProcessamentosViewModel viewModel { get; set; }

        private readonly IConfiguration _configuration;
        public CadastroModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //string apiUrl = _configuration.GetSection("ApiSettings:ApiUrl").Value;

            //var httpClient = new HttpClient();
            //var url = apiUrl + "/Cadastro";
            //var dados = new {  };

            //// Converter os dados para JSON
            //var json = JsonConvert.SerializeObject(dados);
            ////Console.WriteLine(json);


            //var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

            //var resposta = await httpClient.PostAsync(url, conteudo);

            //if (!resposta.IsSuccessStatusCode)
            //{
            //    TempData["ErroMensagem"] = resposta.RequestMessage.ToString();
            //    return Page();
            //}
            //var responseContent = await resposta.Content.ReadAsStringAsync();
            //var CadastroRealizado = JsonConvert.DeserializeObject<Cadastro>(responseContent);

            //if (Imagem == null)
            //{
            //    TempData["SucessoMensagem"] = "Gravação realizada com sucesso!";
            //    return RedirectToPage("/Index");
            //}

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

        public async Task<IActionResult> OnGetAsync()
        {
            viewModel = new ListaDeProcessamentosViewModel();
            return Page();
            
        }
    }
}