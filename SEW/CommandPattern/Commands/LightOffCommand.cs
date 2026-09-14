using CommandPattern.Interfaces;
using CommandPattern.Receivers;

namespace CommandPattern.Commands;

public class LightOffCommand : ICommand
{
    private Light _light;
    private int _previousBrightness;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _previousBrightness = _light.GetBrightness();
        _light.Off();
    }

    public void Undo()
    {
        _light.Dim(_previousBrightness);
    }
}
