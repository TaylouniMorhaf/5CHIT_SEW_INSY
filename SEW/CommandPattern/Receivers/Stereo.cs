using System;

namespace CommandPattern.Receivers;

// Another Receiver class
public class Stereo
{
    private string _location;
    private int _volume;

    public Stereo(string location)
    {
        _location = location;
    }

    public void On()
    {
        Console.WriteLine($"[{_location}] Stereo is ON");
    }

    public void Off()
    {
        Console.WriteLine($"[{_location}] Stereo is OFF");
    }

    public void SetCD()
    {
        Console.WriteLine($"[{_location}] Stereo is set for CD input");
    }

    public void SetVolume(int volume)
    {
        _volume = volume;
        Console.WriteLine($"[{_location}] Stereo volume set to {_volume}");
    }

    public int GetVolume()
    {
        return _volume;
    }
}
