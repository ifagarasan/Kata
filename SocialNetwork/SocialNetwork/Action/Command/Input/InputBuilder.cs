using System;
using System.Collections.Generic;
using SocialNetwork.Exceptions;

namespace SocialNetwork.Action.Command.Input
{
    public class InputBuilder : IInputBuilder
    {
        public CommandInput Build(string input)
        {
            var arguments = new List<string>();
            CommandType? type = null;

            if (input.Equals("exit"))
                type = CommandType.Exit;
            else
            {
                var split = input.Split(' ');
                if (split.Length == 1)
                {
                    type = CommandType.DisplayTimeline;
                    arguments.Add(input);
                }
                else if (split.Length == 2 && split[1].Equals("wall"))
                {
                    type = CommandType.DisplayWall;
                    arguments.Add(split[0]);
                }
                else if (split.Length == 3 && split[1].Equals("follows"))
                {
                    type = CommandType.Follow;
                    arguments.Add(split[0]);
                    arguments.Add(split[2]);
                }
                else if (split[1].Equals("->"))
                {
                    type = CommandType.Post;    
                    arguments.Add(split[0]);
                    arguments.Add(input.Substring(input.IndexOf("->", StringComparison.InvariantCulture) + 3));
                }
            }

            if (!type.HasValue)
                throw new CommandTypeNotDefinedException($"Command '{input}' is not supported");

            return new CommandInput(type.Value, arguments.ToArray());
        }
    }
}