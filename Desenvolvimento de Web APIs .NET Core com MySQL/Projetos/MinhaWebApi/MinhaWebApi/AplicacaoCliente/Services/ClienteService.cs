using AplicacaoCliente.Models;
using AplicacaoCliente.Util;
using MinhaWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacaoCliente.Services
{
    public class ClienteService
    {
        public List<ClienteModel> ListarTodosClientes()
        {
            try
            {
                var retorno = new List<ClienteModel>();

                var responseJson = WebAPI.RequestGet("RetornarTodosClientesCadastrados", String.Empty);

                var response = JsonConvert.DeserializeObject<ReturnAllServices>(responseJson);

                var clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(response.Message);

                return clientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
