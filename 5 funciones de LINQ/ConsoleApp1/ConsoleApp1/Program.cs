using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numero1 = new int[] { 1, 2, 3, 4, 5, 6 };
            var numero2 = new int[] { 6, 7, 8, 9, 10 };

            var numerounion = numero1.Union(numero2); //union los mazcla pero no los repite

            numerounion.ToList().ForEach(e =>
                Console.WriteLine(e)
            );
            Console.ReadLine();
            ///////////////////////////////////////////////////////////////////////////
            var numero3 = new int[] { 1, 2, 3, 4, 5 };
            var numeroP = new string[] { "uno", "dos", "tres", "cuatro", "cinco" };
            var numbersP = numero1.Zip(numeroP, (n, p) => //hace un enlace uno a uno,si uno sobra no lo pone
            {
                return n + " " + p;
            });

            numbersP.ToList().ForEach(e =>
                Console.WriteLine(e)
            );
            Console.ReadLine();
            //////////////////////////////////////////////////////////////////////////
            var beers = new List<(string Name, int IdBrand)>
            {
                ("Miller", 1),
                ("Cristal", 1),
                ("Corona", 2),
                ("Heineken", 2)
            };
            var brand = new List<(int IdBrand, string Name)>
            {
                (1, "Erdinger"),
                (2, "Fuller")
            };
            var beersDetail = beers.Join(brand, b => b.IdBrand, br => br.IdBrand, (beer, bran) => //hace un union
            {
                return new
                {
                    Name = beer.Name,
                    BrandName = bran.Name
                };
            });
            beersDetail.ToList().ForEach(e =>
                Console.WriteLine(e)
            );
            Console.ReadLine();
            //////////////////////////////////////////////////////////
            var cerveza = new List<(string Name, int IdBrand)>
            {
                ("Miller", 1),
                ("Cristal", 1),
                ("Corona", 2),
                ("Heineken", 2)
            };
            var fabricante = new List<(int IdBrand, string Name)>
            {
                (1, "Erdinger"),
                (2, "Fuller")
            };
            var cervezaDetalle = (from c in cerveza
                                  join f in fabricante on c.IdBrand equals f.IdBrand //un union como el anterior pero mas simple
                                  select new
                                  {
                                      Name = c.Name,
                                      BrandName = f.Name
                                  });
            cervezaDetalle.ToList().ForEach(e =>
                Console.WriteLine(e)
            );
            Console.ReadLine();
            ///////////////////////////////////////////////////////
            var numero6 = new int[] { 1, 2, 3, 4, 5, 6 };
            var numero7 = new int[] { 6, 7, 8, 9, 10 };
            Console.WriteLine(numero6.All(e => e > 5));//evalua segun condicion todos los elementos y devuelve true o false
            Console.WriteLine(numero7.All(e => e > 5));
            Console.ReadLine();
            ///////////////////////////////////////////////////////
            var beerBrands1 = new List<(string Name, List<string> Beers)>
            {
                ("Erdinger", new List<string>{ "Picantus", "Dinger"}),
                ("Deliriumn", new List<string>{ "Cristal", "Bucanero"})
            };

            var beerDetail2 =
                beerBrands1.SelectMany(beersBrand => beersBrand.Beers,
                    (beerBrand, beer) => new { beerBrand, beer }
                ).Select(beerBrand =>
                    new
                    {
                        BrandName = beerBrand.beerBrand.Name,
                        BeerName = beerBrand.beer
                    }
                );

            beerDetail2.ToList().ForEach(e =>
                Console.WriteLine($"{e.BrandName} {e.BeerName}")
            );
            Console.ReadLine();
        }
    }
}
