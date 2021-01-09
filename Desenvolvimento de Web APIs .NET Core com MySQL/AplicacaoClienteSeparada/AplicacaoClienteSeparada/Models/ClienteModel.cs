using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AplicacaoClienteSeparada.Models
{
    public class ClienteModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        [JsonIgnore]
        public DateTime data_cadastro { get; set; }
        public string cpf_cnpj { get; set; }
        public string data_nascimento { get; set; }
        public string tipo { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
    }
}
