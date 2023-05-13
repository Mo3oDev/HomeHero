using HomeHero.Data;
using HomeHero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HomeHero.Services
{
    public class HHeroPostulation
    {
        readonly HomeHeroContext _context;
        public HHeroPostulation(HomeHeroContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPostulation(int requestId, int price, int userId)
        {
            if (await ValidatePostulationAsync(requestId, userId))
            {
                Request req = await _context.Request.FirstOrDefaultAsync(r => r.RequestID == requestId);
                AttentionRequest attentionRequest = new AttentionRequest
                {
                    RequestID_AttentionRequest = requestId,
                    HelperUserID = userId,
                    AttentionReqValue = price,
                    AttentionDate = DateTime.Now
                };
                _context.AttentionRequest.Add(attentionRequest);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> ValidatePostulationAsync(int requestId, int userId)
        {
            AttentionRequest attention = await _context.AttentionRequest
                .FirstOrDefaultAsync(e => e.HelperUserID == userId && e.RequestID_AttentionRequest == requestId);
            return attention == null;
        }
    }
}
