using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrLavaTudo_Teste.Models
{
    public class ClienteModel
    {
        //criando as variáveis privadas para armazenar os valores que serão exibidos
        private int id;
        private string nome;
        private int id_os;
        private int id_servico;
        private string nome_servico;

        //elas foram encapsuladas para que outras classes a acessem
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Id_os
        {
            get
            {
                return id_os;
            }

            set
            {
                id_os = value;
            }
        }

        public int Id_servico
        {
            get
            {
                return id_servico;
            }

            set
            {
                id_servico = value;
            }
        }

        public string Nome_servico
        {
            get
            {
                return nome_servico;
            }

            set
            {
                nome_servico = value;
            }
        }
    }
}