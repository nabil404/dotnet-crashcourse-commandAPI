//Interface naming convention => Capital I before the name of the interface 

//This is the interface that defines which methods must be available in the corresponding repo

using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandId(int id);
        void CreateCommnad(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}