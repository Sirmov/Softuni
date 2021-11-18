using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    internal class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command = Console.ReadLine();


            while (true)
            {
                Console.WriteLine(this.commandInterpreter.Read(command));

                command = Console.ReadLine();
            }
        }
    }
}
