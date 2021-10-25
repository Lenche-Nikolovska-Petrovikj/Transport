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
                int volumeCalc = DistancePriceCar;
                int distance = Distance;
                int total = volumeCalc + distance;
                return total;
            }
        }

    }
}
