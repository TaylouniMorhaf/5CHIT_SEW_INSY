using CommandPattern.Interfaces;
using CommandPattern.Receivers;

namespace CommandPattern.Commands;

public class LightOnCommand : ICommand
{
    private Light _light;
    private int _previousBrightness;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        // Store state before modifying, so we can undo properly
        _previousBrightness = _light.GetBrightness();
        _light.On();
    }

    public void Undo()
    {
        _light.Dim(_previousBrightness);
    }
}
