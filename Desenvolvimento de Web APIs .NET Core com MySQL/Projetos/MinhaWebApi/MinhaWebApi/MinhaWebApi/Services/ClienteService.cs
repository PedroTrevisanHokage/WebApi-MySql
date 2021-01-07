using MinhaWebApi.Models;
using MinhaWebApi.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Services
{
    public class ClienteService
    {

        public void RegistrarCliente(ClienteModel infos)
        {
            string qry = "INSERT INTO cliente (nome, data_cadastro,cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                "VALUES(" +
                $" '{infos.nome}'" +
                $",'{DateTime.Now.ToString("yyyy/MM/dd")}'" +
                $",'{infos.cpf_cnpj}'" +
                $",'{infos.data_nascimento.ToString("yyyy/MM/dd")}'"+
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

    }
}
