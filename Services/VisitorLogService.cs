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
            var existingVisitor = await _context.VisitorLogs
                .FirstOrDefaultAsync(v => v.IPAddress == log.IPAddress);
            
            // Update existing visitor log
            if (existingVisitor != null)
            {
                existingVisitor.LastSeen = DateTime.UtcNow;
                existingVisitor.VisitCount += 1;
            }
            // New visitor
            else
            {
                log.FirstVisit = DateTime.UtcNow;
                log.LastSeen = log.FirstVisit;
                log.VisitCount = 1;

                _context.VisitorLogs.Add(log);
            }

            await _context.SaveChangesAsync();
        }
    }
}