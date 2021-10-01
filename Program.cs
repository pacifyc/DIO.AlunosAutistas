using System;

namespace DIO.AlunosAutistas
{
    class Program
    {
        static AlunosAutistasRepositorio repositorio = new AlunosAutistasRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarAlunos();
                        break;
                    case "2":
                        InserirAluno();
                        break;
                    case "3":
                        AtualizarAluno();
                        break;
                    case "4":
                        ExcluirAluno();
                        break;
                    case "5":
                        VisualizarAlunos();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }


        private static void VisualizarAlunos()
		{
			Console.Write("Digite a Matricula do Aluno da série: ");
			int indiceMatricula = int.Parse(Console.ReadLine());

			var aluno = repositorio.RetornaPorMatricula(indiceMatricula);

			Console.WriteLine(aluno);
            Console.WriteLine("");
            Console.WriteLine("Pressioone qualquer tecla ... !");

            Console.ReadLine();
		}

        private static void ExcluirAluno()
		{
			Console.Write("Digite o Matricula do Aluno: ");
			int indiceMatricula = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("Deseja realmente excluir ? [s/n] ");
            char opcao = char.Parse(Console.ReadLine().ToUpper());

            if(opcao.Equals("S")){

                repositorio.Excluir(indiceMatricula);
                Console.Clear();
                Console.Write("A exclusão foi efetuada com SUCESSO !");
                Console.ReadLine();
                Console.Clear();

            }else{

                Console.Clear();
                Console.WriteLine("A exclusão foi CANCELADA !");
                Console.ReadLine();
                Console.Clear();

            }

		}


        private static void AtualizarAluno()
		{
            Console.Clear();

			Console.Write("Digite a Matricula do Aluno: ");
			int indiceMatricula = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Nivel)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
			}
			Console.Write("Digite o nivel de autismo entre as opções acima: ");
			int entradaNivel = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Aluno: ");
			string entradaNome = Console.ReadLine();

            Console.Write("Digite o comportamento do Nivel de Autismo: ");
			string entradaComportamento = Console.ReadLine();

			Console.Write("Digite a idade do Aluno: ");
			int entradaIdade = int.Parse(Console.ReadLine());

			Console.Write("Digite o sexo do Aluno ");
			char entradaSexo = char.Parse(Console.ReadLine());

			AlunosAutistas atualizaAluno = new AlunosAutistas(matricula: indiceMatricula,
										nivel: (Nivel)entradaNivel,
										nome: entradaNome,
                                        comportamento: entradaComportamento,
										idade: entradaIdade,
										sexo: entradaSexo);

			repositorio.Atualiza(indiceMatricula, atualizaAluno);
		}

                
        private static void ListarAlunos()
        {
            Console.Clear();

            Console.WriteLine("Listar Alunos");

            var lista = repositorio.Lista();
            
            if ( lista.Count == 0 )
            {

                Console.WriteLine("Nenhuma aluno cadastrada. ");
                Console.WriteLine("");
                Console.WriteLine("Pressioone qualquer tecla ... !");

                Console.ReadLine();
                return;

            }

            foreach ( var aluno in lista)
            {

                Console.WriteLine("-> Matricula {0}: - {1} ", aluno.retornaMatricula(), aluno.retornaNome());

                //Console.WriteLine(" --> {0}", aluno.ToString());



            }

                Console.WriteLine("");
                Console.WriteLine("Pressioone qualquer tecla ... !");

                Console.ReadLine();

        }

        
        private static void InserirAluno()
		{
            Console.Clear();

			Console.WriteLine("Inserir nova Aluno");


			foreach (int i in Enum.GetValues(typeof(Nivel)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
			}
			Console.Write("Digite o nivel de autismo entre as opções acima: ");
			int entradaNivel = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Aluno: ");
			string entradaNome = Console.ReadLine();

            Console.Write("Digite o comportamento do Nivel de Autismo: ");
			string entradaComportamento = Console.ReadLine();

			Console.Write("Digite a idade do Aluno: ");
			int entradaIdade = int.Parse(Console.ReadLine());

			Console.Write("Digite o sexo do Aluno ");
			char entradaSexo = char.Parse(Console.ReadLine());

			AlunosAutistas novoAluno = new AlunosAutistas(matricula: repositorio.ProximoId(),
										nivel: (Nivel)entradaNivel,
										nome: entradaNome,
                                        comportamento: entradaComportamento,
										idade: entradaIdade,
										sexo: entradaSexo);

			repositorio.Insere(novoAluno);
		}


        private static string ObterOpcaoUsuario()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("           [  Cadastro de Alunos Autistas  ]  " );
            Console.WriteLine();
            Console.WriteLine(" Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine(" 1 - Listar Alunos ");
            Console.WriteLine(" 2 - Inserir novo Aluno ");
            Console.WriteLine(" 3 - Atualizar Cadastro ");
            Console.WriteLine(" 4 - Excluir Aluno ");
            Console.WriteLine(" 5 - Visualizar Alunos ");
            Console.WriteLine(" C - Limpar Tela ");
            Console.WriteLine(" X - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;



        }
    }
}
