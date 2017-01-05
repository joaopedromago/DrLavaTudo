using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace CamadaDeDados
{
    public class DAL
    {
        private static string servidor = "localhost";
        private static string banco = "drlavatudo";
        private static string user = "root";
        private static string password = "";

        private string string_conexao = "Server=" + servidor + ";Database=" + banco + ";Uid=" + user + ";Pwd=" + password;
        public MySqlConnection conexao;

        private void Conectar()
        {
            conexao = new MySqlConnection();
            conexao.ConnectionString = string_conexao;
            conexao.Open();
        }

        private void Desconectar()
        {
            conexao.Close();
        }
        //INSERT, UPDATE E DELETE
        public void ExecutarComandoSQL(string sql)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexao;
            comando.CommandText = sql;
            comando.ExecuteNonQuery();
            Desconectar();
        }


        //APENAS SELECT
        public DataTable RetDataTable(string comando_select)
        {
            Conectar();
            DataTable dados = new DataTable(); //Retorno para o meu GRID ou COMBOBOX
            MySqlDataAdapter da = new MySqlDataAdapter(); //Adaptador de dados do Mysql para o C#
            MySqlCommand comando = new MySqlCommand(); //Comando a ser utilizado pelo adaptador

            comando.Connection = conexao;
            comando.CommandText = comando_select;
            da.SelectCommand = comando;

            da.Fill(dados); //Preenche o objeto dados com os dados recuperados no bd
            Desconectar();
            return dados;
        }
    }
}