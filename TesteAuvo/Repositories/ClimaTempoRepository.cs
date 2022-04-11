using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TesteAuvo.Data;
using TesteAuvo.ExtensionsMethod;

namespace TesteAuvo.Repositories
{
    public class ClimaTempoRepository : IClimaTempoRepository
    {
        private ClimaTempoDbContext db;

        public ClimaTempoRepository(ClimaTempoDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PrevisaoClima> FindClimaMaximo()
        {
            var diaAtual = DateTime.Today;

            var previsaoClimaTempMaxima = db.PrevisaoClimas
                .Where(x => x.DataPrevisao == diaAtual)
                .Include(p => p.Cidade).OrderByDescending(p => p.TemperaturaMaxima)
                .Take(3).ToList();

            return previsaoClimaTempMaxima;
        }

        public IEnumerable<PrevisaoClima> FindClimaMinimo()
        {
            var diaAtual = DateTime.Today;

            var previsaoClimaTempMinimo = db.PrevisaoClimas
                .Where(x => x.DataPrevisao == diaAtual)
                .Include(p => p.Cidade).OrderBy(p => p.TemperaturaMinima)
                .Take(3).ToList();

            return previsaoClimaTempMinimo;
        }

        public IEnumerable<PrevisaoClima> FindClimaSemanal(int? CidadeId)
        {
            var start = DateTime.Now.StartOfWeek();
            var end = DateTime.Now.EndOfWeek();
  

            var previsaoSemanal = db.PrevisaoClimas
            .Where(x => x.DataPrevisao >= start && x.DataPrevisao <= end && x.CidadeId == CidadeId)
            .OrderBy(x => x.DataPrevisao)
            .ToList();

            return previsaoSemanal;

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}