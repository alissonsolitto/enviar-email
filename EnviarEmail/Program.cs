using System;
using System.Collections.Generic;

namespace EnviarEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            //Configurações para o envio de Email
            var paramEmail = new
            {
                host = "", //Host do provedor de Email
                port = 999, //Porta do provedor de Email
                user = "", //Email usando para enviar
                password = "" //Senha do Email
            };

            //Dados para o envio de Email
            var dadosEmail = new
            {
                from = "", //Remetente
                lstTo = new List<string> { "element1", "element2", "element3" }, //Lista de destinatários
                subject = "", //Assunto
                body = "", //Mensagem
                bodyHtml = false //A mensagem é um HTML?
            };

            //Instanciando a classe Email
            var email = new Email(paramEmail.host, paramEmail.port, paramEmail.user, paramEmail.password);
            
            //Usando o método para o envio do Email
            email.SendMail(dadosEmail.from, dadosEmail.lstTo, dadosEmail.subject, dadosEmail.body, dadosEmail.bodyHtml);

            Console.ReadKey();
        }
    }
}
