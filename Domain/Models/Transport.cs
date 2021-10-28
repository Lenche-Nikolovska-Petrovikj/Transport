using Infrastructure.Data.Models.Base;


namespace Infrastructure.Data.Models
{
   
    public class Transport : AuditableBaseEntity
    {
        public int Distance { get; set; }
        public int LivingArea { get; set; }
        public int AtticArea { get; set; }
        public int DistancePriceCar
        {
            get
            {
                int living = LivingArea;
                int attic = AtticArea;
                int calc = (living + (attic * 2)) / 50;
                return calc;

            }
        }
        public bool Piano { get; set; }

        public int Price
        {
            get
            {
                int distPrice;
                int volumeCalc = ((LivingArea + (AtticArea * 2)) / 50);
                if (Distance < 50)
                {
                    distPrice = 1000 + (Distance * 10);
                }
                else if (Distance > 50 || Distance < 100)
                {
                    distPrice = 5000 + (Distance * 8);
                }
                else
                {
                    distPrice = 10000 + (Distance * 7);
                }
                var price = distPrice * volumeCalc;
                var totalPrice = Piano ? price + 5000 : price;
                return totalPrice;

            }
        }

    }
}
