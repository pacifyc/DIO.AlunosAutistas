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
                        //AtualizarAlunosAutistas();
                        break;
                    case "4":
                        //ExcluirAlunosAutistas();
                        break;
                    case "5":
                        //VisualizarAlunosAutistas();
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

                
        private static void ListarAlunos()
        {

            Console.WriteLine("Listar Alunos");

            var lista = repositorio.Lista();
            
            if ( lista.Count == 0 )
            {

                Console.WriteLine("Nenhuma aluno cadastrada. ");
                return;

            }

            foreach ( var aluno in lista)
            {

                //Console.WriteLine("* Matricula {0}: - {1} - {2} - {3}", aluno.retornaMatricula()///, aluno.retornaNome(), aluno.retornaComportamento(), aluno.ToString());

                Console.WriteLine(" --> {0}", aluno.ToString());

            }

        }

        
        private static void InserirAluno()
		{
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

            Console.WriteLine();
            Console.WriteLine(" Cadastro de Alunos Autistas" );
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
