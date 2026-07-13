namespace DesignPatterns.Factory;

public class FactoryMethod
{
    public void Run()
    {
        // Road delivery
        Logistics logistics = new RoadLogistics();
        logistics.PlanDelivery();
        // Planning delivery...
        // Delivering by road in a Truck.

        // Switch to sea — zero changes to Logistics base class
        logistics = new SeaLogistics();
        logistics.PlanDelivery();
        // Planning delivery...
        // Delivering by sea in a Ship.

         // Switch to air — zero changes to Logistics base class
        logistics = new AirLogistics();
        logistics.PlanDelivery();
        // Planning delivery...
        // Delivering by air in a Plane.

    }
}