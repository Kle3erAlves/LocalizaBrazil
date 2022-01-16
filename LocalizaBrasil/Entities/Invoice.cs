using System.Globalization;

namespace LocalizaBrasil.Entities
{
    class Invoice
    {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }
        
        public Invoice()
        {
        }

        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment //PROPRIEDADE CALCULADA
        {
            get { return BasicPayment + Tax; }
        }

        public override string ToString()
        {
            return "Basic payment:"
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\n TAX: "
                + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\n Total Payment: "
                + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
