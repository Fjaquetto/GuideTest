using GuideAPI.Application.ViewModel;
using GuideAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Application.Interfaces
{
    public interface IAutoresAppService : IDisposable
    {
        Task<List<AutoresViewModel>> ObterTodos();
        Task<bool> Adicionar(IEnumerable<AutoresViewModel> autores);
        IEnumerable<Autores> ManipularNome(IEnumerable<AutoresViewModel> autores);
    }
}
