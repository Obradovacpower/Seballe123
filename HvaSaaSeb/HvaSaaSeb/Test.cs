using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HvaSaaSeb.Models;
using HvaSaaSeb.Data;

namespace HvaSaaSeb
{
    public class Test
    {
        public int AmountOfOrders(DateTime day)
        {
            //given a date, how many guests have ordered food
            var db = new ApplicationDbContext(default);


            var target = db.Set<OrderEntity>().ToList();
            return target.Count(x => x.Day == day);
        }
        public int AmountDoneEating(DateTime day)
        {
            //get a list of all guests who has eaten today, both kids and adults
            var db = new ApplicationDbContext(default);

            var target = db.Set<GuestEntity>().ToList();

            int adults = target.Count(x => (x.HasEatenToday == true) && (x.IsAdult == true));
            int kids = target.Count(x => (x.HasEatenToday == true) && (x.IsAdult == false));

            return kids + adults;
            //now print numbers
        }
        public void waiterFunc(uint roomId)
        {
            //check in for guests for breakfast
            var db = new ApplicationDbContext(default);

            var target = db.Set<GuestEntity>().ToList();
            var guestsToCheckIn = target.Where(x => x.RoomId == roomId);
            foreach(GuestEntity g in guestsToCheckIn)
            {
                g.CheckIn = true;
            }
            db.SaveChanges();
        }
        public void kitchenFunc(DateTime day)
        {
            //given a date, how many guests have ordered food, and how many are kids/adults
            var db = new ApplicationDbContext(default);

            int adults = 0;
            int kids = 0;

            var target = db.Set<OrderEntity>().ToList();
            int targets = target.Count(x => x.Day == day);
            var orders = target.Where(x => x.Day == day);
            foreach(OrderEntity o in orders)
            {
                if(o.Guest.IsAdult)
                {
                    adults++;
                }
                else
                {
                    kids++;
                }
            }
            //then print out the numbers
        }
        public void KitchenFunc2(bool kidOrAdult)
        {
            //how many adults is checked in
            var db = new ApplicationDbContext(default);

            int amount = db.Set<GuestEntity>().ToList().Count(x => x.CheckIn == kidOrAdult);
            //print number
        }
        public int NotCheckedIn(DateTime day)
        {
            //how many have yet to check in
            //you need to know amount of orders - checkedIn
            return AmountDoneEating(day) + AmountOfOrders(day);
        }
    }
}
