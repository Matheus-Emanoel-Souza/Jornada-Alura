using ByteBankIO;
using System;
using System.Text;
partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoarquivo = "contas.txt";
        
        using (var fluxodoarquivo = new FileStream(enderecoDoarquivo,FileMode.Open))
        {
            var leitor = new StreamReader(fluxodoarquivo);

            //var linha =  leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();

            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaConta = ConverterStringParaContaCorrente(linha);
                Console.WriteLine(linha);

                var msg = $"conta número {contaConta.Numero}, agencia {contaConta.Agencia}, saldo:{contaConta.Saldo}";
                Console.WriteLine(msg);
            }//Enquanto não chegar no fim do fluxo do arquivo, execute.

            //Console.WriteLine(numero);
        }
        Console.ReadLine();
    }
    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        var campo = linha.Split(',');
        var agencia = int.Parse(campo[0]);
        var numero = int.Parse(campo[1]);
        var saldo = double.Parse(campo[2].Replace('.',','));
        var nomeTitular = campo[3];


        var resultado = new ContaCorrente(agencia, numero, nomeTitular);
        resultado.Depositar(saldo);
        return resultado;
    }
}