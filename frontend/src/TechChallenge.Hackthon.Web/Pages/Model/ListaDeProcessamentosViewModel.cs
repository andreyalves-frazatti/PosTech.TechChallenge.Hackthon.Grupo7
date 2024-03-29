﻿namespace TechChallenge.Pages.Model
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
