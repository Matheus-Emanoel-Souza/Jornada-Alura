class Musica
{
    public string Nome { get; set; }
    public string Artista {  get; set; }
    public int Duracao {  get; set; }
    public bool Disponivel {  get; set; }
    public string NomeCompleto { get; }


    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nomes da música {Nome}");
        Console.WriteLine($"Artista:{Artista}");
        Console.WriteLine($"Duração:{Duracao}");
        if (Disponivel)
        {
            Console.WriteLine($"Disponível no plano");
        }
        else 
        {
            Console.WriteLine("Adquira o plano PLUS+");
        }

    }
}
