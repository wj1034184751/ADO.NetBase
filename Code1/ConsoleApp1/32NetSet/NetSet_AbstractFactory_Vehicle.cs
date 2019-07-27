using System;
using System.Collections.Generic;
using System.Text;

namespace _32NetSet
{
    public class NetSet_AbstractFactory_Vehicle
    {

    }

    public abstract class VehicleSystemFactory
    {
        public abstract Vehicle GetVehicle();

        public abstract VehicleStation GetVehicleStation();
    }

    public class BusSystemFactory : VehicleSystemFactory
    {
        public override Vehicle GetVehicle()
        {
            return new Bus();
        }

        public override VehicleStation GetVehicleStation()
        {
            return new BusStation();
        }
    }

    public class Vehicle
    { }

    public class VehicleStation
    { }

    public class Bus : Vehicle
    { }

    public class BusStation : VehicleStation
    { }

}
