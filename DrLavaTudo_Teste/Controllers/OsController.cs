using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrLavaTudo_Teste.Models;
using DrLavaTudo_Teste.Services;
using DrLavaTudo_Teste.Classes.BLL;
using System.Web.Mvc;

namespace DrLavaTudo_Teste.Controllers
{
    public class OsController : ApiController
    {
        private OsRepository osRepository; //criando um objeto OsRepository

        OsBLL objOsBLL = new OsBLL(); //instanciando a classe OsBLL
        OsRepository objOsRepository = new OsRepository(); // instanciando o objeto OsRepository

        //este método construct ultilizará o OsRepository para listar os Os
        public OsController()
        {
            objOsRepository.Data = objOsBLL.retOs(-1); // Atualizando a Data do Repository para que liste todos
            this.osRepository = new OsRepository(); // Reinstanciando o objeto OsRepository, para que seu construct execute a listagem atualizada
        }


        //Listando todos dados na tela
        public OsModel[] Get()
        {
            return osRepository.GetAllOs();
        }

        //Listando dados específicos na tela
        public OsModel[] Get(int id)
        {
            return osRepository.GetSelectedOs(id); // utilizando o método de listagem específica com o parametro ID da url
        }
    }
}
