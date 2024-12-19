using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal: GenericRepository<Booking>,IBookingDal
    {
        public EfBookingDal(Context context): base(context) { }

        public int GetBookingCount()
        {
            using var context = new Context();
            var count = context.Bookings.Count();
            return count;
        }

        public List<Booking> GetLast6Booking()
        {
            var context = new Context();
            var values = context.Bookings.OrderByDescending(x=> x.BookingId).Take(6).ToList();
            return values;
        }
    }
}
