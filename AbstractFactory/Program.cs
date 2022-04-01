using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Toy> toys = new List<Toy>();
            CatFactory cf = new CatFactory();
            DollFactory df = new DollFactory();
            toys.Add(new Toy(cf, "kitty"));
            toys.Add(new Toy(df, "kelly"));
            toys.Add(new Toy(cf, "tom"));
            toys.Add(new Toy(df, "poly"));
            toys.Add(new Toy(cf, "murzik"));
            toys.Add(new Toy(df, "anni"));
            foreach (Toy t in toys)
            {
                t.Introduce();
                t.MakeVoice();
                t.Wrap();
                Console.WriteLine("-------------");
            }
        }
    }

    public class Toy
    {
        public string Name { get; set; }
        private AbstractCloth cloth;
        private AbstractVoice voice;

        public Toy(ToyFactory f, string n)
        {
            this.Name = n;
            cloth = f.CreateCloth();
            voice = f.CreateVoice();
        }

        public void Wrap()
        {
            cloth.GetCloth();
        }

        public void MakeVoice()
        {
            voice.GetVoice();
        }

        public void Introduce()
        {
            Console.WriteLine(this.Name);
        }
    }

    public abstract class AbstractVoice
    {
        public abstract void GetVoice();
    }
    public abstract class AbstractCloth
    {
        public abstract void GetCloth();
    }

    public class DollVoice : AbstractVoice
    {
        public override void GetVoice()
        {
            Console.WriteLine("Mammy!");
        }
    }

    public class CatVoice : AbstractVoice
    {
        public override void GetVoice()
        {
            Console.WriteLine("Meow!");
        }
    }

    public class DollCloth : AbstractCloth
    {
        public override void GetCloth()
        {
            Console.WriteLine("Dress");
        }
    }

    public class CatCloth : AbstractCloth
    {
        public override void GetCloth()
        {
            Console.WriteLine("Fur");
        }
    }

    public abstract class ToyFactory
    {
        public abstract AbstractVoice CreateVoice();
        public abstract AbstractCloth CreateCloth();
    }

    public class DollFactory : ToyFactory
    {
        public override AbstractVoice CreateVoice()
        {
            return new DollVoice();
        }

        public override AbstractCloth CreateCloth()
        {
            return new DollCloth();
        }
    }
    public class CatFactory : ToyFactory
    {
        public override AbstractVoice CreateVoice()
        {
            return new CatVoice();
        }

        public override AbstractCloth CreateCloth()
        {
            return new CatCloth();
        }
    }
}
