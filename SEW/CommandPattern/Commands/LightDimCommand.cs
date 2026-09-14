using CommandPattern.Interfaces;
using CommandPattern.Receivers;

namespace CommandPattern.Commands;

public class LightDimCommand : ICommand
{
    private Light _light;
    private int _newBrightness;
    private int _previousBrightness;

    public LightDimCommand(Light light, int newBrightness)
    {
        _light = light;
        _newBrightness = newBrightness;
    }

    public void Execute()
    {
        _previousBrightness = _light.GetBrightness();
        _light.Dim(_newBrightness);
    }

    public void Undo()
    {
        _light.Dim(_previousBrightness);
    }
}
