namespace CommandPattern.Interfaces;

public interface ICommand
{
    void Execute();
    void Undo(); // The 'little bit more' to show power of Command Pattern
}
