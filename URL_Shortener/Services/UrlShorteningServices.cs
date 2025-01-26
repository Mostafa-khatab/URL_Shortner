using Microsoft.EntityFrameworkCore;
using URL_Shortener.Models;

namespace URL_Shortener.Services
{
    public class UrlShorteningServices
    {
        public int NumberOfChars = 7;
        private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private readonly AppDbContext _dbContext;

        public UrlShorteningServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GenerateShortUrl(string url)
        {
            List<char> list = new List<char>();
            while (true)
            {
                for (int i = 0; i < NumberOfChars; i++)
                {
                    var index = Random.Shared.Next(Alphabet.Length - 1);
                    list.Add(Alphabet[index]);
                }
                var code = new string(list.ToArray());
                if (!await _dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }

    }
}
