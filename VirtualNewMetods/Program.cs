using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualNewMetods
{
    class Program
    {
        class Animal
        {
            public virtual void Introduce()
            {
                Console.WriteLine("I am an animal");
            }
        }

        class Cabra : Animal
        {
            public override void Introduce()
            {
                Console.WriteLine("I am a cabra");
            }
        }


        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Introduce();

            Cabra caba = new Cabra();
            caba.Introduce();


            Console.WriteLine("-----------------");

            animal = caba;
            animal.Introduce();


            Console.ReadKey();
        }
    
    }
}
