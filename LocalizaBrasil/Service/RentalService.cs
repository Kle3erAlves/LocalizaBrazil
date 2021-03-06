using System;
using LocalizaBrasil.Entities;

namespace LocalizaBrasil.Service
{
    class RentalService
    {   //Atributos
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        //private BrazilTaxService _brazilTaxService = new BrazilTaxService();//Não pode depdender  de uma classe especifica, deverá ser generica Interface
        //veja abaixo:

        private ITaxService _taxService;
        //Construtores
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }
        //Metodos
        public void ProcessInvoice(CarRental carRental)        {
            ///calculo da locacao
            ///
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);//SUBTRAI A DATA FINAL DA DATA DE INICIO

            double basicPayment = 0.0; //INICIO O BasicPayment em "zero
            if (duration.TotalHours <= 12.0)//se duracao menor que 12 horas...
            {
                 basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); //...Basic pagamento = priceperhours * total hours
                                            //Math Ceiling arredonda pra cima          
            }
            else
            {
                 basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);//se nao Basic Payment = priceperhours * total day 
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);

        }
    }
}
