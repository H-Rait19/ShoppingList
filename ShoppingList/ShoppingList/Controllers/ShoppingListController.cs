using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShoppingList.Models;
using ShoppingList.ShoppingListItems;

namespace ShoppingList.Controllers
{
    public class ShoppingListController : ApiController
    {
        private readonly ShoppingListModel _skmModel = new ShoppingListModel();

        [HttpPost]
        public HttpResponseMessage PostItemToShoppingList(string itemName, int quantity)
        {
            if(!_skmModel.AddItem(itemName.ToLower(), quantity)) return new HttpResponseMessage(HttpStatusCode.NotModified);
            return Request.CreateResponse(HttpStatusCode.OK, new Items() {Name = itemName, Quantity = quantity});
        }

        [HttpPut]
        public HttpResponseMessage PutUpdateItemQuantity(string itemName, int quantity)
        {
            if(!_skmModel.UpdateQuantity(itemName.ToLower(), quantity)) return new HttpResponseMessage(HttpStatusCode.NotModified);
            return Request.CreateResponse(HttpStatusCode.OK, new Items() { Name = itemName, Quantity = quantity });
        }
        
        [HttpDelete]
        public HttpResponseMessage DeleteItemFromList(string itemName)
        {
            if(!_skmModel.RemoveItem(itemName.ToLower())) return new HttpResponseMessage(HttpStatusCode.NotModified);
            return Request.CreateResponse(HttpStatusCode.OK, new Items() { Name = itemName, Quantity = 0 });
        }

        [HttpGet]
        public HttpResponseMessage GetItemQuantity(string itemName)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { quantity = _skmModel.GetQuantity(itemName.ToLower())});
        }

        [HttpGet]
        public HttpResponseMessage GetAllShoppingListItems()
        {
            var list = _skmModel.GetAllListItems();
            return Request.CreateResponse(HttpStatusCode.OK, new { ShoppingItemList = list });
        }



    }
}
