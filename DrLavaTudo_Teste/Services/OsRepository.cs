using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrLavaTudo_Teste.Models;
using System.Data;
using DrLavaTudo_Teste.Classes.BLL;

namespace DrLavaTudo_Teste.Services
{
    public class OsRepository
    {
        private const string CacheKey = "OsStore"; // criando uma const string para armazenar o cachekey
        private static DataTable data; //criamos um DataTable estático para que o seu valor não mude durante a execução do programa
        OsBLL objOsBll = new OsBLL(); // instanciando a classe OsBLL

        //a Data foi encapsulada para que o controller tenha acesso a ela
        public DataTable Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        //esse método construct irá ser responsável por listar todos Os que estão banco
        public OsRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null && Data != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var os = new OsModel[Data.Rows.Count];//Aqui criamos uma var para armazenar os dados que estão no OsModel

                    for (int i = 0; i < Data.Rows.Count; i++) //Este for é o responsável por alterar os dados da OsModel
                    {
                        os[i] =
                            new OsModel
                            {
                                Id = int.Parse(Data.Rows[i]["Id"].ToString()),
                                Data_contratacao = Data.Rows[i]["Data_contratacao"].ToString(),
                                Data_execucao = Data.Rows[i]["Data_contratacao"].ToString(),
                                Id_cliente = int.Parse(Data.Rows[i]["Id_cliente"].ToString()),
                                Id_servicos = int.Parse(Data.Rows[i]["Id_servicos"].ToString()),
                                Id_endereco = int.Parse(Data.Rows[i]["Id_endereco"].ToString()),
                                Nome_cliente = Data.Rows[i]["Nome_cliente"].ToString(),
                                Nome_servico = Data.Rows[i]["Nome_servico"].ToString(),
                                Email_cliente = Data.Rows[i]["Email_cliente"].ToString(),
                                Data_nasc_cliente = Data.Rows[i]["Data_nasc_cliente"].ToString(),
                                Telefone_celular_cliente = Data.Rows[i]["Telefone_celular_cliente"].ToString(),
                                Telefone_residencial_cliente = Data.Rows[i]["Telefone_residencial_cliente"].ToString(),
                                Cep_endereco = Data.Rows[i]["Cep_endereco"].ToString(),
                                Rua_endereco = Data.Rows[i]["Rua_endereco"].ToString(),
                                Bairro_endereco = Data.Rows[i]["Bairro_endereco"].ToString(),
                                Numero_endereco = Data.Rows[i]["Numero_endereco"].ToString(),
                                Complemento_endereco = Data.Rows[i]["Complemento_endereco"].ToString(),
                                Cidade_endereco = Data.Rows[i]["Cidade_endereco"].ToString(),
                                Uf_endereco = Data.Rows[i]["Uf_endereco"].ToString()
                            };
                        
                    }
                    ctx.Cache[CacheKey] = os; // atualizamos o cachekey com os dados recebidos
                }
            }
        }


        //este método retornará todos dados que estão na OsModel
        public OsModel[] GetAllOs()
        {
            var ctx = HttpContext.Current;

            if (ctx != null) //Para evitar erros testaremos se o cachekey não está vazio
            {
                return (OsModel[])ctx.Cache[CacheKey]; // assim retornraremos os dados do OsModel
            }
            //senão retornraremos dados vazios
            return new OsModel[]
            {
                new OsModel
                {
                    Id = 0,
                    Data_contratacao = "Placeholder",
                    Data_execucao = "Placeholder",
                    Id_cliente = 0,
                    Id_servicos = 0,
                    Id_endereco = 0,
                    Nome_cliente = "Placeholder",
                    Nome_servico = "Placeholder",
                    Email_cliente = "Placeholder",
                    Data_nasc_cliente = "Placeholder",
                    Telefone_celular_cliente = "Placeholder",
                    Telefone_residencial_cliente = "Placeholder",
                    Cep_endereco = "Placeholder",
                    Rua_endereco = "Placeholder",
                    Bairro_endereco = "Placeholder",
                    Numero_endereco = "Placeholder",
                    Complemento_endereco = "Placeholder",
                    Cidade_endereco = "Placeholder",
                    Uf_endereco = "Placeholder"
                }
            };
        }

        //este método retornará todos dados que estão na OsModel, porém apenas com o id específico
        public OsModel[] GetSelectedOs(int id) 
        {
            Data = objOsBll.retOs(id); //atualizaremos o data, agora com o id específico
            if (data.Rows.Count == 0) // testaremos se existe algum Os com este id
            {
                return new OsModel[] { }; // se sim retornaremos vazio
            }

            //se não, retornaremos o Os encontrado
            return new OsModel[]
            {
                new OsModel
                    {
                    Id = int.Parse(Data.Rows[0]["Id"].ToString()),
                    Data_contratacao = Data.Rows[0]["Data_contratacao"].ToString(),
                    Data_execucao = Data.Rows[0]["Data_contratacao"].ToString(),
                    Id_cliente = int.Parse(Data.Rows[0]["Id_cliente"].ToString()),
                    Id_servicos = int.Parse(Data.Rows[0]["Id_servicos"].ToString()),
                    Id_endereco = int.Parse(Data.Rows[0]["Id_endereco"].ToString()),
                    Nome_cliente = Data.Rows[0]["Nome_cliente"].ToString(),
                    Nome_servico = Data.Rows[0]["Nome_servico"].ToString(),
                    Email_cliente = Data.Rows[0]["Email_cliente"].ToString(),
                    Data_nasc_cliente = Data.Rows[0]["Data_nasc_cliente"].ToString(),
                    Telefone_celular_cliente = Data.Rows[0]["Telefone_celular_cliente"].ToString(),
                    Telefone_residencial_cliente = Data.Rows[0]["Telefone_residencial_cliente"].ToString(),
                    Cep_endereco = Data.Rows[0]["Cep_endereco"].ToString(),
                    Rua_endereco = Data.Rows[0]["Rua_endereco"].ToString(),
                    Bairro_endereco = Data.Rows[0]["Bairro_endereco"].ToString(),
                    Numero_endereco = Data.Rows[0]["Numero_endereco"].ToString(),
                    Complemento_endereco = Data.Rows[0]["Complemento_endereco"].ToString(),
                    Cidade_endereco = Data.Rows[0]["Cidade_endereco"].ToString(),
                    Uf_endereco = Data.Rows[0]["Uf_endereco"].ToString()
                }
            };
            
        }
        
    }
}