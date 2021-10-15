using System;
using PM2E100380028.Modelo;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E100380028.Controlador
{
    public class Controller
    {
        readonly SQLiteAsyncConnection db;

        public Controller(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Coordenadas>().Wait();
        }
        public Task<List<Coordenadas>> ObtenerListaPersonas()
        {
            return db.Table<Coordenadas>().ToListAsync();

        }

        public Task<Coordenadas> ObtenerPersonas(int pcodigo)
        {
            return db.Table<Coordenadas>().Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }
        public Task<int> CrearPersonas(Coordenadas personas)
        {
            if (personas.codigo != 0)
            {
                return db.UpdateAsync(personas);

            }
            else
            {
                return db.InsertAsync(personas);
            }
        }
        public Task<int> EliminarPersonas(Coordenadas personas)
        {
            return db.DeleteAsync(personas);
        }
    }
}
