using MinhaWebApi.Models;
using MinhaWebApi.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Services
{
    public class ClienteService
    {

        public void RegistrarCliente(ClienteModel infos)
        {
            try
            {
                var dataNascimento = Convert.ToDateTime(infos.data_nascimento);

                string qry = "INSERT INTO cliente (nome, data_cadastro,cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                    "VALUES(" +
                    $" '{infos.nome}'" +
                    $",'{DateTime.Now.ToString("yyyy/MM/dd")}'" +
                    $",'{infos.cpf_cnpj}'" +
                    $",'{dataNascimento.ToString("yyyy/MM/dd")}'" +
                    $",'{infos.tipo}'" +
                    $",'{infos.telefone}'" +
                    $",'{infos.email}'" +
                    $",'{infos.cep}'" +
                    $",'{infos.logradouro}'" +
                    $",'{infos.numero}'" +
                    $",'{infos.bairro}'" +
                    $",'{infos.complemento}'" +
                    $",'{infos.cidade}'" +
                    $",'{infos.uf}'" +
                    $")";

                var dal = new DAL();
                dal.ExecutarComandoSql(qry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClienteModel> RetornarTodosClientesCadastrados()
        {
            try
            {
                string qry = "SELECT * FROM CLIENTE";
                var dal = new DAL();
                var tabela = dal.RetornarDataTable(qry);
                
                var listaClientes = new List<ClienteModel>();

                foreach (DataRow cli in tabela.Rows)
                {
                    var cliente = new ClienteModel() { 
                        id = Convert.ToInt32(cli["id"]),
                        nome = cli["nome"].ToString(),
                        data_cadastro = Convert.ToDateTime(cli["data_cadastro"].ToString()),
                        cpf_cnpj = cli["cpf_cnpj"].ToString(),
                        data_nascimento = cli["data_nascimento"].ToString(),
                        tipo = cli["tipo"].ToString(),
                        telefone = cli["telefone"].ToString(),
                        email = cli["email"].ToString(),
                        cep = cli["cep"].ToString(),
                        logradouro = cli["logradouro"].ToString(),
                        numero = cli["numero"].ToString(),
                        bairro = cli["bairro"].ToString(),
                        complemento = cli["complemento"].ToString(),
                        cidade = cli["cidade"].ToString(),
                        uf = cli["uf"].ToString()
                    };

                    listaClientes.Add(cliente);                   
                }

                return listaClientes;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel RetornarClientePorId(int id)
        {
            try
            {
                string qry = $"SELECT * FROM CLIENTE WHERE id = {id}";
                var dal = new DAL();
                DataTable tabela = dal.RetornarDataTable(qry);

                if (tabela.Rows.Count > 0)
                {
                    var cliente = new ClienteModel()
                    {
                        id = Convert.ToInt32(tabela.Rows[0]["id"]),
                        nome = tabela.Rows[0]["nome"].ToString(),
                        data_cadastro = Convert.ToDateTime(tabela.Rows[0]["data_cadastro"].ToString()),
                        cpf_cnpj = tabela.Rows[0]["cpf_cnpj"].ToString(),
                        data_nascimento = tabela.Rows[0]["data_nascimento"].ToString(),
                        tipo = tabela.Rows[0]["tipo"].ToString(),
                        telefone = tabela.Rows[0]["telefone"].ToString(),
                        email = tabela.Rows[0]["email"].ToString(),
                        cep = tabela.Rows[0]["cep"].ToString(),
                        logradouro = tabela.Rows[0]["logradouro"].ToString(),
                        numero = tabela.Rows[0]["numero"].ToString(),
                        bairro = tabela.Rows[0]["bairro"].ToString(),
                        complemento = tabela.Rows[0]["complemento"].ToString(),
                        cidade = tabela.Rows[0]["cidade"].ToString(),
                        uf = tabela.Rows[0]["uf"].ToString()
                    };

                    return cliente;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarCliente(ClienteModel infos)
        {
            try
            {
                var dataNascimento = Convert.ToDateTime(infos.data_nascimento);

                string qry = "UPDATE CLIENTE " +
                    " SET " +
                    $" nome = '{infos.nome}'" +
                    $",data_cadastro = '{DateTime.Now.ToString("yyyy/MM/dd")}'" +
                    $",cpf_cnpj = '{infos.cpf_cnpj}'" +
                    $",data_nascimento = '{dataNascimento.ToString("yyyy/MM/dd")}'" +
                    $",tipo = '{infos.tipo}'" +
                    $",telefone = '{infos.telefone}'" +
                    $",email = '{infos.email}'" +
                    $",cep = '{infos.cep}'" +
                    $",logradouro = '{infos.logradouro}'" +
                    $",numero = '{infos.numero}'" +
                    $",bairro = '{infos.bairro}'" +
                    $",complemento = '{infos.complemento}'" +
                    $",cidade = '{infos.cidade}'" +
                    $",uf = '{infos.uf}'" +
                    $" WHERE id = {infos.id}";

                var dal = new DAL();
                dal.ExecutarComandoSql(qry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirClientePorId(int id)
        {
            try
            {
                string qry = $"DELETE FROM CLIENTE WHERE id = {id}";

                var dal = new DAL();
                dal.ExecutarComandoSql(qry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
