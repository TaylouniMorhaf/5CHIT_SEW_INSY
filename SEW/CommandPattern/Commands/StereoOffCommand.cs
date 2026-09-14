using CommandPattern.Interfaces;
using CommandPattern.Receivers;

namespace CommandPattern.Commands;

public class StereoOffCommand : ICommand
{
    private Stereo _stereo;
    private int _previousVolume;

    public StereoOffCommand(Stereo stereo)
    {
        _stereo = stereo;
    }

    public void Execute()
    {
        _previousVolume = _stereo.GetVolume();
        _stereo.Off();
    }

    public void Undo()
    {
        _stereo.On();
        _stereo.SetVolume(_previousVolume);
    }
}
