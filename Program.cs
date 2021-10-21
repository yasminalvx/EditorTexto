//Program.cs
//O programa Abre e Cria arquivo.txt
using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar arquivo");
            Console.WriteLine("0 - Sair");

            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: Abrir(); break;
                case 2: Criar(); break;
                case 0: System.Environment.Exit(0); break;
                default: Menu(); break;
            }

        }
        static void Abrir() 
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            var path = Console.ReadLine(); //caminho onde o arquivo está armazenado 

            using(var file = new StreamReader(path)) //abre e fecha o arquivo
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.ReadLine(); //esperar ENTER
            Menu();
        }
        static void Criar() 
        {
            Console.Clear();

            string text = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Digite seu texto abaixo (ESC para sair):\n");
                Console.Write(text);

                text += Console.ReadLine();
                text += "\n";

                Console.WriteLine("ENTER continuar ESC para sair");
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape); //enquanto o usuário não digitar ESC não vai sair do loop
            
            Console.WriteLine(" exemplo"); //para exibir \n como primeiro caractere do próximo Console.WriteLine();
            Salvar(text);
        }

        static void Salvar(string text) 
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");

            var path = Console.ReadLine(); //caminho onde o arquivo vai ser armezenado 
            
            using(var file = new StreamWriter(path)) //abre e fecha o arquivo
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path}salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}
