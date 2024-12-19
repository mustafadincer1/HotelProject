﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public int TGetRoomCount()
        {
          return  _roomDal.GetRoomCount();
        }

        public void TDelete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public Room TGetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TInsert(Room entity)
        {
            _roomDal.Insert(entity);
        }

        public void TUpdate(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}
