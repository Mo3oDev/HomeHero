using HomeHero.Data;
using HomeHero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace HomeHero.Services
{
    public class HHeroRequest
    {
        readonly HomeHeroContext _context;
        public HHeroRequest(HomeHeroContext context)
        {
            _context = context;
        }
        public async Task AddRequest(string title, string desc, IFormFile image, string location, DateTime dateReq, int cantMb, int userId)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }
            Request request1 = new Request
            {
                UserId_Request = userId,
                RequestTitle = title,
                RequestContent = desc,
                RequestPicture = fileBytes,
                LocationServiceID = int.Parse(location),
                PublicationReqDate = dateReq,
                MembersNeeded = cantMb,
                ReqStateID_Request = 1,
               
            };
            _context.Request.Add(request1);
            await _context.SaveChangesAsync();

            Chat chat1 = new Chat
            {
                RequestID_Chat= request1.RequestID,
                ChatCreationDate = dateReq,
            };
            _context.Chat.Add(chat1);
            await _context.SaveChangesAsync();


        }
    }
}
