namespace CalculoSalarioBaseadoEmContratos.Entities
{
    internal class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract() { }

        public double totalValue()
        {
            double total = ValuePerHour * Hours;
            return total;
        }
    }
}
