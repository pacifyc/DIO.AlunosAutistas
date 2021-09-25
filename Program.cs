using System;

namespace DIO.AlunosAutistas
{
    class Program
    {
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        //ListarAlunosAutistas();
                        break;
                    case "2":
                        //InserirAlunosAutistas();
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
            Console.WriteLine(" 5 - Visualizar Alunos);
            Console.WriteLine(" C - Limpar Tela ");
            Console.WriteLine(" X - Sair ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;



        }
    }
}
