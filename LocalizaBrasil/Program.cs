﻿using System;
using System.Globalization;
using LocalizaBrasil.Entities;
using LocalizaBrasil.Service;

namespace LocalizaBrasil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data: ");
            Console.Write("Car model: ");
            string car = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy  hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy  hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);


            Console.Write("Enter price per hour: ");
            double priceHour = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double priceDay = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(car));

            RentalService rentalService = new RentalService(priceHour, priceDay);

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("");
            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
