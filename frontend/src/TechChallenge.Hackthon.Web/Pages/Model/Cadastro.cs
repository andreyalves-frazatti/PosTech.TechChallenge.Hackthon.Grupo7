using System.ComponentModel.DataAnnotations;

namespace Site.Pages.Model
{
    public class Cadastro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = " ";
        public string Email { get; set; } = " ";
        public string Telefone { get; set; } = " ";
        public string Endereco { get; set; } = " ";
        public string Complemento { get; set; } = " ";
        public string Bairro { get; set; } = " ";
        public string Municipio { get; set; } = " ";
        public string Imagem { get; set; } = " ";
    }
}
