using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CamadaDeDados;
using System.Data;

namespace DrLavaTudo_Teste.Classes.BLL
{
    public class OsBLL
    {
        //Instância da classe DAL
        DAL objDAL = new DAL();

        //método que retornará clientes em forma de DataTable
        public DataTable retOs(int id_Ordem_Servico)
        {
            //testaremos se está pedindo todos Os (id = -1) ou algum específico
            string whereclause = ""; // para isso usaremos uma string de whereclause
            if (id_Ordem_Servico != -1)
            {
                whereclause = "where o.id = '" + id_Ordem_Servico + "'";
            }

            DataTable data = new DataTable();
            string sql = "select " +
                "o.id as Id, o.data_contratacao as Data_contratacao, o.data_execucao as Data_execucao, " +
                "o.id_cliente as Id_cliente, o.id_servicos as Id_servicos, o.id_endereco as Id_endereco, " +
                "c.nome as Nome_cliente, s.nome_servico as Nome_servico, c.email as Email_cliente, " +
                "c.data_de_nascimento as Data_nasc_cliente, c.telefone_celular as Telefone_celular_cliente, " +
                "c.telefone_residencial as Telefone_residencial_cliente, e.endereco_cep as Cep_endereco, " +
                "e.endereco_rua as Rua_endereco, e.endereco_bairro as Bairro_endereco, e.endereco_numero as Numero_endereco, " +
                "e.endereco_complemento as Complemento_endereco, e.endereco_cidade as Cidade_endereco, e.endereco_UF as Uf_endereco " +
                "from ordem_de_servico as o " +
                "inner join cliente as c on c.id = o.id_cliente " +
                "inner join servicos as s on s.id = o.id_servicos " +
                "inner join endereco as e on e.id = o.id_endereco " + whereclause; // aqui está a string sql para listagem de dados

            data = objDAL.RetDataTable(sql); // utilizando o método da DAL para retorno da nossa listagem
            return data; //retornando os dados
        }
    }
}