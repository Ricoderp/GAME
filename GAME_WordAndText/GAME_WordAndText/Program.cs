using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


/*
 *  switch ()
    {
        case 1:
                            
            break;
        case 2:
                            
            break;
        case 3:
                            
            break;
        case 4:
                            
            break;
    }
*/
namespace GAME_WordAndText
{
    class Program
    {
        private static double timer = secs; //secs; //secs
        private static bool waySelected = false, end = false; //false - tempo acabou, true - tempo ON
        private static string palavra, texto, input;
        private static Timer aTimer;
        private static int totalPlayers, nPlayers, currentPlayer = 0, playersLost = 0, oldCursorPos;
        private static string p1, p2, p3, p4, pTimer;
        private static double secs;
        private static double rounds = 1.00, roundTime;
        

        //Método para limpar a linha da consola
        static void ClearLine()
        {
            int currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, currentLine);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        //Método que tenta para converter um para numeros inteiros
        static int converterInt(string a)
        {
            int b;
            //Repete o código enquanto não for possivel a conversão
            do
            {
                //se for possivel a conversão manda b de volta, se não for pede um numero inteiro
                if (!int.TryParse(a, out b))
                { 
                    Console.WriteLine("Erro, tem de introduzir um número inteiro");
                    a = Console.ReadLine();
                }
              
            } while (!int.TryParse(a, out b));
            return b;
        }

        //Trata de tudo relacionado com o numero de jogadores
        static void Players()
        {
            bool Erro = false;

            //Do while() para limitar o nr de jogadores a 4
            do
            {
                //if para caso o numero de jogadores seja inválido, mostrar uma mensagem de erro
                if (!Erro)
                {
                    Console.Clear();
                    Console.Write("Quantos jogadores (1-4 Jogadores): ");
                    input = Console.ReadLine();
                    nPlayers = converterInt(input);
                    Erro = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(nPlayers + " não é um número de jogadores válido - 1 a 4 Jogadores");
                    Console.Write("Quantos jogadores (1-4 Jogadores): ");
                    input = Console.ReadLine();
                    nPlayers = converterInt(input);
                }

            } while (nPlayers > 4 || nPlayers < 1);
            totalPlayers = nPlayers;


            switch (nPlayers)   //NOME DOS PLAYERS
            {
                case 1:
                    Console.Write("Nome do Jogador 1: ");
                    p1 = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Nome do Jogador 1: ");
                    p1 = Console.ReadLine();
                    Console.Write("Nome do Jogador 2: ");
                    p2 = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Nome do Jogador 1: ");
                    p1 = Console.ReadLine();
                    Console.Write("Nome do Jogador 2: ");
                    p2 = Console.ReadLine();
                    Console.Write("Nome do Jogador 3: ");
                    p3 = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Nome do Jogador 1: ");
                    p1 = Console.ReadLine();
                    Console.Write("Nome do Jogador 2: ");
                    p2 = Console.ReadLine();
                    Console.Write("Nome do Jogador 3: ");
                    p3 = Console.ReadLine();
                    Console.Write("Nome do Jogador 4: ");
                    p4 = Console.ReadLine();
                    break;


            }
            Console.Clear();
        }


