namespace Site.Pages.Model
{
    public class ListaDeProcessamentosViewModel
    {
        public List<Processamentos> Processamentos = new List<Processamentos>();

        public ListaDeProcessamentosViewModel()
        {
            Processamentos.Add(new Processamentos());
            Processamentos.Add(new Processamentos());
            Processamentos.Add(new Processamentos());
        }

        public List<Processamentos> GetlistaProcessamentos()
        { 
                return Processamentos; 
        }
    }
}
