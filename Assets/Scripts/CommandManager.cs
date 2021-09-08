using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public static CommandManager Instance {get; private set;}

    public static Stack<ICommand> commands = new Stack<ICommand>();

    void Awake()
    {
        Instance = this;
    }

    public void AddCommand(ICommand command)
    {
        commands.Push(command);
    }

    public void Undo()
    {
        if (commands.Count == 0)
        {
            return;
        }

        ICommand command = commands.Pop();
        command.Undo();
    }
}
