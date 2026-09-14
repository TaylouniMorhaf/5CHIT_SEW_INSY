using System;
using CommandPattern.Commands;
using CommandPattern.Invoker;
using CommandPattern.Receivers;

namespace CommandPattern;

class Program
{
    static void Main(string[] args)
    {
        // 1. Setup Phase: Configure the remote with our devices and commands
        RemoteControl remoteControl = new RemoteControl(4);

        Light livingRoomLight = new Light("Living Room");
        Light kitchenLight = new Light("Kitchen");
        Stereo stereo = new Stereo("Living Room");

        LightOnCommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
        LightOffCommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

        LightOnCommand kitchenLightOn = new LightOnCommand(kitchenLight);
        LightOffCommand kitchenLightOff = new LightOffCommand(kitchenLight);

        LightDimCommand livingRoomLightDim = new LightDimCommand(livingRoomLight, 50);

        StereoOnWithCDCommand stereoOnWithCD = new StereoOnWithCDCommand(stereo);
        StereoOffCommand stereoOff = new StereoOffCommand(stereo);

        // Load commands into the remote slots
        remoteControl.SetCommand(0, livingRoomLightOn, livingRoomLightOff);
        remoteControl.SetCommand(1, kitchenLightOn, kitchenLightOff);
        remoteControl.SetCommand(2, stereoOnWithCD, stereoOff);
        remoteControl.SetCommand(3, livingRoomLightDim, livingRoomLightOff);

        // 2. Interactive User Experience Phase
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("            SMART HOME REMOTE CONTROL             ");
            Console.WriteLine("==================================================");
            
            // Display the remote layout
            Console.WriteLine(remoteControl.ToString());
            
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("How to use the remote:");
            Console.WriteLine("  Type 'on <slot>'  -> (e.g., 'on 0' to push ON for slot 0)");
            Console.WriteLine("  Type 'off <slot>' -> (e.g., 'off 2' to push OFF for slot 2)");
            Console.WriteLine("  Type 'undo'       -> to undo the last button press");
            Console.WriteLine("  Type 'exit'       -> to put the remote away");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("\nWhat would you like to press? ");
            
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input)) continue;

            Console.WriteLine("\n--- Action Output ---");

            if (input == "exit" || input == "quit")
            {
                exit = true;
                continue;
            }
            else if (input == "undo")
            {
                remoteControl.UndoButtonWasPushed();
            }
            else if (input.StartsWith("on "))
            {
                if (int.TryParse(input.Substring(3), out int slot))
                {
                    remoteControl.OnButtonWasPushed(slot);
                }
                else
                {
                    Console.WriteLine("Invalid slot number format.");
                }
            }
            else if (input.StartsWith("off "))
            {
                if (int.TryParse(input.Substring(4), out int slot))
                {
                    remoteControl.OffButtonWasPushed(slot);
                }
                else
                {
                    Console.WriteLine("Invalid slot number format.");
                }
            }
            else
            {
                Console.WriteLine("Unknown command. Please try again.");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
