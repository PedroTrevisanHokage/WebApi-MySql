using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaWebApi.Util
{
    public class Autenticacao
    {
        public static string token = "132131sxfvasddbvdwe654cHokage";
        public static string FALHA_AUTENTICACAO = "Falha na autenticação: O token informado é inválido.";
        IHttpContextAccessor contextAccessor;

        public Autenticacao(IHttpContextAccessor context)
        {
            contextAccessor = context;
        }

        public void Autenticar()
        {
            try
            {
                string tokenbRecebido = contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (!String.Equals(token, tokenbRecebido))
                {
                    throw new Exception(FALHA_AUTENTICACAO);
                }
            }
            catch (Exception)
            {
                throw new Exception(FALHA_AUTENTICACAO);
            }
        }
    
    }
}
