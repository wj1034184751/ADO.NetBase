using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _32NetSet
{
    public class NetSet_FactoryMehod
    {
        public static void Printf()
        {
            CarFactory factory = new HongQiCarFactory();
            Car car = factory.CarCreate();
            car.StartUp();
            car.Run();
            car.Stop();
        }
    }

    public abstract class CarFactory
    {
        public abstract Car CarCreate();
    }

    public abstract class Car
    {
        public abstract void StartUp();
        public abstract void Run();
        public abstract void Stop();
    }

    public class HongQiCarFactory:CarFactory
    {
        public override Car CarCreate()
        {
            return new HongQiCar();
        }
    }

    public class BMWCarFactory:CarFactory
    {
        public override Car CarCreate()
        {
            return new HongQiCar();
        }
    }

    public class HongQiCar : Car
    {
        public override void Run()
        {
            Console.WriteLine("The HongQiCar run is very quiclkly!");
        }

        public override void StartUp()
        {
            Console.WriteLine("Test HongQiCar start-up speed!");
        }

        public override void Stop()
        {
            Console.WriteLine("The slow stop time is 3 second");
        }
    }

    public class BMWQiCar : Car
    {
        public override void Run()
        {
            Console.WriteLine("The BMWQiCar run is very quiclkly!");
        }

        public override void StartUp()
        {
            Console.WriteLine("Test BMWQiCar start-up speed!");
        }

        public override void Stop()
        {
            Console.WriteLine("The slow stop time is 2 second");
        }
    }

}

