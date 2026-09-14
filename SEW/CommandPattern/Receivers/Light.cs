using System;

namespace CommandPattern.Receivers;

// The Receiver class - knows how to perform the actual operations.
public class Light
{
    private string _location;
    private int _brightness;

    public Light(string location)
    {
        _location = location;
    }

    public void On()
    {
        _brightness = 100;
        Console.WriteLine($"[{_location}] Light is ON (Brightness: {_brightness}%)");
    }

    public void Off()
    {
        _brightness = 0;
        Console.WriteLine($"[{_location}] Light is OFF");
    }

    public void Dim(int level)
    {
        _brightness = level;
        if (_brightness == 0)
        {
            Console.WriteLine($"[{_location}] Light is OFF (0%)");
        }
        else
        {
            Console.WriteLine($"[{_location}] Light is dimmed to {_brightness}%");
        }
    }

    public int GetBrightness()
    {
        return _brightness;
    }
}
