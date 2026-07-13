namespace DesignPatterns.Command.LightAndFanExample;

// Client
public static class LightAndFanClient
{
    public static void Run()
    {
        var remote = new RemoteControl();

        // Create receivers
        var livingRoomLight = new Light("Living Room");
        var kitchenLight = new Light("Kitchen");
        var ceilingFan = new CeilingFan("Living Room");

        // Create commands
        var livingRoomLightOn = new LightOnCommand(livingRoomLight);
        var livingRoomLightOff = new LightOffCommand(livingRoomLight);
        var kitchenLightOn = new LightOnCommand(kitchenLight);
        var kitchenLightOff = new LightOffCommand(kitchenLight);
        var ceilingFanHigh = new CeilingFanHighCommand(ceilingFan);
        var ceilingFanOff = new CeilingFanOffCommand(ceilingFan);

        // Load commands into slots
        remote.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
        remote.SetCommand(1, kitchenLightOn, kitchenLightOff);
        remote.SetCommand(2, ceilingFanHigh, ceilingFanOff);

        // Press buttons
        remote.OnButtonPressed(0);
        remote.OnButtonPressed(1);
        remote.OnButtonPressed(2);

        remote.OffButtonPressed(0);
        remote.UndoButtonPressed();

        remote.OffButtonPressed(2);
        remote.UndoButtonPressed();
    }
}
