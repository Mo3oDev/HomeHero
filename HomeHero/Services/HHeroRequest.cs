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
        public async Task AddRequest(string title, string desc, IFormFile image, string location, DateTime dateReq, int cantMb)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                fileBytes = ms.ToArray();
            }

            // Crear el registro principal
            Request request1 = new Request
            {
                RequestTitle = title,
                RequestContent = desc,
                RequestPicture = fileBytes,
                LocationServiceID = int.Parse(location),
                PublicationReqDate = dateReq,
                MembersNeeded = cantMb
            };
            _context.Request.Add(request1);

            // Crear el registro secundario con la clave foránea
            Chat chat1 = new Chat
            {
                RequestID = request1.RequestID,
                ChatCreationDate = dateReq,
            };
            _context.Chat.Add(chat1);

            // Guardar los cambios en la base de datos
            _context.SaveChangesAsync();
            
        }
    }
}
