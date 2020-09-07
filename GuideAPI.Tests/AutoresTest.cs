using GuideAPI.Application.Interfaces;
using GuideAPI.Application.Services;
using GuideAPI.Application.ViewModel;
using GuideAPI.Domain.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GuideAPI.Tests
{
    public class AutoresTest
    {
        private readonly AutoresAppService _autoresAppService;
        private readonly Mock<IAutoresRepository> _autoresRepositoryMock = new Mock<IAutoresRepository>();

        public AutoresTest()
        {
            _autoresAppService = new AutoresAppService(_autoresRepositoryMock.Object);
        }

        [Theory]
        [InlineData("João da Silva", "SILVA, João da")]
        [InlineData("Paulo da Silva Neto", "SILVA NETO, Paulo")]
        public void ValidarNome(string nomeAutor, string nomeAutorFormatadoEsperado)
        {
            var lstAutores = new List<AutoresViewModel>();

            lstAutores.Add(new AutoresViewModel { Nome = nomeAutor });

            var nomeAutorFormatado = _autoresAppService.ManipularNome(lstAutores);

            foreach(var item in nomeAutorFormatado)
            {
                Assert.Equal(nomeAutorFormatadoEsperado, item.Nome);
            }
        }
    }
}