        //Caso o tempo acabe e não tenha sido inserida uma palavra o jogador perde
        static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //caso boolean waySelected seja falso
            if (waySelected == false)
            {
                //caso o tempo acabe, desqualifica o jogador
                if (timer <= -0.5)
                {

                    //  PLAYER LOST
                    switch (currentPlayer)
                    {
                        case 1:
                            Console.SetCursorPosition(0, (4 + playersLost));
                            Console.WriteLine(p1 + " perdeu!!!");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine();
                            p1 = p2;
                            p2 = p3;
                            p3 = p4;
                            nPlayers = nPlayers - 1;
                            currentPlayer = currentPlayer - 1;
                            playersLost = playersLost + 1;
                            break;
                        case 2:
                            Console.SetCursorPosition(0, (4 + playersLost));
                            Console.WriteLine(p2 + " perdeu!!!");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine();
                            p2 = p3;
                            p3 = p4;
                            nPlayers = nPlayers - 1;
                            currentPlayer = currentPlayer - 1;
                            playersLost = playersLost + 1;
                            break;
                        case 3:
                            Console.SetCursorPosition(0, (4 + playersLost));
                            Console.WriteLine(p3 + " perdeu!!!");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine();
                            p3 = p4;
                            nPlayers = nPlayers - 1;
                            currentPlayer = currentPlayer - 1;
                            playersLost = playersLost + 1;
                            break;
                        case 4:
                            Console.SetCursorPosition(0, (4 + playersLost));
                            Console.WriteLine(p4 + " perdeu!!!");
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine();
                            nPlayers = nPlayers - 1;
                            currentPlayer = currentPlayer - 1;
                            playersLost = playersLost + 1;
                            break;
                    }
                    // ...

                    waySelected = true;

                    
                    if ((playersLost + 1) >= totalPlayers) //Quando o jogo acabar aka restar só um player
                    {
                        end = true;
                        Console.Clear();
                        Console.WriteLine(texto);
                        Console.WriteLine(p1 + " ganhou!!! Congratz!");
                        Console.Write("Clique 'Enter' para terminar...");
                        Console.ReadKey();
                        End();
                    }

                    Console.Write("Clique 'Enter' para continuar o jogo...");
                    do { } while (Console.ReadKey().Key != ConsoleKey.Enter);
                    ClearLine();
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

                    timer = timer - 0.5;

                    //  Clear a ao output
                    Console.SetCursorPosition(0, 0);
                    ClearLine();
                    Console.SetCursorPosition(0, 1);
                    ClearLine();
                    Console.SetCursorPosition(0, 2);
                    ClearLine();
                    Console.SetCursorPosition(0, 3);
                    ClearLine();
                    Console.SetCursorPosition(0, 0);

                    Main();

                }
                else
                {

                    //  Timer OUTPUT
                    pTimer = Convert.ToString(timer);

                    if (timer % 1 == 0) //QUANDO timer FOR INTEIRO PARA IMPRIMIR COM UMA CASA DECIMAL ADICIONA-SE...
                    {
                        pTimer = pTimer + ".0";
                    }
                    oldCursorPos = Console.CursorLeft;
                    Console.SetCursorPosition(10, 2);   //Posição do Output aseguir
                    switch (currentPlayer)
                    {
                        case 1:
                            Console.WriteLine(pTimer + " segundos! É a vez do " + p1 + "!");
                            break;
                        case 2:
                            Console.WriteLine(pTimer + " segundos! É a vez do " + p2 + "!");
                            break;
                        case 3:
                            Console.WriteLine(pTimer + " segundos! É a vez do " + p3 + "!");
                            break;
                        case 4:
                            Console.WriteLine(pTimer + " segundos! É a vez do " + p4 + "!");
                            break;
                    }
                    Console.SetCursorPosition(oldCursorPos, 3);
                    //  ...

                    timer = timer - 0.5;
                }
            }
            else
            {
                timer = 0;
                aTimer.Close();
            }

        }

        static void time()
        {
            //Limpa a consola e pede o tempo da primeira ronda
            do
            {
                Console.Clear();
                Console.Write("Quanto tempo para escrever palavra (segundos): ");
                secs = Convert.ToDouble(Console.ReadLine());
            } while (secs <= 0);

            //limpa a consola e pede a dificuldade por ronda
            do
            {
                Console.SetCursorPosition(0, 1);
                ClearLine();
                Console.SetCursorPosition(0, 1);
                Console.Write("Dificuldade 0 [Sem redução] to 10 [Hardcore - 50% Redução]: ");
                roundTime = Convert.ToDouble(Console.ReadLine());
            } while (roundTime > 10 || roundTime < 0);

            roundTime = roundTime / 20;
            Console.Clear();
        }

