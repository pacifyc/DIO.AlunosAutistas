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
                        //throw new ArgumentOutOfRangeException();
                        Console.Clear();
                        Console.WriteLine("Opção invalida");
                        Console.WriteLine();
                        Console.Write("Pressione a tecla < ENTER >  para continua... ");
                        Console.ReadLine();
                        break;
                        

                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }


        private static void VisualizarAlunos()
		{
                        Console.Clear();
            if(MatriculaVazia() != false){

                Mensagem();
                return;

            }
            else
            {                    
                try{
                    
                    Console.Write("Informe o número da Matricula: ");
                    int indiceMatricula = int.Parse(Console.ReadLine());

                    var aluno = repositorio.RetornaPorMatricula(indiceMatricula);

                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(aluno);
                    Console.WriteLine("");
                    Console.WriteLine("Pressioone a tecla < ENTER > para continuar... ");

                    Console.ReadLine();


                }catch (Exception)
                {                
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Matricula Inexistente !");
                    Console.WriteLine("");
                    Console.WriteLine("Pressioone a tecla < ENTER > para continuar... ");

                    Console.ReadLine();

                }

            }


		}

        private static bool MatriculaVazia(){

            bool confirma = false;
            var lista = repositorio.Lista();
            if ( lista.Count == 0 )
            {
                confirma = true;

            }

            return confirma;

        }

        private static void Mensagem()
        {
            Console.WriteLine("Nenhuma aluno cadastrada. ");
            Console.WriteLine("");
            Console.WriteLine("Pressione a tecla < ENTER > para continuar ...");

            Console.ReadLine();
            
        }


        private static void ExcluirAluno()
		{
            Console.Clear();
            if(MatriculaVazia() != false){

                Mensagem();
                return;

            }
            else
            {
                try
                {
                    Console.Write("Digite o Matricula do Aluno: ");
                    int indiceMatricula = int.Parse(Console.ReadLine());
                    //Mensagem();

                    Console.Clear();
                    Console.Write("Deseja realmente excluir ? [ s / n ] ");
                    string opcao = Console.ReadLine().ToUpper();

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
                catch (Exception)                
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Matricula Inexistente !");
                    Console.WriteLine("");
                    Console.WriteLine("Pressioone a tecla < ENTER > para continuar... ");

                    Console.ReadLine();
                }

            }

		}


        private static void AtualizarAluno()
		{
            Console.Clear();
            Console.Clear();
            if(MatriculaVazia() != false){

                Mensagem();
                return;

            }
            else
            {
                try
                {                    

                    Console.Write("Digite a Matricula do Aluno: ");
                    int indiceMatricula = int.Parse(Console.ReadLine());

                    foreach (int i in Enum.GetValues(typeof(Nivel)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
                    }
                    Console.Write("Digite o nivel de autismo entre as opções acima: ");
                    int entradaNivel = int.Parse(Console.ReadLine());

                    Console.Write("Informe o Nome do Aluno: ");
                    string entradaNome = Console.ReadLine();

                    Console.Write("Informe o comportamento em destaque no aluno: ");
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
                catch (Exception)                
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("Matricula Inexistente !");
                    Console.WriteLine("");
                    Console.WriteLine("Pressioone a tecla < ENTER > para continuar... ");

                    Console.ReadLine();
                }

            }













            ///----


		}

                
        private static void ListarAlunos()
        {
            Console.Clear();

            Console.WriteLine("     [   Listar Alunos   ]     ");

            var lista = repositorio.Lista();
            
            if ( lista.Count == 0 )
            {

                Console.WriteLine("Nenhuma aluno cadastrada. ");
                Console.WriteLine("");
                Console.WriteLine("Pressioone a tecla < ENTER > para continuar ...");

                Console.ReadLine();
                return;

            }

            foreach ( var aluno in lista)
            {

                if(aluno.retornaExcuido().Equals(false)){

                    Console.WriteLine("");
                    Console.WriteLine("-> Matricula {0}: - {1} ", aluno.retornaMatricula(),                 aluno.retornaNome());
                }

                //Console.WriteLine("-> Matricula {0}: - {1}  - {3} ", aluno.retornaMatricula(), aluno.////retornaNome(), aluno.retornaExcuido());

                //Console.WriteLine(" --> {0}", aluno.ToString());

            }

                Console.WriteLine("");
                Console.WriteLine("Pressioone a tecla < ENTER > para continuar... ");
                Console.ReadLine();

        }

        
        private static void InserirAluno()
		{
            Console.Clear();

			Console.WriteLine("     [   Inserir novo Aluno   ]      ");
            Console.WriteLine();
            Console.WriteLine("Nível de Autismo");

			foreach (int i in Enum.GetValues(typeof(Nivel)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Nivel), i));
			}
            Console.WriteLine();
			Console.Write("Informe um valor referente ao nivel de autismo entre as opções acima: ");
			int entradaNivel = int.Parse(Console.ReadLine());

			Console.Write("Informe o Nome do Aluno: ");
			string entradaNome = Console.ReadLine();

            Console.Write("Informe o comportamento em destaque no aluno: ");
			string entradaComportamento = Console.ReadLine();

			Console.Write("Informe a idade do Aluno: ");
			int entradaIdade = int.Parse(Console.ReadLine());

			Console.Write("Informe o sexo do Aluno: ");
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
