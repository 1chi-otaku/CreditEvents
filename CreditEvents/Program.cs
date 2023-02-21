using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard a = new CreditCard();
            Observer observer= new Observer();

            a.CreditMoney += new voidDelegate(Observer.CreditMoney);
            a.PINChanged += new voidDelegate(Observer.PinChanged);
            a.SummAchieve += new voidDelegate(Observer.PinChanged);
            a.ToppedDown += new voidDelegate(Observer.ToppedDown);
            a.ToppedUp += new voidDelegate(Observer.ToppedUp);

            a.TopUp(100);
            a.TopDown(10000);
            a.ChangePin();
            





        }
    }
}
