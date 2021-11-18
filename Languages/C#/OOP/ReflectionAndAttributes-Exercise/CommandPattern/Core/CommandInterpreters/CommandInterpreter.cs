using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.CommandInterpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string commandName = $"{tokens[0]}Command";
            string[] commandArgs = tokens.Skip(1).ToArray();

            Type commandType = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == commandName).FirstOrDefault();
            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            return command.Execute(commandArgs);
        }
    }
}
