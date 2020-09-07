using GuideAPI.Domain.Interface;
using GuideAPI.Domain.Models;
using GuideAPI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideAPI.Infra.Data.Repository
{
    public class AutoresRepository : Repository<Autores>, IAutoresRepository
    {
        public AutoresRepository(GuideContext context)
            : base(context)
        {
        }
    }
}
