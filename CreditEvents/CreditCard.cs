using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CreditEvents
{

    delegate void voidDelegate();
    internal class CreditCard
    {
        public event voidDelegate CreditMoney;
        public event voidDelegate SummAchieve;
        public event voidDelegate PINChanged;
        public event voidDelegate ToppedUp;
        public event voidDelegate ToppedDown;
        public string card_nunber { get; set; }
        public string full_name { get; set;}
        public string pin;
        public double credit_limit { get; set; }
        public double summ { get; set; }

        public CreditCard()
        {
            card_nunber = "1234567890123456";
            full_name  = "Tom vi Irish";
            pin = "1234";
            credit_limit = 1000;
            summ = 0;
        }
        public CreditCard(string card_nunber, string full_name, string pin, double credit_limit, int summ)
        {
            this.card_nunber = card_nunber;
            this.full_name = full_name;
            this.pin = pin;
            this.credit_limit = credit_limit;
            this.summ = summ;
        }

        public void TopUp(double summ)
        {
           this.summ += summ;
           ToppedUp?.Invoke();
           if(summ >= 10000) SummAchieve.Invoke();
        }
        public void TopDown(double summ)
        { 
           this.summ-= summ;
           ToppedDown?.Invoke();
            if (summ < 0 && credit_limit > 0)
            {
                CreditMoney?.Clone();
                credit_limit = 0;
                summ += credit_limit;
            }
        }
        public void ChangePin()
        {
            Console.WriteLine("Enter Your previous PIN:");
            string prev_pin = Console.ReadLine();
            if(prev_pin == pin)
            {
                Console.WriteLine("Enter Your new PIN:");
                pin = Console.ReadLine();
                PINChanged?.Invoke();
            }
            else
                Console.WriteLine("Wrong Pin");
        }

    }

    class Observer
    {
        static public void PinChanged()
        {
            Console.WriteLine("Event: Pin has been changed");
        }
        static public void ToppedUp() {
            Console.WriteLine("Event: Account has been topped up!");
        }
        static public void ToppedDown()
        {
            Console.WriteLine("Event: Money was withdrawn from the account.");
        }
        static public void CreditMoney()
        {
            Console.WriteLine("Event: Credit money began to be used!");
        }
        static public void SummAchieved()
        {
            Console.WriteLine("Event: Summ achieved!");
        }
    }

}
