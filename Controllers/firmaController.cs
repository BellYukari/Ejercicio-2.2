using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tarea2._2FirmaDigital.Models;

namespace Tarea2._2FirmaDigital.Controllers
{
    public class firmaController
    {
        SQLiteAsyncConnection _connection;


        public firmaController()
        {
            InitializeDatabase();
        }

        async void InitializeDatabase()
        {
            SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "DBFirmas");

            _connection = new SQLiteAsyncConnection(databasePath, flags);

            await _connection.CreateTableAsync<firmaDigital>();
        }


        //Conexion a la base de datos
        public async Task Init()
        {
            try
            {
                if (_connection == null)
                {

      
                    SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;

                   var databasePath = Path.Combine(FileSystem.AppDataDirectory, "DBFirmas");

                    // Inicializa la conexión de SQLite
                    _connection = new SQLiteAsyncConnection(databasePath, extensiones);

                    // Crear la tabla si no existe
                    await _connection.CreateTableAsync<Models.firmaDigital>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Init(): {ex.Message} \nStackTrace: {ex.StackTrace}");
            }
        }

        //Create
        public async Task<int> storeFirma(firmaDigital firma)
        {
            await Init();
            if (firma.Id == 0)
            {
                return await _connection.InsertAsync(firma);
            }
            else
            {
                return await _connection.UpdateAsync(firma);
            }
        }

        //Update
        public async Task<int> updateFirma(firmaDigital firma)
        {
            await Init();
            return await _connection.UpdateAsync(firma);
        }

        //Read
        public async Task<List<Models.firmaDigital>> getListFirmas()
        {
            await Init();
            return await _connection.Table<firmaDigital>().ToListAsync();
        }

        //Read Element
        public async Task<Models.firmaDigital> getFirma(int pid)
        {
            await Init();
            return await _connection.Table<firmaDigital>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        //Delete
        public async Task<int> deleteFirma(int autorID)
        {
            await Init();
            var firmaToDelete = await getFirma(autorID);

            if (firmaToDelete != null)
            {
                return await _connection.DeleteAsync(firmaToDelete);
            }

            return 0;
        }
    }
}
