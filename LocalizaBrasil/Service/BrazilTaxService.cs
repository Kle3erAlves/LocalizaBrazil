
namespace LocalizaBrasil.Service
{
    class BrazilTaxService : ITaxService
    {             
       // Metodo
        public double Tax(double amount)           
        {
            //ProcessInvoice.basicPayment = new Process(double Basicpayment);

            if ( amount <= 100.00)
            { 
                return 0.20 * amount;
            }
            else
            {
                return 0.15 * amount; 
            }
        }

    }
}
