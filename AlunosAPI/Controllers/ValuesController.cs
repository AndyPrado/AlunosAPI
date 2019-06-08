using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlunosAPI.Models;
using AlunosAPI.Util;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("listagem")]
        public List<AlunoModel> Listagem()
        {
            var studentsList = new AlunoModel().GetStudents();
            return studentsList;
        }

        // GET api/values/5
        [HttpGet]
        [Route("listagem/aluno/{id}")]
        public AlunoModel RetornaAluno(int id)
        {
            var aluno = new AlunoModel().RetornaAluno(id.ToString());
            return aluno;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] AlunoModel aluno)
        {
            aluno.RegisterStudent();
        }

        // PUT api/values/5
        [HttpPut]
        [Route("atualizar/{id}")]
        public void UpdateStudent(int id, [FromBody] AlunoModel aluno)
        {
            aluno.UpdateStudent(id);
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("apagar/{id}")]
        public void DeleteStudent(int id)
        {
            new AlunoModel().DeleteStudent(id);
        }
    }
}
