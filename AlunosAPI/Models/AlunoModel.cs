using AlunosAPI.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AlunosAPI.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        #region CRUD

        //Create
        public void RegisterStudent()
        {
            DAL dalObj = new DAL();
            var commandQuery = $"insert into persons ( firstname, lastname, address, gender)" +
                $"values ('{FirstName}','{LastName}','{Address}','{Gender}')";
            dalObj.ExecuteCommand(commandQuery);
        }

        //Read
        public List<AlunoModel> GetStudents()
        {
            List<AlunoModel> listaAlunos = new List<AlunoModel>();
            AlunoModel aluno;

            DAL dalObj = new DAL();

            var sqlCommand = "Select * from persons order by lastname";
            DataTable dados = dalObj.GetTable(sqlCommand);

            for (int i = 0; i < dados.Rows.Count; i++)
            {
                aluno = new AlunoModel
                {
                    Id = int.Parse(dados.Rows[i]["Id"].ToString()),
                    FirstName = dados.Rows[i]["firstname"].ToString(),
                    LastName = dados.Rows[i]["lastname"].ToString(),
                    Address = dados.Rows[i]["address"].ToString(),
                    Gender = dados.Rows[i]["gender"].ToString(),
                };

                listaAlunos.Add(aluno);
            }

            return listaAlunos;
        }

        //Retorna 1 item
        public AlunoModel RetornaAluno(string id)
        {
            AlunoModel aluno;
            DAL dalObj = new DAL();

            var sqlCommand = $"Select * from persons where id = {id}";
            DataTable dados = dalObj.GetTable(sqlCommand);
            aluno = new AlunoModel
            {
                Id = int.Parse(dados.Rows[0]["Id"].ToString()),
                FirstName = dados.Rows[0]["firstname"].ToString(),
                LastName = dados.Rows[0]["lastname"].ToString(),
                Address = dados.Rows[0]["address"].ToString(),
                Gender = dados.Rows[0]["gender"].ToString(),
            };


            return aluno;
        }

        //Update
        public void UpdateStudent(int id)
        {
            DAL dalObj = new DAL();
            var commandQuery = $"update persons set firstname ='{FirstName}', lastname ='{LastName}', address ='{Address}', gender ='{Gender}' where id={id}";
            dalObj.ExecuteCommand(commandQuery);
        }
        //Delete
        public void DeleteStudent(int id)
        {
            DAL dalObj = new DAL();
            var commandQuery = $"delete from persons where id = {id}";
            dalObj.ExecuteCommand(commandQuery);
        }

        #endregion
    }
}
