using Microsoft.EntityFrameworkCore;
using MvcCoreSeriesBeanstalk.Data;
using MvcCoreSeriesBeanstalk.Models;

namespace MvcCoreSeriesBeanstalk.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }

        private async Task<int> GetMaxIdSerie()
        {
            return await this.context.Series.MaxAsync(x => x.Id) + 1;
        }

        public async Task CreateSerieAsync(string nombre, string imagen, int anyo)
        {
            Serie serie = new Serie
            {
                Id = await this.GetMaxIdSerie(),
                Nombre = nombre,
                Imagen = imagen,
                Anyo = anyo
            };
            this.context.Series.Add(serie);
            await this.context.SaveChangesAsync();
        }
    }
}
