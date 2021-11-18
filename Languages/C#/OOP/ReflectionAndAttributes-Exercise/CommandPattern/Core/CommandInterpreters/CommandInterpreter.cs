using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core.CommandInterpreters
{
    internal class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = tokens[0];
            string[] commandArgs = tokens.Skip(1).ToArray();

            string commandFullName = $"CommandPattern.Core.{commandName}Command";
            Type commandType = Type.GetType(commandFullName);
            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            return command.Execute(commandArgs);
        }
    }
}
