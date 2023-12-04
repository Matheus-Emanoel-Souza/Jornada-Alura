class Musica
{
    public string nome;
    public string artista;
    public int duracao;
    public bool Disponivel {  get; set; }

    
    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nomes da música {nome}");
        Console.WriteLine($"Artista:{artista}");
        Console.WriteLine($"Duração:{duracao}");
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
