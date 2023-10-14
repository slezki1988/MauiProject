using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TarotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{value}")]
        public ActionResult<string> GetLink(int value)
        {
            switch (value)
            {
                case 1: return "https://www.artmajeur.com/medias/hd/e/l/elenaypetrik/artwork/14175050_3-karta-taro-600kh1200mm.jpg";
                case 2: return "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/RWS_Tarot_12_Hanged_Man.jpg/150px-RWS_Tarot_12_Hanged_Man.jpg";
                case 3: return "https://i.pinimg.com/474x/fb/48/7f/fb487f0108232144dea91ea1fe0187e8.jpg";
                case 4: return "https://cs9.pikabu.ru/post_img/big/2020/04/08/10/1586365533141676125.jpg";
                case 5: return "https://cdn.optipic.io/site-539/upload/iblock/f49/f4902e7e805de9e60cf1c24807d99c14.jpg";
                case 6: return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Empereur_tarot_charles6.jpg/150px-Empereur_tarot_charles6.jpg";
                case 7: return "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d2/RWS_Tarot_03_Empress.jpg/150px-RWS_Tarot_03_Empress.jpg";
                default: return "Invalid value";
            }
        }
    }

}
