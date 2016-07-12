using System;
using System.Collections.Generic;
using SocialNetwork.Model.Command.Exceptions;

namespace SocialNetwork.Model.Command.Input
{
    public class InputParser : IInputParser
    {
        public CommandInput Parse(string input)
        {
            var arguments = new List<string>();
            InputType? type = null;

            if (input.Equals("exit"))
                type = InputType.Exit;
            else
            {
                var split = input.Split(' ');
                if (split.Length == 1)
                {
                    type = InputType.DisplayTimeline;
                    arguments.Add(input);
                }
                else if (split.Length == 2 && split[1].Equals("wall"))
                {
                    type = InputType.DisplayWall;
                    arguments.Add(split[0]);
                }
                else if (split.Length == 3 && split[1].Equals("follows"))
                {
                    type = InputType.Follow;
                    arguments.Add(split[0]);
                    arguments.Add(split[2]);
                }
                else if (split[1].Equals("->"))
                {
                    type = InputType.Post;    
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