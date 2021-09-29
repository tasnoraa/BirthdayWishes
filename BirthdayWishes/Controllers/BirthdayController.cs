using BirthdayService;
using System.Web.Http;

namespace BirthdayWishes.Controllers
{
    public class BirthdayController : ApiController
    {
        IBirthdayWishesService _birthdayWishes;

        public BirthdayController(IBirthdayWishesService birthdayWishes)
        {
            _birthdayWishes = birthdayWishes;
        }

        public string GetBirthdays()
        {
            return _birthdayWishes.getEmployeeBirthday();
        }
    }
}
