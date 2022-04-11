using System;
using System.Collections.Generic;
using TesteAuvo.Data;

namespace TesteAuvo.Repositories
{
    public interface IClimaTempoRepository : IDisposable
    {
        IEnumerable<PrevisaoClima> FindClimaMaximo();
        IEnumerable<PrevisaoClima> FindClimaMinimo();
        IEnumerable<PrevisaoClima> FindClimaSemanal(int? CidadeId);
    }
}