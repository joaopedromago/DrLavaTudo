using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrLavaTudo_Teste.Models;
using System.Data;
using DrLavaTudo_Teste.Classes.BLL;

namespace DrLavaTudo_Teste.Services
{
    public class ClienteRepository
    {
        private const string CacheKey = "ClienteStore"; // criando uma const string para armazenar o cachekey
        private static DataTable data; //criamos um DataTable estático para que o seu valor não mude durante a execução do programa
        ClienteBLL objClienteBLL = new ClienteBLL(); // instanciando a classe ClienteBLL

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

        //esse método construct irá ser responsável por listar todos Clientes que estão banco
        public ClienteRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null && Data != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var cliente = new ClienteModel[Data.Rows.Count]; //Aqui criamos uma var para armazenar os dados que estão no ClienteModel

                    for (int i = 0; i < Data.Rows.Count; i++) //Este for é o responsável por alterar os dados da ClienteModel
                    {
                        cliente[i] =
                        new ClienteModel
                        {
                            Id = int.Parse(Data.Rows[i]["Id"].ToString()),
                            Nome = Data.Rows[i]["Nome"].ToString(),
                            Id_os = int.Parse(Data.Rows[i]["Id_os"].ToString()),
                            Id_servico = int.Parse(Data.Rows[i]["Id_servico"].ToString()),
                            Nome_servico = Data.Rows[i]["Nome_servico"].ToString()
                        };
                    }

                    ctx.Cache[CacheKey] = cliente; // atualizamos o cachekey com os dados recebidos
                }
            }
        }

        //este método retornará todos dados que estão na ClienteModel
        public ClienteModel[] GetAllClientes()
        {
            var ctx = HttpContext.Current;

            if (ctx != null) //Para evitar erros testaremos se o cachekey não está vazio
            {
                return (ClienteModel[])ctx.Cache[CacheKey]; // assim retornraremos os dados do ClienteModel
            }
            //senão retornraremos dados vazios
            return new ClienteModel[]
            {
              new ClienteModel
                 {
                    Id = 0,
                    Nome = "placeholder",
                    Id_os = 0,
                    Id_servico = 0,
                    Nome_servico = "placeholder"
                }
            };
        }

        //este método retornará todos dados que estão na ClienteModel, porém apenas com o id específico
        public ClienteModel[] GetSelectedCliente(int id)
        {
            Data = objClienteBLL.retCliente(id); //atualizaremos o data, agora com o id específico
            if (data.Rows.Count == 0) // testaremos se existe algum cliente com este id
            {
                return new ClienteModel[] { }; // se sim retornaremos vazio
            }

             //se não, retornaremos o cliente encontrado
            return new ClienteModel[]
            {
                new ClienteModel
                    {
                    Id = int.Parse(Data.Rows[0]["Id"].ToString()),
                    Nome = Data.Rows[0]["Nome"].ToString(),
                    Id_os = int.Parse(Data.Rows[0]["Id_os"].ToString()),
                    Id_servico = int.Parse(Data.Rows[0]["Id_servico"].ToString()),
                    Nome_servico = Data.Rows[0]["Nome_servico"].ToString()
                }
            };
            
        }

    }
}