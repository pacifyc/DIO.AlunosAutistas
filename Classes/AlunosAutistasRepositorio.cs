using System;
using System.Collections.Generic;
using DIO.AlunosAutistas.interfaces;

namespace DIO.AlunosAutistas
{
    public class AlunosAutistasRepositorio : IRepositorio<AlunosAutistas>
    {
        private List<AlunosAutistas> listaAlunosAutistas = new List<AlunosAutistas>();

        public void Atualiza(int matricula, AlunosAutistas crianca)
        {
            listaAlunosAutistas[matricula] = crianca;
            //throw new NotImplementedException();
        }

        public void Excluir(int matricula)
        {
            listaAlunosAutistas[matricula].Excluir();
            //throw new NotImplementedException();
        }

        public void Insere(AlunosAutistas crianca)
        {
            listaAlunosAutistas.Add(crianca);
            //throw new NotImplementedException();
        }

        public List<AlunosAutistas> Lista()
        {
            return listaAlunosAutistas;
            //throw new NotImplementedException();
        }

        public int ProximoId()
        {
            return listaAlunosAutistas.Count;
            //throw new NotImplementedException();
        }

        public AlunosAutistas RetornaPorMatricula(int matricula)
        {
            return listaAlunosAutistas[matricula];
            //throw new NotImplementedException();
        }
    }
}