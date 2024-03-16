namespace Site.Pages.Model
{
    public class Processamentos
    {
        public string Id { get; set; }
        public string ArquivoZIP { get; set; }
        public int StatusProcessamento { get; set; }

        public Processamentos()
        {
            Id = Guid.NewGuid().ToString();
            ArquivoZIP = "";
            StatusProcessamento = 1;
        }
    }
}
