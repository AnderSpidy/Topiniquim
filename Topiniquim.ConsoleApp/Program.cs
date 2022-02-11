using System;

namespace Topiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool condicao = true;
            int[] coordenadasGrid = new int[2];
            string[] posiçãoAtual = new string[3];
           //Receber os dados da dimenção da área.
            Console.WriteLine("Projeto Tupiniquim 2.0!");
            Console.WriteLine("Digite a coordenada X da área: ");
            coordenadasGrid[0] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a coordenada Y da área: ");
            coordenadasGrid[1] = Convert.ToInt32(Console.ReadLine());
            //Este if é para evitar que os dados da area entre menores que zero, caso aconteça: será setado como 0.(SEI QUE PODE TER UMA FORMA MAIS INTELIGENTE DO QUE ESSA, MAS NO MOMENTO ESTOU COM SONO)
            if (coordenadasGrid[0] < 0)
            {
                coordenadasGrid[0] = 0;
            }if (coordenadasGrid[1] < 0){
                coordenadasGrid[1] = 1;
            }
            Console.Clear();
            //Receber os dados da quantidade de robos
            Console.WriteLine("Projeto Tupiniquim 2.0!");
            Console.WriteLine("Quantidade de robos lançados:");
            int robo = Convert.ToInt32(Console.ReadLine());
            string[] historicoRobos = new string[robo];
            //Este é o for para repetir as intruções de "lançamento, pouso e movimentação"
            for (int i = 0; i < robo; ++i)
            {
                //Este While é feito para garantir que os dados foram colocados corretamente
                while (condicao == true)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nÁrea Rastreada>> X:" + coordenadasGrid[0] + " Y:" + coordenadasGrid[1]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nRobo numeração nº" + (i + 1));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n=======================================================\n");
                    Console.WriteLine("Digite a coordenada X de pouso do Robo nº" + (i+1) + ":");
                    posiçãoAtual[0] = Console.ReadLine();
                    Console.WriteLine("Digite a coordenada Y de pouso do Robo nº" + (i+1) + ":");
                    posiçãoAtual[1] = Console.ReadLine();
                    //while para filtrar os caracteres certo para a "direção de pouso inicial"
                    while (posiçãoAtual[2] != "N" && posiçãoAtual[2] != "S" && posiçãoAtual[2] != "L" && posiçãoAtual[2] != "O" && 
                           posiçãoAtual[2] != "n" && posiçãoAtual[2] != "s" && posiçãoAtual[2] != "l" && posiçãoAtual[2] != "o")
                    {
                        Console.WriteLine("Digite a direção inicial: N = norte, S = sul, L = leste ou O = oeste");
                        posiçãoAtual[2] = Console.ReadLine();
                        Console.Clear();   
                    }
                    //Este if é para ver se o robo pousou dentro da área. Ou Seja, para saber se os dados colcado pelo usuario, está dentro das dimenções 
                    if (Convert.ToInt32(posiçãoAtual[0]) > coordenadasGrid[0] || Convert.ToInt32(posiçãoAtual[1]) > coordenadasGrid[1])
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nO ROBO CAIU FORA DA ÁREA DE COMINICAÇÃO!!!\nAPERTE ENTER para lançar mais um Robo nº"+(i+1));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        continue;
                    }
                    condicao = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n Este robo está dentro das coordenadas.\n Parabéns, o pouso do Robo foi bem sucedido!\n APERTE ENTER para continuar; ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nÁrea Rastreada>> X:" + coordenadasGrid[0] + " Y:" + coordenadasGrid[1]);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("\nCoordenadas do pouso do Robo nº" + (i + 1) + ">> X:" + posiçãoAtual[0] + " Y:" + posiçãoAtual[1] + " Drireção:" + posiçãoAtual[2]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nDigite os comandos de movimento para o Robo:\n");
                string comando = Console.ReadLine();
                //O método "ToCharArray()" transforma uma string em um Array de char, como se estivesse "fraguimentando" a string em unidade de char
                char[] instruções = comando.ToCharArray();
                //passando os dados de array para variaveis mais "Simples de se trabalhar.(Na verdade acho que nem seria necessario essas arrays rsrs MAS ESTOU CANSADO E COM SONO POR CONTA DA FACUL )
                int intPosiçãoAtualX = Convert.ToInt32(posiçãoAtual[0]);
                int intPosiçãoAtualY = Convert.ToInt32(posiçãoAtual[1]);
                string direção = posiçãoAtual[2];
                //este FOR, é para "decodificar as instruções"
                //este for vai ser rodado até o tamanho do array de char de instruções
                for (int j = 0; j < instruções.Length; j++)
                {
                    //se a instrção for M para todos os lados tera que ir a frente
                    if (instruções[j] == 'M' || instruções[j] == 'm')
                    {
                        if (direção == "N" || direção == "n")
                        {
                            intPosiçãoAtualY = intPosiçãoAtualY + 1;
                        }
                        else if (direção == "L" || direção == "l")
                        {
                            intPosiçãoAtualX = intPosiçãoAtualX + 1;
                        }
                        else if (direção == "S" || direção == "s")
                        {
                            intPosiçãoAtualY = intPosiçãoAtualY - 1;
                        }
                        else if (direção == "O" || direção == "o")
                        {
                            intPosiçãoAtualX = intPosiçãoAtualX - 1;
                        }
                    }
                    //se a intrução for E para todos os lados terá que trocar de direção 90º para a esquerda
                    else if (instruções[j] == 'E' || instruções[j] == 'e')
                    {
                        if (direção == "N" || direção == "n")
                        {
                            direção = "O";
                        }
                        else if (direção == "L" || direção == "l")
                        {
                            direção = "N";
                        }
                        else if (direção == "S" || direção == "s")
                        {
                            direção = "L";
                        }
                        else if (direção == "O" || direção == "o")
                        {
                            direção = "S";
                        }
                    }
                    //se a intrução for D para todos os lados terá que trocar de direção 90º para a direita
                    else if (instruções[j] == 'D' || instruções[j] == 'd')
                    {
                        if (direção == "N" || direção == "n")
                        {
                            direção = "L";
                        }
                        else if (direção == "L" || direção == "l")
                        {
                            direção = "S";
                        }
                        else if (direção == "S" || direção == "s")
                        {
                            direção = "O";
                        }
                        else if (direção == "O" || direção == "o")
                        {
                            direção = "N";
                        }
                    }
                }
                //este if é feito para mostrar para o usuario a localisação final do seu robo
                //nesta entrada seria se o robo sair da area estimada, alem de mostrar na hora, tambem salva esta informação em uma array de historico
                if (coordenadasGrid[0] < intPosiçãoAtualX || coordenadasGrid[1] < intPosiçãoAtualY || intPosiçãoAtualX < 0 || intPosiçãoAtualY < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("O Robo saiu fora do ar, esta FORA DE ALCANCE de comunicação!!!");
                    historicoRobos[i] = ("\nRobo nº" + (i + 1) + " Coordenadas>> DESCONHECIDAS\n");
                }
                else//este else, seria caso o robo se mantivesse na area 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    historicoRobos[i] = ("\nRobo nº" + (i + 1) + " Coordenadas>> X:" + intPosiçãoAtualX + " Y:" + intPosiçãoAtualY + " Direção: " + direção);  
                    Console.WriteLine("Coordenadas>> X:" + intPosiçãoAtualX + " Y:" + intPosiçãoAtualY + " Direção: " + direção);
                }
                Console.ReadLine();
                posiçãoAtual[2] = null;
                condicao = true;
            }
            //aqui é para mostrar o historico dos robos 
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||||||||||||||||\n");
            Console.WriteLine("HISTORICO DA MISSÃO");
            Console.WriteLine("\n|||||||||||||||||||||||||||||||||||||||||||||||||\n");
            for (int i = 0; i < robo; i++)
            {
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
                Console.WriteLine("\nSTATUS DO ROBO Nº" + i + ": ");
                Console.WriteLine(historicoRobos[i]);
                Console.WriteLine("\n==========================================\n");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MISSION COMPLETE!!! ♫ musiquinha do METAL SLUG ♫\n\n");
            Console.Title = "ASCII Art";
            string title = @"
　　　　 　    _
　　　　　 ヽ_!l|〕__
　　　　 ＼= 二二ヽ ＿
　　, ､‐､i´ [-II　▽l].|__]
　　＼＼ヽ　 ＿__／
　　　 ,｀○)ol ：･)oヾヽ ,
　　 ヽ（◎,_[ ｌニｌ ]_（◎,ヽ
　　 　´ ´　　　 　　 ´
";
            Console.WriteLine(title);
            Console.ReadLine();
        }
    }
}
