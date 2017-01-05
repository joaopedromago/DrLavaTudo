using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrLavaTudo_Teste.Models;
using DrLavaTudo_Teste.Services;
using DrLavaTudo_Teste.Classes.BLL;

namespace DrLavaTudo_Teste.Controllers
{
    public class ClienteController : ApiController
    {
        private ClienteRepository clienteRepository; //criando um objeto ClienteRepository

        ClienteBLL objOsBLL = new ClienteBLL(); //instanciando a classe ClienteBLL
        ClienteRepository objClienteRepository = new ClienteRepository(); // instanciando o objeto ClienteRepository

        //este método construct ultilizará o ClienteRepository para listar os Clientes
        public ClienteController()
        {
            objClienteRepository.Data = objOsBLL.retCliente(-1); // Atualizando a Data do Repository para que liste todos
            this.clienteRepository = new ClienteRepository(); // Reinstanciando o objeto ClienteRepository, para que seu construct execute a listagem atualizada
        }

        //Listando todos dados na tela
        public ClienteModel[] Get()
        {
            return clienteRepository.GetAllClientes();
        }

        //Listando dados específicos na tela
        public ClienteModel[] Get(int id)
        {
            return clienteRepository.GetSelectedCliente(id); // utilizando o método de listagem específica com o parametro ID da url
        }
    }
}
