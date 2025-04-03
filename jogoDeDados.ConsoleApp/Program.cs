using System;
using System.ComponentModel.Design;

namespace jogoDeDados.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int limiteLinhaChegada = 30;

            while (true)
            {
                int posicaoUsuario = 0;
                int posicaoComputador = 0;
                bool jogoEstaEmAndamento = true;

                while (jogoEstaEmAndamento)
                {
                    // Turno do Jogador
                    ExibirCabecalho("Usuário");

                    int resultado = LancarDado();

                    ExibirResultadoSorteio(resultado);

                    posicaoUsuario += resultado;

                    // Evento de rodada extra
                    if (resultado == 6)
                    {
                        Console.WriteLine("Você tirou 6! Ganhou uma rodada extra!");
                        resultado = LancarDado();
                        ExibirResultadoSorteio(resultado);
                        posicaoUsuario += resultado;
                    }

                    //Evendo de avanço extra
                    if (posicaoUsuario == 5 || posicaoUsuario == 10 || posicaoUsuario == 15)
                    {
                        Console.WriteLine("Parabéns! Você caiu em uma posição de avanço extra e avança +3 casas!");
                        posicaoUsuario += 3;
                    }

                    //Evento de recuo
                    if (posicaoUsuario == 7 || posicaoUsuario == 13 || posicaoUsuario == 20)
                    {
                        Console.WriteLine("Que pena! Você caiu em uma posição de recuo e volta -2 casas!");
                        posicaoUsuario -= 2;
                    }

                    if (posicaoUsuario >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Parabéns, você alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O jogador está na posição: {posicaoUsuario} de {limiteLinhaChegada}");

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();

                    //Turno do Computador
                    ExibirCabecalho("Computador");

                    int resultadoComputador = LancarDado();

                    ExibirResultadoSorteio(resultadoComputador);

                    posicaoComputador += resultadoComputador;

                    // Evento de rodada extra
                    if (resultado == 6)
                    {
                        Console.WriteLine("O computador tirou 6 e ganhou uma rodada extra!");
                        resultadoComputador = LancarDado();
                        ExibirResultadoSorteio(resultadoComputador);
                        posicaoComputador += resultadoComputador;
                    }

                    //Evendo de avanço extra
                    if (posicaoComputador == 5 || posicaoComputador == 10 || posicaoComputador == 15)
                    {
                        Console.WriteLine("O computador caiu em uma posição de avanço extra e avança +3 casas!");
                        posicaoComputador += 3;
                    }

                    //Evento de recuo
                    if (posicaoComputador == 7 || posicaoComputador == 13 || posicaoComputador == 20)
                    {
                        Console.WriteLine("O computador caiu em uma posição de recuo e volta -2 casas!");
                        posicaoComputador -= 2;
                    }

                    if (posicaoComputador >= limiteLinhaChegada)
                    {
                        Console.WriteLine("Que pena! O computador alcançou a linha de chegada!");
                        Console.ReadLine();

                        jogoEstaEmAndamento = false;
                        continue;
                    }
                    else
                        Console.WriteLine($"O computador está na posição: {posicaoComputador} de {limiteLinhaChegada}");

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Pressione ENTER para continuar...");

                    Console.ReadLine();
                }

                string opcaoContinuar = ExibirMenuContinuar();


                if (opcaoContinuar != "S")
                    break;
            }
        }

        static void ExibirCabecalho(string nomeJogador)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Jogo dos Dados");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Turno do: {nomeJogador} ");
            Console.WriteLine("-----------------------------------------");

            if (nomeJogador != "Computador")
            {
                Console.Write("Pressione ENTER para lançar o dado...");
                Console.ReadLine();
            }

            
        }

        static int LancarDado()
        {
            Random geradorDeNumeros = new Random();

            int resultado = geradorDeNumeros.Next(1, 7);

            return resultado;
        }

        static void ExibirResultadoSorteio(int resultado)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"O valor sorteado foi: {resultado}");
            Console.WriteLine("-----------------------------------------");

             
        }

        static string ExibirMenuContinuar()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Deseja continuar? (S/N) ");
            string opcaoContinuar = Console.ReadLine()!.ToUpper();
            return opcaoContinuar;
        }
    }
}
