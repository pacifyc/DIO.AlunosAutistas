using System.Collections.Generic;

namespace DIO.AlunosAutistas.interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorMatricula(int matricula);

        void Insere(T crianca);

        void Excluir(int matricula);

        void Atualiza(int id, T entidade);

        int ProximoId();
         
    }
}