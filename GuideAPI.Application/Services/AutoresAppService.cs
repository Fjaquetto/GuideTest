using GuideAPI.Application.Interfaces;
using GuideAPI.Application.ViewModel;
using GuideAPI.Domain.Interface;
using GuideAPI.Domain.Models;
using GuideAPI.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Application.Services
{
    public class AutoresAppService : IAutoresAppService
    {
        private readonly IAutoresRepository _autoresRepository;

        public AutoresAppService(IAutoresRepository autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }

        public async Task<List<AutoresViewModel>> ObterTodos()
        {
            List<AutoresViewModel> autoresViewModel = new List<AutoresViewModel>();

            foreach (var item in await _autoresRepository.ObterTodos())
            {
                autoresViewModel.Add(new AutoresViewModel { Nome = item.Nome });
            }

            return autoresViewModel;
        }

        public async Task<bool> Adicionar(IEnumerable<AutoresViewModel> autores)
        {
            var lstAutores = ManipularNome(autores);

            foreach (var item in lstAutores)
            {
                await _autoresRepository.Adicionar(item);
            }
            return true;
        }

        public IEnumerable<Autores> ManipularNome(IEnumerable<AutoresViewModel> autores)
        {
            List<Autores> lstAutores = new List<Autores>();

            foreach (var itens in autores)
            {
                var nome = itens.Nome.Split(' ');

                string primeiroNome = nome.First().First().ToString().ToUpper() + nome.First().Substring(1);
                string nomeMeio = String.Empty;
                string ultimoNome = nome.Last().ToUpper();
                string nomeCompleto = String.Empty;

                if (new string[] { "da", "de", "do", "das", "dos" }.Contains(nome[nome.Length - 2]))
                {
                    primeiroNome = primeiroNome + " " + nome[nome.Length - 2];
                }

                if (new string[] { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" }.Contains(ultimoNome))
                {
                    nomeMeio = nome[nome.Length - 2].ToUpper();
                }

                nomeCompleto = ultimoNome + ", " + primeiroNome;

                if (!string.IsNullOrEmpty(nomeMeio))
                {
                    nomeCompleto = nomeMeio + " " + ultimoNome + ", " + primeiroNome;
                }
                lstAutores.Add(new Autores { Nome = nomeCompleto });
            };
            return lstAutores;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