        static void Main()
        {
            if (playersLost == 0)   //PARA QUANDO UM PLAYER PERDER N VOLTAR A PERDIR A MESMAS COISAS
            {
                Console.Clear();

                //INSTRUCTIONS
                do
                {
                    Console.Clear();
                    Console.WriteLine("Este é um jogo criado por 'Ricode'. Este jogo é um jogo cooperativo e tem como  objetivo " +
                        "final escrever uma frase, com varios jogadores introduzindo uma e só uma palavra de cada vez. ");
                    Console.WriteLine("");
                    Console.WriteLine("Após selecionar o a informação sobre os jogadores, o utilizador terá de introduzir também: ");
                    Console.WriteLine(" - Tempo - O tempo introduzido, é o tempo que cada jogador tem para escrever a palavra." +
                        " Se esse tempo acabar, o jogador corrente perde!");
                    Console.WriteLine(" - Dificuldade - Quando a ronda acabar (todos os jogadores escreverem a sua palavra) " +
                        "o Tempo diminui, se a Dificuldade for igual a 10 - diminui metade, se for 0 - Tempo permanece sempre igual. ");
                    Console.WriteLine("");
                    Console.WriteLine("Se quiser pode terminar o jogo e ver a sua frase, basta quando for a introduzir a sua palavra," +
                        "escrever um ponto '.'");
                    Console.WriteLine("");
                    Console.WriteLine("Bom jogo!");
                    Console.Write("Pressione 'Enter' para prosseguir...");
                } while (Console.ReadKey().Key != ConsoleKey.Enter);

                Players(); //Summon à informação dos players
                time(); //Timers defenidos
            }

            //  VAR SECTION
            string espaco = " ";
            int pos;
            //  ...

            //  TIMER SECTION
            aTimer = new Timer();
            aTimer.Interval = 500;   //Defenido um intervalo de 0.1 segundo a 0.1 segundo
            aTimer.Elapsed += OnTimedEvent;     //Defenido quando 'Elapsed' (segundo a segundo) dar 'Summon' ao 'OnTimedEvent'
            aTimer.Start();
            //  ...

            palavra = " ";
            while (palavra != ".")
            {
                if (end)
                {
                    End();
                }

                if (currentPlayer >= nPlayers)
                {
                    currentPlayer = 1;
                    rounds = rounds + 1;
                }
                else
                {
                    currentPlayer = currentPlayer + 1;
                }


                //  TIMER RESET AND ENABLED
                waySelected = false;
                if (rounds == 1)
                {
                    timer = secs;
                }
                else
                {
                    timer = (secs * Math.Pow(roundTime, (rounds - 1)));     //Value of timer output
                }

                if (timer < 1.5) timer = 1.5;   //O timer nao desce menos de 1.5 segundos
                aTimer.Enabled = true;      //Timer Ativo
                //  ...

                // INSTRUCTIONS/BEFORE WORD
                Console.Write("Palavra anterior: ");
                Console.Write(espaco);
                Console.WriteLine(palavra);
                System.Console.WriteLine("Escreva '.' (ponto) para acabar.");
                //  ...

                //  INPUT
                System.Console.WriteLine("Palavra: ");
                palavra = System.Console.ReadLine();
                ////Defenição de uma só palavra
                palavra = palavra + " ";
                pos = palavra.IndexOf(" ");
                palavra = palavra.Substring(0, pos);
                ////....
                //  ...

                texto = texto + espaco + palavra;
                waySelected = true;


                //  Clear a este output
                Console.SetCursorPosition(0, 0);
                ClearLine();
                Console.SetCursorPosition(0, 1);
                ClearLine();
                Console.SetCursorPosition(0, 2);
                ClearLine();
                Console.SetCursorPosition(0, 3);
                ClearLine();
                Console.SetCursorPosition(0, 0);
            }

            //  OUTPUT
            if (palavra == ".")
            {
                Console.Clear();
                Console.WriteLine(texto);
            }
            //  ...
            GC.KeepAlive(aTimer);

        }

        //Termina o jogo caso seja chamada (batoteiro xD)
        static void End()
        {
            Environment.Exit(0);

        }
    }
}
