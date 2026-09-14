using CommandPattern.Interfaces;
using CommandPattern.Commands;
using System;
using System.Text;

namespace CommandPattern.Invoker;

// The Invoker class - holds commands and triggers them, but doesn't know what they actually do.
public class RemoteControl
{
    private ICommand[] _onCommands;
    private ICommand[] _offCommands;
    private ICommand _undoCommand;

    public RemoteControl(int slots)
    {
        _onCommands = new ICommand[slots];
        _offCommands = new ICommand[slots];

        ICommand noCommand = new NoCommand();
        for (int i = 0; i < slots; i++)
        {
            _onCommands[i] = noCommand;
            _offCommands[i] = noCommand;
        }
        _undoCommand = noCommand; // initially nothing to undo
    }

    public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
    {
        _onCommands[slot] = onCommand;
        _offCommands[slot] = offCommand;
    }

    public void OnButtonWasPushed(int slot)
    {
        if (slot >= 0 && slot < _onCommands.Length)
        {
            _onCommands[slot].Execute();
            _undoCommand = _onCommands[slot]; // save for undo
        }
    }

    public void OffButtonWasPushed(int slot)
    {
        if (slot >= 0 && slot < _offCommands.Length)
        {
            _offCommands[slot].Execute();
            _undoCommand = _offCommands[slot]; // save for undo
        }
    }

    public void UndoButtonWasPushed()
    {
        Console.WriteLine("--- UNDO Pressed ---");
        _undoCommand.Undo();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("\n------ Remote Control ------");
        for (int i = 0; i < _onCommands.Length; i++)
        {
            sb.AppendLine($"[slot {i}] {_onCommands[i].GetType().Name,-25} {_offCommands[i].GetType().Name}");
        }
        sb.AppendLine($"[undo] {_undoCommand.GetType().Name}");
        return sb.ToString();
    }
}
