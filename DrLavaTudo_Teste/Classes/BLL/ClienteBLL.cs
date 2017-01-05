using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamadaDeDados;
using System.Data;

namespace DrLavaTudo_Teste.Classes.BLL
{
    public class ClienteBLL
    {
        //Instância da classe DAL
        DAL objDAL = new DAL();

        //método que retornará clientes em forma de DataTable
        public DataTable retCliente(int id_Cliente)
        {
            //testaremos se está pedindo todos clientes (id = -1) ou algum específico
            string whereclause = ""; // para isso usaremos uma string de whereclause
            if (id_Cliente != -1)
            {
                whereclause = "where c.id = '" + id_Cliente + "'";
            }

            DataTable data = new DataTable();
            string sql = "select " +
                "c.id as Id, c.nome as Nome, o.id as Id_os, s.id as Id_Servico, s.nome_servico as Nome_servico " +
                "from cliente as c "+
                "inner join ordem_de_servico as o on o.id_cliente = c.id " +
                "inner join servicos as s on s.id = o.id_servicos " + whereclause; // aqui está a string sql para listagem de dados

            data = objDAL.RetDataTable(sql); // utilizando o método da DAL para retorno da nossa listagem
            return data; //retornando os dados
        }
    }
}