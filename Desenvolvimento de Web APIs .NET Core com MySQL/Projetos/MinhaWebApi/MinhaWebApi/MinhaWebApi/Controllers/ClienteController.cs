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

        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public ReturnAllServices Get()
        {
            try
            {
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
        public IActionResult RetornarTodosClientesCadastrados()
        {
            try
            {
                var service = new ClienteService();

                return Ok(service.RetornarTodosClientesCadastrados());
                
                //return new ReturnAllServices()
                //{
                //    Result = true,
                //    Message = JsonSerializer.Serialize(service.RetornarTodosClientesCadastrados())
                //};

            }
            catch (Exception ex)
            {
                return BadRequest($"Falha ao retornar dados: {ex.Message}");
                //return new ReturnAllServices()
                //{
                //    Result = false,
                //    Message = $"Erro ao tentar cadastrar o cliente. exMessage: {ex.Message}"
                //};
            }
        }

        [HttpGet]
        [Route("RetornarClientePorId/{id}")]
        public IActionResult RetornarClientePorId(int id)
        {
            try
            {
                var service = new ClienteService();

                var cliente = service.RetornarClientePorId(id);

                if (cliente != null)
                {
                    return Ok(cliente);
                    //return Content(HttpStatusCode.OK, new ResponseDto("99", mensagemRetorno));
                }
                else
                {
                    return Ok("Não há cliente com esse ID");
                }

                //return new ReturnAllServices()
                //{
                //    Result = true,
                //    Message = JsonSerializer.Serialize(service.RetornarTodosClientesCadastrados())
                //};

            }
            catch (Exception ex)
            {
                return BadRequest($"Falha ao retornar dados: {ex.Message}");
                //return new ReturnAllServices()
                //{
                //    Result = false,
                //    Message = $"Erro ao tentar cadastrar o cliente. exMessage: {ex.Message}"
                //};

                //return Content(HttpStatusCode.BadRequest, new ResponseDto("99", mensagemRetorno));
            }
        }

        [HttpPut]
        public ReturnAllServices AtualizarCliente([FromBody] ClienteModel informacoes)
        {
            try
            {
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
