using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaWebApi.Util;

namespace MinhaWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
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
        public IEnumerable<string> Get2()
        {
            try
            {
                //var dal = new DAL();
                //string qry = "INSERT INTO cliente (nome, data_cadastro,cpf_cnpj, data_nascimento, tipo, telefone, email, cep, logradouro, numero, bairro, complemento, cidade, uf)" +
                //    "VALUES(" +
                //    " 'Teste1'" +
                //    $",'{DateTime.Now.ToString("yyyy/MM/dd")}'" +
                //    ",'367.883.528.79'" +
                //    ",'1988/04/01'" +
                //    ",'F'" +
                //    ",'9999999999'" +
                //    ",'pedtrevisan@gmail.com'" +
                //    ",'14092-460'" +
                //    ",'Rua Teste'" +
                //    ",'545'" +
                //    ",'Bairro Teste'" +
                //    ",'Complemento TESTE'" +
                //    ",'Cidade Teste'" +
                //    ",'TT'" +
                //    ")";

                //dal.ExecutarComandoSql(qry);

                return new string[] { "OK" };
            }
            catch (Exception ex)
            {
                return new string[] { $"{ex.Message}" };
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
    }
}
