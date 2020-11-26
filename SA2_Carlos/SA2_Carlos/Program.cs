using SA2_Carlos.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SA2_Carlos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Receitas> receitas = DatabaseReceitas.getReceitas();
            List<Ingredientes> ingredientes = DatabaseIngredientes.getIngredientes();

        Menu:
            Console.Clear();
            Console.WriteLine("1 - Adicionar ingredientes.\n");
            Console.WriteLine("2 - Editar ingrediente.\n");
            Console.WriteLine("3 - Remover ingrediente.\n");
            Console.WriteLine("4 - Adicionar receita.\n");
            Console.WriteLine("5 - Editar receita.\n");
            Console.WriteLine("6 - Excluir receita.\n");
            Console.WriteLine("7 - Lista de receitas.\n");
            Console.WriteLine("8 - Receitas por dificuldade.\n");
            Console.WriteLine("9 - Receitas por Categoria.\n");
            Console.WriteLine("10 - Receitas por tempo de preparo.\n");
            Console.WriteLine("11 - Cotação de ingredientes.\n");
            Console.WriteLine("12 - Valor estimado da receita.\n");
            Console.WriteLine("0 - Sair do programa.\n");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            int opcao = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            switch (opcao)
            {
                case 1:
                    Ingredientes ingrediente = new Ingredientes();
                    Console.Clear();
                    Console.Write("Insira o nome do ingrediente que deseja adicionar: ");
                    ingrediente.nomeIngrediente = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Insira o preço do ingrediente (por unidade de medida): ");
                    ingrediente.precoIngrediente = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                    Console.Write("Informe a unidade de medida do ingrediente: ");
                    ingrediente.unidadeMedida = Console.ReadLine();
                    Console.Clear();
                    if (ingrediente.precoIngrediente < 0)
                    {
                        Console.WriteLine("Valor inválido.");
                        Console.ReadKey();
                        goto case 1;
                    }
                    if (ingredientes.Count < 1)
                    {
                        ingrediente.codIngrediente = 1;
                    } else
                    {
                        ingrediente.codIngrediente = ingredientes.Last().codIngrediente + 1;
                    }
                    ingredientes.Add(ingrediente);
                    DatabaseIngredientes.postIngredientes(ingrediente);
                    Console.Write("Deseja adicionar mais algum ingrediente?(1 = Sim, 2 = Não): ");
                    int decisao = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (decisao == 1)
                    {
                        goto case 1;
                    }
                    goto Menu;

                case 2:
                    decisao = 0;
                    foreach(var item in ingredientes)
                    {
                        Console.WriteLine($"Código do ingrediente: {item.codIngrediente} | Nome: {item.nomeIngrediente} | Preço do ingrediente: {item.precoIngrediente} |");
                        Console.WriteLine();
                    }
                    Console.Write("Insira o código do ingrediente que deseja atualizar: ");
                    int cod = Convert.ToInt16(Console.ReadLine());
                    var alteraIngrediente = ingredientes.Find(item => item.codIngrediente == cod);
                    if (alteraIngrediente == null)
                    {
                        Console.WriteLine("CÓDIGO INVÁLIDO");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    }
                    Console.Clear();
                    while (decisao != 4)
                    {
                    subMenuIngredientes:

                        Console.WriteLine("\t1 - Nome do ingrediente.\n");
                        Console.WriteLine("\t2 - Preço do ingrediente.\n");
                        Console.WriteLine("\t3 - Unidade de medida.\n");
                        Console.WriteLine("\t4 - Voltar ao menu.\n");
                        Console.WriteLine();
                        Console.Write("Insira a opção que deseja: ");
                        decisao = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();
                        if (decisao == 1)
                        {
                            Console.Write("Insira o novo nome do ingrediente: ");
                            alteraIngrediente.nomeIngrediente = Console.ReadLine();
                            Console.Clear();
                            goto subMenuIngredientes;
                        }

                        if (decisao == 2)
                        {
                            Console.Write("Insira o novo preço do ingrediente: ");
                            alteraIngrediente.precoIngrediente = Convert.ToDouble(Console.ReadLine());
                            Console.Clear();
                            goto subMenuIngredientes;
                        }

                        if (decisao == 3)
                        {
                            Console.Write("Insira a unidade de medida do ingrediente: ");
                            alteraIngrediente.unidadeMedida = Console.ReadLine();
                            Console.Clear();
                            goto subMenuIngredientes;
                        }
                    }
                    DatabaseIngredientes.putIngredientes(alteraIngrediente);
                    goto Menu;

                case 3:
                    Console.Clear();
                    opcao = 0;
                    foreach (var item in ingredientes)
                    {
                        Console.WriteLine($"Código do ingrediente: {item.codIngrediente} | Nome: {item.nomeIngrediente} | Preço do ingrediente: {item.precoIngrediente} |");
                        Console.WriteLine();
                    }
                    Console.Write("Insira o código do ingrediente que deseja remover: ");
                    cod = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    var removeIngrediente = ingredientes.Find(item => item.codIngrediente == cod);
                    if (removeIngrediente == null)
                    {
                        Console.WriteLine("CÓDIGO INVÁLIDO");
                        Console.ReadKey();
                        Console.Clear();
                        goto Menu;
                    }
                    ingredientes.Remove(removeIngrediente);
                    DatabaseIngredientes.deleteIngredientes(removeIngrediente);
                    goto Menu;

                case 4:
                    Console.Clear();
                    Receitas R = new Receitas();
                    Console.Write("Insira o nome da receita: ");
                    R.nomeReceita = Console.ReadLine();
                    Console.Clear();
                    Console.Write("Insira o tempo de preparo: ");
                    R.tempoPreparacao = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("1 - Fácil");
                    Console.WriteLine("2 - Média");
                    Console.WriteLine("3 - Difícil");
                    Console.WriteLine("4 - Muito Difícil");
                    Console.Write("Escolha o grau de dificuldade: ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        R.dificuldade = "Fácil";
                        R.codDificuldade = 1;
                    }
                    if (decisao == 2)
                    {
                        R.dificuldade = "Média";
                        R.codDificuldade = 2;
                    }
                    if (decisao == 3)
                    {
                        R.dificuldade = "Difícil";
                        R.codDificuldade = 3;
                    }
                    if (decisao == 4)
                    {
                        R.dificuldade = "Muito Difícil";
                        R.codDificuldade = 4;
                    }
                    if (decisao > 4 || decisao < 1)
                    {
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        goto case 4;
                    }
                    Console.Clear();
                    Console.Write("Insira o número de pessoas que uma porção serve: ");
                    R.porcao = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("1 - Carne");
                    Console.WriteLine("2 - Peixe");
                    Console.WriteLine("3 - Marisco");
                    Console.WriteLine("4 - Pasteleria");
                    Console.WriteLine("5 - Sobremesa");
                    Console.WriteLine("6 - Outro");
                    Console.WriteLine();
                    Console.Write("Escolha a categoria da comida: ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (decisao == 1)
                    {
                        R.categoria = "Carne";
                    }
                    if (decisao == 2)
                    {
                        R.categoria = "Peixe";
                    }
                    if (decisao == 3)
                    {
                        R.categoria = "Marisco";
                    }
                    if (decisao == 4)
                    {
                        R.categoria = "Pastelaria";
                    }
                    if (decisao == 5)
                    {
                        R.categoria = "Sobremesa";
                    }
                    if (decisao == 6)
                    {
                        Console.Write("Insira a categoria da sua receita: ");
                        R.categoria = Console.ReadLine();
                        Console.Clear();
                    }
                    if (decisao < 1 || decisao > 6)
                    {
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        goto case 4;
                    }
                    Console.Clear();
                    Console.Write("Insira o modo de preparo da receita: ");
                    R.descricao = Console.ReadLine();
                    opcao = 0;
                    while (opcao != 2)
                    {
                        Console.Clear();
                        foreach (var item in ingredientes)
                        {
                            Console.WriteLine($"Código: {item.codIngrediente} | Nome: {item.nomeIngrediente}");
                            Console.WriteLine();
                        }
                        Console.Write("Insira o codigo do ingrediente que será usado na receita: ");
                        decisao = Convert.ToInt16(Console.ReadLine());
                        Console.Clear();
                        Ingredientes confereItem = new Ingredientes();
                        confereItem = ingredientes.Find(item => item.codIngrediente == decisao);
                        if (confereItem == null)
                        {
                            Console.WriteLine("Código inválido.");
                        }
                        else
                        {
                            Console.Write("Insira a unidade de medida do ingrediente (KG, g, etc): ");
                            confereItem.unidadeMedida = Console.ReadLine();
                            Console.Clear();
                            Console.Write("Insira a quantidade de ingredientes que será utilizada (1/2 = 0,5, 100 g = 0,1 Kg): ");
                            confereItem.qtdIngrediente = Convert.ToDouble(Console.ReadLine());
                            R.ingredientes = new List<Ingredientes>();
                            R.ingredientes.Add(confereItem);
                        }
                        Console.Clear();
                        Console.Write("Deseja inserir outro ingrediente? (1 = Sim, 2 = Não): ");
                        opcao = int.Parse(Console.ReadLine());
                    }
                    if (receitas.Count < 1)
                    {
                        R.codReceita = 1;
                    } else 
                    {
                        R.codReceita = receitas.Last().codReceita + 1;
                    }
                    receitas.Add(R);
                    DatabaseReceitas.postReceitas(R);
                    goto Menu;


                case 5:
                    Console.Clear();
                    foreach (var item in receitas)
                    {
                        Console.WriteLine($"Código da receita: {item.codReceita} | Nome: {item.nomeReceita} | Tempo de preparo: {item.tempoPreparacao} | Dificuldade: {item.dificuldade} | " +
                            $"\nPorção: {item.porcao} pessoas | Categoria: {item.categoria} |\nDescrição: {item.descricao} \n");
                        Console.WriteLine("Ingredientes: ");
                        Console.WriteLine();
                        foreach (var r in item.ingredientes)
                        {
                            Console.WriteLine($"{r.nomeIngrediente} | Quantidade: {r.qtdIngrediente} |\n");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                    Console.Write("Insira o CODIGO da receita que deseja editar: ");
                    cod = Convert.ToInt16(Console.ReadLine());
                    var alterarReceita = receitas.Find(item => item.codReceita == cod);
                    if (alterarReceita == null)
                    {
                        Console.WriteLine("Código inválido.");
                        Console.ReadKey();
                        Console.Clear();
                        goto case 5;
                    }
                subMenuReceitas:
                    Console.Clear();
                    Console.WriteLine("1 - Alterar nome.\n");
                    Console.WriteLine("2 - Alterar tempo de preparo.\n");
                    Console.WriteLine("3 - Alterar Dificuldade.\n");
                    Console.WriteLine("4 - Alterar o número de pessoas servidas por porção.\n");
                    Console.WriteLine("5 - Alterar categoria.\n");
                    Console.WriteLine("6 - Alterar modo de preparo.\n");
                    Console.WriteLine("7 - Alterar ingredientes (os ingredientes existentes serão excluidos).\n");
                    Console.WriteLine("8 - Voltar ao menu principal.\n");
                    Console.WriteLine();
                    Console.Write("Escolha uma opção: ");
                    decisao = Convert.ToInt16(Console.ReadLine());

                    if (decisao == 1)
                    {
                        Console.Clear();
                        Console.Write("Insira o novo nome da receita: ");
                        alterarReceita.nomeReceita = Console.ReadLine();
                        goto subMenuReceitas;
                    }

                    if (decisao == 2)
                    {
                        Console.Clear();
                        Console.Write("Insira o novo tempo de preparo: ");
                        alterarReceita.tempoPreparacao = Console.ReadLine();
                        goto subMenuReceitas;
                    }

                    if (decisao == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Fácil");
                        Console.WriteLine("2 - Média");
                        Console.WriteLine("3 - Difícil");
                        Console.WriteLine("4 - Muito Difícil");
                        Console.Write("Escolha o grau de dificuldade: ");
                        decisao = Convert.ToInt16(Console.ReadLine());
                        if (decisao == 1)
                        {
                            alterarReceita.dificuldade = "Fácil";
                        }
                        if (decisao == 2)
                        {
                            alterarReceita.dificuldade = "Média";
                        }
                        if (decisao == 3)
                        {
                            alterarReceita.dificuldade = "Difícil";
                        }
                        if (decisao == 4)
                        {
                            alterarReceita.dificuldade = "Muito Difícil";
                        }
                        if (decisao > 4 || decisao < 1)
                        {
                            Console.WriteLine("Opção inválida.");
                            Console.ReadKey();
                            goto subMenuReceitas;
                        }
                        goto subMenuReceitas;
                    }

                    if (decisao == 4)
                    {
                        Console.Clear();
                        Console.Write("Informe o número de pessoas servidas por porção: ");
                        alterarReceita.porcao = Convert.ToInt16(Console.ReadLine());
                        goto subMenuReceitas;
                    }

                    if (decisao == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Carne");
                        Console.WriteLine("2 - Peixe");
                        Console.WriteLine("3 - Marisco");
                        Console.WriteLine("4 - Pasteleria");
                        Console.WriteLine("5 - Sobremesa");
                        Console.WriteLine("6 - Outro");
                        Console.WriteLine();
                        Console.Write("Escolha a categoria da comida: ");
                        decisao = Convert.ToInt16(Console.ReadLine());
                        if (decisao == 1)
                        {
                            alterarReceita.categoria = "Carne";
                        }
                        if (decisao == 2)
                        {
                            alterarReceita.categoria = "Peixe";
                        }
                        if (decisao == 3)
                        {
                            alterarReceita.categoria = "Marisco";
                        }
                        if (decisao == 4)
                        {
                            alterarReceita.categoria = "Pastelaria";
                        }
                        if (decisao == 5)
                        {
                            alterarReceita.categoria = "Sobremesa";
                        }
                        if (decisao == 6)
                        {
                            Console.Write("Insira a categoria da receita: ");
                            alterarReceita.categoria = Console.ReadLine();
                        }
                        if (decisao < 1 || decisao > 6)
                        {
                            Console.WriteLine("Opção inválida.");
                            Console.ReadKey();
                            goto subMenuReceitas;
                        }
                    }

                    if (decisao == 6)
                    {
                        Console.Clear();
                        Console.Write("Escreva o modo de preparo da receita: ");
                        alterarReceita.descricao = Console.ReadLine();
                        goto subMenuReceitas;
                    }

                    if (decisao == 7)
                    {
                        alterarReceita.ingredientes.RemoveAll(item => item.codIngrediente != 0);
                        opcao = 0;
                        while (opcao != 2)
                        {
                            Console.Clear();
                            foreach (var item in ingredientes)
                            {
                                Console.WriteLine($"Código: {item.codIngrediente} | Nome: {item.nomeIngrediente}");
                                Console.WriteLine();
                            }
                            Console.Write("Insira o codigo do ingrediente que será usado na receita: ");
                            decisao = Convert.ToInt16(Console.ReadLine());
                            var confereItem = ingredientes.Find(item => item.codIngrediente == decisao);
                            if (confereItem == null)
                            {
                                Console.WriteLine("Código inválido.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("Insira a quantidade de ingredientes que será utilizada (1/2 = 0,5, 100 g = 0,1 Kg): ");
                                confereItem.qtdIngrediente = Convert.ToDouble(Console.ReadLine());
                                Console.Clear();
                                Console.Write("Insira a unidade de medida do ingrediente: ");
                                confereItem.unidadeMedida = Console.ReadLine();
                                alterarReceita.ingredientes.Add(confereItem);
                            }
                            Console.Clear();
                            Console.WriteLine("Deseja adicionar outro ingrediente? (1 = Sim, 2 = Não): ");
                            opcao = Convert.ToInt16(Console.ReadLine());
                        }
                        goto subMenuReceitas;
                    }
                    if (decisao == 8)
                    {
                        DatabaseReceitas.putReceitas(alterarReceita);
                        goto Menu;
                    }
                    goto Menu;

                case 6:
                    Console.Clear();
                    foreach (var item in receitas)
                    {
                        Console.WriteLine($"Código da receita: {item.codReceita} |\nNome: {item.nomeReceita} | Tempo de preparo: {item.tempoPreparacao} | Dificuldade: {item.dificuldade} | " +
                            $"Porção: {item.porcao} pessoas |\nCategoria: {item.categoria} | \nDescrição: {item.descricao}\n");
                        Console.WriteLine("Ingredientes: ");
                        Console.WriteLine();
                        foreach (var r in item.ingredientes)
                        {
                            Console.WriteLine($"| {r.nomeIngrediente} | Quantidade: {r.qtdIngrediente} {r.unidadeMedida}|\n");
                        }
                            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                    Console.Write("Insira o código da receita que deseja excluir: ");
                    cod = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    var removerReceita = receitas.Find(item => item.codReceita == cod);
                    if (removerReceita == null)
                    {
                        Console.WriteLine("Código inválido.");
                        Console.ReadKey();
                        goto Menu;
                    }
                    receitas.Remove(removerReceita);
                    DatabaseReceitas.deleteReceitas(removerReceita);
                    goto Menu;

                case 7:
                    Console.Clear();
                    foreach (var item in receitas)
                    { 
                        Console.WriteLine($"Código receita: {item.codReceita} \t|\t Nome: {item.nomeReceita}");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
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
                    Console.Clear();
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.codDificuldade.CompareTo(r2.codDificuldade);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.nomeReceita} | Tempo de preparo: {r.tempoPreparacao} | Dificuldade: {r.dificuldade} | " +
                            $"Porção: {r.porcao} pessoas | Categoria: {r.categoria} | \nDescrição: {r.descricao}\n");
                        Console.WriteLine("Ingredientes: ");
                        Console.WriteLine();
                        foreach (var item in r.ingredientes)
                        {
                            Console.WriteLine($"{item.nomeIngrediente} | Quantidade: {item.qtdIngrediente} | \n");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    });
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
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
                    Console.Clear();
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.categoria.CompareTo(r2.categoria);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.nomeReceita} | Tempo de preparo: {r.tempoPreparacao} | Dificuldade: {r.dificuldade} | " +
                            $"Porção: {r.porcao} pessoas | Categoria: {r.categoria} | \nDescrição: {r.descricao}\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    });
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 10:
                    Console.Clear();
                    receitas.Sort(delegate (Receitas r1, Receitas r2)
                    {
                        return r1.tempoPreparacao.CompareTo(r2.tempoPreparacao);
                    });
                    receitas.ForEach(delegate (Receitas r)
                    {
                        Console.WriteLine($"Nome: {r.nomeReceita} | Tempo de preparo: {r.tempoPreparacao} | Dificuldade: {r.dificuldade} | " +
                            $"Porção: {r.porcao} pessoas | Categoria: {r.categoria} | \nDescrição: {r.descricao}\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    });
                    Console.ReadKey();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 11:
                    foreach (var item in receitas)
                    {
                        Console.WriteLine($"Nome da receita: { item.nomeReceita}\n");
                        foreach (var r in item.ingredientes)
                        {
                            r.precoTotal = r.precoIngrediente * r.qtdIngrediente;
                            Console.WriteLine($"Nome ingrediente: {r.nomeIngrediente} | Valor total do ingrediente: R${r.precoTotal}\n");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
                    decisao = Convert.ToInt16(Console.ReadLine());
                    if (decisao == 1)
                    {
                        goto Menu;
                    }
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar nossos serviços.");
                    Console.ReadKey();
                    break;

                case 12:
                    foreach (var item in receitas)
                    {
                        foreach (var r in item.ingredientes)
                        {
                            item.precoReceita += r.precoIngrediente * r.qtdIngrediente;
                        }
                        Console.WriteLine($"Nome receita: {item.nomeReceita} | Preço da Receita: R${item.precoReceita} | Serve: {item.porcao} pessoas. |\n");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Console.Write("Deseja retornar ao menu? (1 = Sim, 2 = Não): ");
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
