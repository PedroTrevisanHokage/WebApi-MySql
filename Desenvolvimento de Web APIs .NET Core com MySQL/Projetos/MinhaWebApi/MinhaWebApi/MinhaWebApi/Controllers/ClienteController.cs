using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaWebApi.Models;
using MinhaWebApi.Services;
using MinhaWebApi.Util;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace MinhaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<ClienteController> _logger;

        //public ClienteController(ILogger<ClienteController> logger)
        //{
        //    _logger = logger;

        //}

        Autenticacao AutenticacaoServico;

        public ClienteController(IHttpContextAccessor context)
        {
            AutenticacaoServico = new Autenticacao(context);
        }

        [HttpGet]
        public ReturnAllServices Get()
        {
            try
            {
                AutenticacaoServico.Autenticar();

                return new ReturnAllServices()
                {
                    Result = true,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Falha ao retornar dados iniciais. exMessage: {ex.Message}"
                };
            }
        }

        [HttpGet("{id}")]
        public string GetDadosPorId(int id)
        {
            try
            {
                var dal = new DAL();
                string qry = $"SELECT * FROM cliente WHERE id = {id}";

                var table = dal.RetornarDataTable(qry);
                return table.Rows[0]["nome"].ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("registrarCliente")]
        public ReturnAllServices RegistrarCliente([FromBody] ClienteModel informacoes)
        {
            var service = new ClienteService();

            try
            {
                AutenticacaoServico.Autenticar();

                service.RegistrarCliente(informacoes);
                return new ReturnAllServices()
                {
                    Result = true,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Erro ao tentar cadastrar o cliente. exMessage: {ex.Message}"
                };
            }
        }

        [HttpGet]
        [Route("RetornarTodosClientesCadastrados")]
        public ReturnAllServices RetornarTodosClientesCadastrados()
        {
            try
            {
                AutenticacaoServico.Autenticar();

                var service = new ClienteService();
                
                return new ReturnAllServices()
                {
                    Result = true,
                    Message = JsonSerializer.Serialize(service.RetornarTodosClientesCadastrados())
                };

            }
            catch (Exception ex)
            {
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Erro ao tentar retornar todos clientes. exMessage: {ex.Message}"
                };
            }
        }

        [HttpGet]
        [Route("RetornarClientePorId/{id}")]
        public ReturnAllServices RetornarClientePorId(int id)
        {
            try
            {
                AutenticacaoServico.Autenticar();

                var service = new ClienteService();

                var cliente = service.RetornarClientePorId(id);

                if (cliente != null)
                {
                    //return Ok(cliente);
                    //return Content(HttpStatusCode.OK, new ResponseDto("99", mensagemRetorno));
                    return new ReturnAllServices()
                    {
                        Result = true,
                        Message = JsonSerializer.Serialize(service.RetornarTodosClientesCadastrados())
                    };
                }
                else
                {
                    //return Ok("Não há cliente com esse ID");
                    return new ReturnAllServices()
                    {
                        Result = false,
                        Message = "Não há cliente com esse ID"
                    };
                }

                //return new ReturnAllServices()
                //{
                //    Result = true,
                //    Message = JsonSerializer.Serialize(service.RetornarTodosClientesCadastrados())
                //};

            }
            catch (Exception ex)
            {
                //return BadRequest($"Falha ao retornar dados: {ex.Message}");
                //return Content(HttpStatusCode.BadRequest, new ResponseDto("99", mensagemRetorno));
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Erro ao tentar cadastrar o cliente. exMessage: {ex.Message}"
                };

            }
        }

        [HttpPut]
        public ReturnAllServices AtualizarCliente([FromBody] ClienteModel informacoes)
        {
            try
            {
                AutenticacaoServico.Autenticar();

                var service = new ClienteService();                

                var cliente = service.RetornarClientePorId(informacoes.id);

                if (cliente != null)
                {
                    service.AtualizarCliente(informacoes);

                    return new ReturnAllServices()
                    {
                        Result = true,
                        Message = $"Informações atualizadas com sucesso"
                    };
                }
                else
                {
                    return new ReturnAllServices()
                    {
                        Result = false,
                        Message = $"Não há cliente com esse ID"
                    };
                }


            }
            catch (Exception ex)
            {
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Erro ao tentar atualizar o cliente. exMessage: {ex.Message}"
                };
            }
        }

        [HttpDelete]
        [Route("excluirCliente/{id}")]
        public ReturnAllServices ExcluirClientePorId(int id)
        {
            
            try
            {
                AutenticacaoServico.Autenticar();
                
                var service = new ClienteService();

                var cliente = service.RetornarClientePorId(id);

                if (cliente != null)
                {
                    service.ExcluirClientePorId(id);

                    return new ReturnAllServices()
                    {
                        Result = true,
                        Message = $"Cliente excluido com sucesso"
                    };
                }
                else
                {
                    return new ReturnAllServices()
                    {
                        Result = false,
                        Message = $"Não há cliente com esse ID"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ReturnAllServices()
                {
                    Result = false,
                    Message = $"Erro ao tentar excluir o cliente. exMessage: {ex.Message}"
                };
            }
        }

    }
}
