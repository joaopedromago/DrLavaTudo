using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrLavaTudo_Teste.Models
{
    public class OsModel
    {
        //criando as variáveis privadas para armazenar os valores que serão exibidos
        private int id;
        private string data_contratacao;
        private string data_execucao;
        private int id_cliente;
        private int id_servicos;
        private int id_endereco;
        private string nome_cliente;
        private string nome_servico;
        private string email_cliente;
        private string data_nasc_cliente;
        private string telefone_celular_cliente;
        private string telefone_residencial_cliente;
        private string cep_endereco;
        private string rua_endereco;
        private string bairro_endereco;
        private string numero_endereco;
        private string complemento_endereco;
        private string cidade_endereco;
        private string uf_endereco;

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

        public string Data_contratacao
        {
            get
            {
                return data_contratacao;
            }

            set
            {
                data_contratacao = value;
            }
        }

        public string Data_execucao
        {
            get
            {
                return data_execucao;
            }

            set
            {
                data_execucao = value;
            }
        }

        public int Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public int Id_servicos
        {
            get
            {
                return id_servicos;
            }

            set
            {
                id_servicos = value;
            }
        }

        public int Id_endereco
        {
            get
            {
                return id_endereco;
            }

            set
            {
                id_endereco = value;
            }
        }

        public string Nome_cliente
        {
            get
            {
                return nome_cliente;
            }

            set
            {
                nome_cliente = value;
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

        public string Email_cliente
        {
            get
            {
                return email_cliente;
            }

            set
            {
                email_cliente = value;
            }
        }

        public string Data_nasc_cliente
        {
            get
            {
                return data_nasc_cliente;
            }

            set
            {
                data_nasc_cliente = value;
            }
        }

        public string Telefone_celular_cliente
        {
            get
            {
                return telefone_celular_cliente;
            }

            set
            {
                telefone_celular_cliente = value;
            }
        }

        public string Telefone_residencial_cliente
        {
            get
            {
                return telefone_residencial_cliente;
            }

            set
            {
                telefone_residencial_cliente = value;
            }
        }

        public string Cep_endereco
        {
            get
            {
                return cep_endereco;
            }

            set
            {
                cep_endereco = value;
            }
        }

        public string Rua_endereco
        {
            get
            {
                return rua_endereco;
            }

            set
            {
                rua_endereco = value;
            }
        }

        public string Bairro_endereco
        {
            get
            {
                return bairro_endereco;
            }

            set
            {
                bairro_endereco = value;
            }
        }

        public string Numero_endereco
        {
            get
            {
                return numero_endereco;
            }

            set
            {
                numero_endereco = value;
            }
        }

        public string Complemento_endereco
        {
            get
            {
                return complemento_endereco;
            }

            set
            {
                complemento_endereco = value;
            }
        }

        public string Cidade_endereco
        {
            get
            {
                return cidade_endereco;
            }

            set
            {
                cidade_endereco = value;
            }
        }

        public string Uf_endereco
        {
            get
            {
                return uf_endereco;
            }

            set
            {
                uf_endereco = value;
            }
        }
    }
}