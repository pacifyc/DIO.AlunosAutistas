using System;
using System.Collections.Generic;
using DIO.AlunosAutistas.interfaces;

namespace DIO.AlunosAutistas
{
    public class AlunosAutistasRepositorio : IRepositorio<AlunosAutistas>
    {
        private List<AlunosAutistas> listaAlunosAutistas = new List<AlunosAutistas>();
        
        public void Atualiza(int id, AlunosAutistas entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int matricula)
        {
            throw new NotImplementedException();
        }

        public void Insere(AlunosAutistas crianca)
        {
            throw new NotImplementedException();
        }

        public List<AlunosAutistas> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();
        }

        public AlunosAutistas RetornaPorMatricula(int matricula)
        {
            throw new NotImplementedException();
        }
    }
}