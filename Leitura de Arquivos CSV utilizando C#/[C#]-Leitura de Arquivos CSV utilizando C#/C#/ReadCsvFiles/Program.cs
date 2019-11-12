/*Aplicação de Exemplo para Leitura
 * de Arquivos CSV em C#
 * Desenvolvido por:
 * Julio Cesar Bueno de Arruda
 * julio.arruda@outlook.com
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Referencia Necessária para realizar a leitura do arquivo
using System.IO;

namespace ReadCsvFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________________________________________");
            Console.WriteLine();
            Console.WriteLine("Aplicação de Exemplo MSDN - Ler Arquivo CSV");
            Console.WriteLine();
            Console.WriteLine("___________________________________________");
            try
            {
                //Declaro o StreamReader para o caminho onde se encontra o arquivo
                StreamReader rd = new StreamReader(@"c:\txt\produtos.csv");
                //Declaro uma string que será utilizada para receber a linha completa do arquivo
                string linha = null;
                //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado
                string[] linhaseparada = null;
                //realizo o while para ler o conteudo da linha
                while ((linha = rd.ReadLine()) != null)
                {
                    //com o split adiciono a string 'quebrada' dentro do array
                    linhaseparada = linha.Split(';');
                    //aqui incluo o método necessário para continuar o trabalho

                }
                rd.Close();
            }
            catch
            {
                Console.WriteLine("Erro ao executar Leitura do Arquivo");
            }
        }
    }
}
