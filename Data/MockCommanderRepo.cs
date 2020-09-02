using System.Collections.Generic;
using Commander.Models;

//Shortcut => Ctrl+. for bringing methods defined in the interface
namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommnad(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>{
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Pan" },
                new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform = "chopping board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place teabag in cup", Platform = "cup" }
            };

            return commands;

        }

        public Command GetCommandId(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}