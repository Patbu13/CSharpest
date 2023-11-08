using CSharpest.Classes;

namespace CSharpest.Services
{
    public class CardService
    {
        private readonly CardService _cardService;
        InventoryLoader inventoryLoader = new InventoryLoader(@".\data\inventory.json");


        public CardService()
        {
        }

        public string Get()
        {
            return "hello";
        }
    }
}
