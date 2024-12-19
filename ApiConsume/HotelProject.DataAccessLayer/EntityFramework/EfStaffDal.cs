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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public List<Staff> GetLast4Staff()
        {
            using var context = new Context();
            var values = context.Staff.OrderByDescending(X => X.StaffId).Take(4).ToList();
            return values;

        }

        public int GetStaffCount()
        {
            using var context = new Context();
            int count = context.Staff.Count();
            return count;
        }
    }


}
