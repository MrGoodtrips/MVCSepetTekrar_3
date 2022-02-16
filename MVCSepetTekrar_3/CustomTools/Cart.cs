using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSepetTekrar_3.CustomTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetUrunlerim;

        public Cart()
        {
            _sepetUrunlerim = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetUrunlerim.Values.ToList();
            }
        }

        public void SepeteEkle(CartItem item)
        {
            //Öncelikle Sepete daha önce o aynı ürün atılmıs mı onu sorgulamalayız
            if (_sepetUrunlerim.ContainsKey(item.ID))
            {
                //Bir Dictionary'e index parantezi verirseniz o key'i yakalamak istediginizi bildirir...
                _sepetUrunlerim[item.ID].Amount += 1;
                return;
            }
            _sepetUrunlerim.Add(item.ID, item);
        }


        public void SepettenSil(int id)
        {
            if (_sepetUrunlerim[id].Amount > 1)
            {
                _sepetUrunlerim[id].Amount -= 1;
                return;
            }
            _sepetUrunlerim.Remove(id);
        }

        //Sepetim Toplam Fiyatı
        public decimal? TotalPrice
        {
            get
            {
                return _sepetUrunlerim.Sum(x => x.Value.SubTotal);
            }



            /*
             
             decimal? toplam = 0;
             foreach(CartItem item in _sepetUrunlerim)
            {
               toplam += item.SubTotal;
            }
             
             
             
             
             
             */
        }
    }
}