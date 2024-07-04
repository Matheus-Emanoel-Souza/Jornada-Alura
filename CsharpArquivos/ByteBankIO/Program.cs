using ByteBankIO;
using System;
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDoArquivo);
            // var linha = leitor.ReadLine();
            // var texto = leitor.ReadToEnd();
            // var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }
        Console.ReadLine();
    }
    static void EscreverBuffer(byte[]buffer)
    {
        var utf8 = new UTF8Encoding();//Conversão da codigicação de byts para texto.

        var texto = utf8.GetString(buffer);
        Console.Write(texto);
        //foreach (byte meubyte in buffer)
        //{
            
            //Console.Write(meubyte);
            //Console.Write(" ");
        //}
    }
}