using AlunosAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosAPI.Models
{
    public class AlunoModel
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public void RegisterStudent()
        {
            DAL dalObj = new DAL();
            var commandQuery = $"insert into persons (firstname, lastname, address, gender)"+
                "Values ({FirstName},{LastName},{Address},{Gender})";
            dalObj.ExecuteCommand(commandQuery);
        }
    }
}
