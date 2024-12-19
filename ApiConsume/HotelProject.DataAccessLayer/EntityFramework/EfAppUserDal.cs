using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Models;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public int GetUserCount()
        {
            using var context = new Context();
            var count = context.Users.Count();
            return count;
        }

        public List<AppUser> UserListWithWorkLocation()
        {
           var context  = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }

        //public List<AppUser> UserListWithWorkLocations()
        //{
        //   var context  = new Context();
        //    var values = context.Users.Include(x => x.WorkLocation).Select(Y => new AppUserWorkLocationViewModel
        //    {
        //        Name = Y.Name,
        //        Surname = Y.Surname,
        //        WorkLocationID = Y.WorkLocationID,
        //        WorkLocationName = Y.WorkLocation.WorkLocationName
        //    }).ToList();

        //    return values;

        //}
        public List<AppUser> UserListWithWorkLocations()
        {
            var context = new Context();
            var values = context.Users
                .Include(x => x.WorkLocation)
                .ToList();

            // You can populate the work location property as needed or return the AppUser list directly
            return values;
        }



    }
}
