using CommandPattern.Interfaces;

namespace CommandPattern.Commands;

// Null Object Pattern - avoids doing null checks in the Invoker
public class NoCommand : ICommand
{
    public void Execute() { }
    public void Undo() { }
}
