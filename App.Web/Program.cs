using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using App.Web.Security;
using App.Web.Repositories;
using Microsoft.EntityFrameworkCore;
using App.Web.Models.Entities;

namespace App.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //List<Usuario> usuario = new List<Usuario>
            //{
            //    new Usuario{Nome = "Gustavo", Email = "gus@gmail.com", DataDeNascimento = DateTime.Parse("20/02/2012"), Senha = "1234", Sexo = Sexo.Masculino, Ativo = 1 },
            //    new Usuario{Nome = "Ronaldo", Email = "ron@gmail.com", DataDeNascimento = DateTime.Parse("20/02/2012"), Senha = "1234", Sexo = Sexo.Masculino, Ativo = 0 },
            //    new Usuario{Nome = "Elis", Email = "elis@gmail.com", DataDeNascimento = DateTime.Parse("20/02/2012"), Senha = "1234", Sexo = Sexo.Feminino, Ativo = 1 },
            //};

            //Console.WriteLine(usuario.FirstOrDefault(u => u.Ativo == 0).ToString()) ;

            //SecurityManager security = new SecurityManager(SHA512.Create());

            //var senha = security.CriptografaSenha("123456");

            //var senhaValidada = security.ValidaSenha("123456", senha);

            //Console.WriteLine(senha);
            //Console.WriteLine(security.CriptografaSenha("123456"));
            //Console.WriteLine(senhaValidada);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
