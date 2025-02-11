using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioWebsite.Models;
using Microsoft.EntityFrameworkCore;


namespace PortfolioWebsite.Services
{
    public class VisitorLogService
    {
        private readonly ApplicationDbContext _context;

        public VisitorLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogVisitorAsync(VisitorLog log)
        {
            _context.VisitorLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}