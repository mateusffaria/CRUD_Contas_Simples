using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using WindowsFormsApp1.util;
using WindowsFormsApp1.modelo;
using System.Windows.Forms;

namespace WindowsFormsApp1.modelo
{
    class Fluxo
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string entradaSaida { get; set; }
        public double valor { get; set; }
        //public double caixa { get; set; }

        public void cadastrar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                String sql = "INSERT INTO lancamento (descricao, entradaSaida, valor) VALUES" +
                    "(@descricao, @entradaSaida, @valor)";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add("@descricao", this.descricao);
                cmd.Parameters.Add("@entradaSaida", this.entradaSaida);
                cmd.Parameters.Add("@valor", this.valor);
                //cmd.Parameters.Add("@caixa", this.caixa);
                cmd.ExecuteNonQuery();

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if(conexao != null)
                {
                    conexao.Close();
                }
            }
        }
        public List<Fluxo> listar()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                string sql = "SELECT * FROM lancamento";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                //Executa a consulta e acumula o resultado em uma tab virutal
                NpgsqlDataReader dr = cmd.ExecuteReader();

                //percorre todas as linhas e monta uma lista
                List<Fluxo> listaFluxo = new List<Fluxo>();
                while (dr.Read())
                {
                    Fluxo novoItem = new Fluxo();
                    novoItem.descricao = dr["descricao"].ToString();
                    novoItem.valor = Convert.ToDouble(dr["valor"]);
                    novoItem.entradaSaida = dr["entradasaida"].ToString();
                    novoItem.id = Convert.ToInt16(dr["id"]);
                    //adicionar o objeto na lista
                    listaFluxo.Add(novoItem);
                }
                return listaFluxo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
        public void Update()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                String sql = "UPDATE public.lancamento SET descricao =@descricao, entradasaida =@entradaSaida, valor =@valor " +
                    "WHERE id = @id;";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.Parameters.Add("@descricao", this.descricao);
                cmd.Parameters.Add("@entradaSaida", this.entradaSaida);
                cmd.Parameters.Add("@valor", this.valor);
                //cmd.Parameters.Add("@caixa", this.caixa);
                cmd.Parameters.Add("@id", this.id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }

        public void delete()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = ConectaDB.getConexao();
                String sql = "DELETE FROM public.lancamento WHERE id = @id;";
                
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", this.id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}
