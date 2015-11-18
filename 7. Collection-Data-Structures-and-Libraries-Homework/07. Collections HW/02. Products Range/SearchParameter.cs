namespace _02.Products_Range
{
    public class SearchParameter
    {
        public SearchParameter(decimal lowPrice, decimal highPrice)
        {
            this.LowPrice = lowPrice;
            this.HighPrice = highPrice;
        }

        public decimal LowPrice { get; set; }

        public decimal HighPrice { get; set; }

        public override string ToString()
        {
            return this.LowPrice + " - " + this.HighPrice;
        }
    }
}
