namespace Api.Model
{
    public class Transaction
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime Date { get; set; }
    }
}
