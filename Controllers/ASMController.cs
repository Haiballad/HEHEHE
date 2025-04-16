
using ASM.Models;
using ASM.Models.ViewModels;
using ASM.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ASMController : ControllerBase
    {
        private readonly ItemServices _itemServices;

        public ASMController(ItemServices itemServices)
        {
            _itemServices = itemServices;
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAllItems()
        {
            var items = _itemServices.GetAllItems();
            return Ok(items);
        }

        [HttpGet("GetAllItemsByGameMode/{gameMode}")]
        public async Task<IActionResult> GetAllItemsByGameMode(string gameMode)
        {
            var players = await _itemServices.GetPlayersByGameModeAsync(gameMode);
            return Ok(players);
        }
        [HttpGet("GetWeaponsWithExperience/{experience}")]
        public async Task<IActionResult> GetWeaponsWithExperience(int experience)
        {
            var weapons = await _itemServices.GetWeaponsWithExperienceAsync(experience);
            return Ok(weapons);
        }
        [HttpGet("GetPurchasableItemsForPlayer/{playerId}")]
        public async Task<IActionResult> GetPurchasableItemsForPlayer(int playerId)
        {
            try
            {
                var items = await _itemServices.GetPurchasableItemsForPlayerAsync(playerId);
                return Ok(items);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItemsWithNameAndPrice/{name}/{maxPrice}")]
        public async Task<IActionResult> GetItemsWithNameAndPrice(string name, int maxPrice)
        {
            var items = await _itemServices.GetItemsWithNameAndPriceAsync(name, maxPrice);
            return Ok(items);
        }

        [HttpGet("GetPlayerItemHistory/{playerId}")]
        public IActionResult GetPlayerItemHistory(int playerId)
        {
            var history = _itemServices.GetPlayerItemHistory(playerId);
            return Ok(history);
        }

        [HttpPost("AddItem")]
        public IActionResult AddItem([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item cannot be null.");
            }

            var items = _itemServices.AddItem(item);
            return CreatedAtAction(nameof(GetAllItems), new { id = item.ItemId }, items);
        }
        
        [HttpPost("UpdtaPassword")]
        public ActionResult<Account> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                var account = _itemServices.ChangePassword(
                    request.AccountId,
                    request.CurrentPassword,
                    request.NewPassword
                );
                return Ok(account); // Có thể trả về DTO nếu không muốn lộ PasswordHash
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetMostPurchasedItems/{topN}")]
        public IActionResult GetMostPurchasedItems(int topN)
        {
            var items = _itemServices.GetMostPurchasedItems(topN);
            return Ok(items);
        }

        [HttpGet("GetAllPlayerAndPurchaseCounts")]
        public IActionResult GeAlltPlayerAndPurchaseCounts()
        {
            var players = _itemServices.GeAlltPlayerAndPurchaseCounts();
            return Ok(players);
        }
    }
}