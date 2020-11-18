using System;
using System.Collections.Generic;

namespace SA2_Carlos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Receitas> receitas = new List<Receitas>();
            Menu:
            Console.Clear();
            Console.WriteLine("1 - Adicionar produto.");
            Console.WriteLine("2 - Editar produto.");
            Console.WriteLine("3 - Excluir produto.");
            Console.WriteLine("4 - Lista de receitas.");
            Console.WriteLine("5 - Receitas por dificuldade.");
            Console.WriteLine("6 - Receitas por Categoria.");
            Console.WriteLine("7 - Receitas por tempo de preparo.");
            Console.WriteLine("8 - Cotação de ingredientes.");
            Console.WriteLine("9 - Valor estimado da receita.");
            Console.WriteLine("0 - Adicionar produto.");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt16(Console.ReadLine());
            switch(opcao)
            {
                case 1:
                    Receitas R = new Receitas();
                    Console.Write("Insira o nome da receita: ");
                    R.Nome = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Insira o tempo de preparo: ");
                    R.TempoPreparacao = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("1 - Fácil");
                    Console.WriteLine("2 - Média");
                    Console.WriteLine("3 - Difícil");
                    Console.WriteLine("4 - Muito Difícil");
                    Console.Write("Escolha o grau de dificuldade: ");
                    int decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        R.Dificuldade = "Fácil";
                    }
                    if (decisao == 2)
                    {
                        R.Dificuldade = "Média";
                    }
                    if (decisao == 3)
                    {
                        R.Dificuldade = "Difícil";
                    }
                    if (decisao == 4)
                    {
                        R.Dificuldade = "Muito Difícil";
                    }
                    if (decisao > 4 || decisao < 1)
                    {
                        Console.WriteLine("Opção inválida.");
                        goto case 1;
                    }
                    Console.Clear();
                    Console.Write("Insira o número de pessoas que uma porção serve: ");
                    R.Porcao = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("1 - Carne");
                    Console.WriteLine("2 - Peixe");
                    Console.WriteLine("3 - Marisco");
                    Console.WriteLine("4 - Pasteleria");
                    Console.WriteLine("5 - Sobremesa");
                    Console.WriteLine();
                    Console.Write("Escolha a categoria da comida: ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        R.Categoria = "Carne";
                    }
                    if (decisao == 2)
                    {
                        R.Categoria = "Peixe";
                    }
                    if (decisao == 3)
                    {
                        R.Categoria = "Marisco";
                    }
                    if (decisao == 4)
                    {
                        R.Categoria = "Pastelaria";
                    }
                    if (decisao == 5)
                    {
                        R.Categoria = "Sobremesa";
                    }
                    if (decisao < 1 || decisao > 5)
                    {
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        Console.Clear();
                        goto case 1;
                    }
                    Console.Clear();
                    Console.Write("Insira o modo de preparo da receita: ");
                    R.Descricao = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Insira os ingredientes usados na receita (ordem alfabética): ");
                    R.Ingredientes = Console.ReadLine();
                    R.Cod = receitas.Count + 1;
                    receitas.Add(R);
                    goto Menu;
                    
                case 2:
                    
                    break;
                    
                case 3:
                    break;
                    
                case 4:
                    foreach (var item in receitas)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 5:
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.Dificuldade.CompareTo(r2.Dificuldade);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.Nome} | Tempo de preparo: {r.TempoPreparacao} | Dificuldade: {r.Dificuldade} | " +
                            $"Porção: {r.Porcao} pessoas | Categoria: {r.Categoria} | \n Descrição: {r.Descricao} \n Ingretientes: {r.Ingredientes} |");
                    });
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;
                    
                case 6:
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.Categoria.CompareTo(r2.Categoria);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.Nome} | Tempo de preparo: {r.TempoPreparacao} | Dificuldade: {r.Dificuldade} | " +
                            $"Porção: {r.Porcao} pessoas | Categoria: {r.Categoria} | \n Descrição: {r.Descricao} \n Ingretientes: {r.Ingredientes} |");
                    });
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;
                    
                case 7:
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.TempoPreparacao.CompareTo(r2.TempoPreparacao);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.Nome} | Tempo de preparo: {r.TempoPreparacao} | Dificuldade: {r.Dificuldade} | " +
                            $"Porção: {r.Porcao} pessoas | Categoria: {r.Categoria} | \n Descrição: {r.Descricao} \n Ingretientes: {r.Ingredientes} |");
                    });
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 8:
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 9:
                    Console.Write("Deseja retornar ao menu? (1 = sim, 2 = não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 0:
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
