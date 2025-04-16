using ASM.Models;
using ASM.AppDataContext;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ASM.Services
{
    public class ItemServices : IItemServices
    {
        private readonly AppDbContext _context;

        public ItemServices(AppDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }
        
        public async Task<List<Player>> GetPlayersByGameModeAsync(string gameMode)
        {
            return await _context.Players
                .Where(p => p.CurrentMod == gameMode)
                .ToListAsync();
        }

        public async Task<List<Item>> GetWeaponsWithExperienceAsync(int experience)
        {
            return await _context.Items
                .Where(i => i.Type == "Weapon" && i.XPPrice > experience)
                .ToListAsync();
        }

        public async Task<List<Item>> GetPurchasableItemsForPlayerAsync(int playerId)
        {
            var player = await _context.Players.FirstOrDefaultAsync(p => p.PlayerId == playerId);
            if (player == null)
            {
                throw new ArgumentException($"Player with ID {playerId} not found.");
            }

            return await _context.Items
                .Where(i => i.XPPrice <= player.XP)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsWithNameAndPriceAsync(string name, int maxPrice)
        {
            return await _context.Items
                .Where(i => i.Name.Contains(name) && i.XPPrice < maxPrice)
                .ToListAsync();
        }

        public List<PlayerItem> GetPlayerItemHistory(int playerId)
        {
            return _context.PlayerItems
                .Where(pi => pi.PlayerId == playerId)
                //.Include(pi => pi.PlayerItemId)
                .OrderByDescending(pi => pi.DateAcquired)
                .ToList();
        }

        public List<Item> AddItem(Item item)
        {
            var newItem = new Item
            {
                Name = item.Name,
                Type = item.Type,
                XPPrice = item.XPPrice,
                ImageUrl = item.ImageUrl,
                Description = item.Description
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();

            return _context.Items.ToList();
        }

        public Account ChangePassword(int accountId, string currentPassword, string newPassword)
        {
            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);

            if (acc == null)
            {
                throw new Exception("Account not found.");
            }

            if (acc.PasswordHash != currentPassword)
            {
                throw new Exception("Current password is incorrect.");
            }

            acc.PasswordHash = newPassword;
            _context.SaveChanges();

            return acc;
        }

        public List<Item> GetMostPurchasedItems(int topN)
        {
            return _context.Items
                .OrderByDescending(i => i.XPPrice)
                .Take(topN)
                .ToList();
        }

        public List<PlayerItem> GeAlltPlayerAndPurchaseCounts()
        {
            return _context.PlayerItems
                .GroupBy(pi => pi.PlayerId)
                .Select(g => new PlayerItem
                {
                    PlayerId = g.Key,
                    Quantity = g.Count()
                })
                .ToList();
        }
    }
}