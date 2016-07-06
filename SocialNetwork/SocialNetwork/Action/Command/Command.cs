﻿using SocialNetwork.Infrastructure;

namespace SocialNetwork.Action.Command
{
    public abstract class Command : ICommand
    {
        protected Command(ISocialEngine socialEngine, IConsole console, string[] arguments)
        {
            SocialEngine = socialEngine;
            Console = console;
            Arguments = arguments;
        }

        protected IConsole Console { get; private set; }
        protected ISocialEngine SocialEngine { get; private set; }
        protected string[] Arguments { get; private set; }

        public abstract void Execute();
    }
}