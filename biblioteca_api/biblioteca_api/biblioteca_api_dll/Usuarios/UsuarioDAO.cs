using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using biblioteca_api_dll.Compartilhados;
using static biblioteca_api_dll.Compartilhados.Conversions;
using Dapper;


namespace biblioteca_api_dll.Usuarios
{
    public class UsuarioDAO : IDAOFind<Usuario,UsuarioFilter>
    {
        private SqlConnection Conexao;

        private const string TableAlias = "Usuario";
        public UsuarioDAO(SqlConnection conexao) {
            this.Conexao = conexao;
        }

        public List<Usuario> FindAll(UsuarioFilter filter) {

            List<Usuario> listUsuarios = Conexao.Query<Usuario>(GetQuery(filter)).ToList();

            return listUsuarios;
        }

        public string GetQuery(UsuarioFilter filtro) {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"SELECT {GetProperties()}");
            sql.AppendLine($"FROM NrmUsuario {TableAlias}");

            if (!string.IsNullOrEmpty(filtro.usuario)) {
                sql.AppendLine($"{TableAlias}.usuario=");
            }
            return sql.ToString();
        }

        public string GetProperties() {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"{TableAlias}.usuario");
            sql.AppendLine($",{TableAlias}.senha");
            return sql.ToString();
        }


    }
}
