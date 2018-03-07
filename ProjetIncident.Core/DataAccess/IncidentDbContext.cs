using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ProjetIncident.Core.DataAccess
{
    public class IncidentDbContext : DbContext
    {
        #region Singleton
        private static IncidentDbContext _context = null;
        public async static Task<IncidentDbContext> GetCurrent()
        {
            if (_context == null)
            {
                _context = new IncidentDbContext(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                 "incidents.db")
                );
                await _context.Database.MigrateAsync();
            }
            return _context;
        }



        #endregion
        private IncidentDbContext(string databasePath)
        {
        }
    }
}