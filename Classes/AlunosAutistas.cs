

using System;

namespace DIO.AlunosAutistas
{
    public class AlunosAutistas : CriancaBase
    {
        private Nivel Nivel { get; set; }
        private string Nome { get; set; }
        private string Conportamento { get; set; }        
        private int Idade { get; set; }
        private char Sexo { get; set; }

        private bool Excluido { get; set; }

        
        public AlunosAutistas(int matricula, Nivel nivel, string nome, string comportamento, int idade, char sexo)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Nivel = nivel;
            this.Conportamento = comportamento;
            this.Idade = idade;
            this.Sexo = sexo;

            this.Excluido = true;



        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Matricula: " +  this.Matricula + Environment.NewLine;
            retorno += "Nome: " +  this.Nome + Environment.NewLine;
            retorno += "Nivel: " +  this.Nivel + Environment.NewLine;
            retorno += "Idade: " +  this.Idade + Environment.NewLine;
            retorno += "Sexo: " +  this.Sexo + Environment.NewLine;

            return retorno;
        }
        public int retornaMatricula()
        {
            return this.Matricula;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        public void Excluir()
        {
            this.Excluido = true;            
        }



    }







}