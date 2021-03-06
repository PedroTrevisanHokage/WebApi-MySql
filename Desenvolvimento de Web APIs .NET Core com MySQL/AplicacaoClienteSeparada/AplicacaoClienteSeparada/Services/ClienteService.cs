﻿using AplicacaoClienteSeparada.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoClienteSeparada.Util;

namespace AplicacaoClienteSeparada.Services
{
    public class ClienteService
    {
        public List<ClienteModel> ListarTodosClientes()
        {
            try
            {
                var retorno = new List<ClienteModel>();

                var responseJson = WebAPI.RequestGet("RetornarTodosClientesCadastrados", "");

                var response = JsonConvert.DeserializeObject<ReturnAllServices>(responseJson);

                var clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(response.Message);

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Inserircliente(ClienteModel dados)
        {
            try
            {
                WebAPI.RequestPost("registrarCliente", JsonConvert.SerializeObject(dados));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel ListarClientePorId(int? id)
        {
            try
            {
                var responseJson = WebAPI.RequestGet("RetornarClientePorId", $"{id}");

                var response = JsonConvert.DeserializeObject<ReturnAllServices>(responseJson);

                var clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(response.Message);

                return clientes.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarCliente(ClienteModel dados)
        {
            try
            {
                WebAPI.RequestPut(String.Empty, JsonConvert.SerializeObject(dados));
            }
            catch (Exception  ex)
            {
                throw ex;
            }
        }

        public void ExcluirCliente(int id)
        {
            try
            {
                WebAPI.RequestDelete("excluirCliente", id.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
