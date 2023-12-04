//Orientação Objeto Modulo 2 Aula 3

Musica musica1 = new Musica(); // criei um objeto com uma classe.
musica1.nome = "Roxane";
musica1.artista = "The Police";
musica1.duracao = 273;
musica1.EscreveDisponivel(false);


Musica musica2 = new Musica();
musica2.nome = "Vertigo";
musica2.artista = "U2";
musica2.duracao = 273;
musica1.EscreveDisponivel(false);

musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();


