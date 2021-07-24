using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoEFBlazorWasm.Server.Services;
using TodoEFBlazorWasm.Shared.Models;

namespace TodoEFBlazorWasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly AppDbContext context;

        public TodosController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetAllTodos")]
        public IEnumerable<Todo> GetAllTodos()
        {
            return context.Todos;
        }

        [HttpPost]
        [Route("AddTodo")]
        public async Task AddTodo(Todo newTodo)
        {
            newTodo.CreatedDate = DateTime.Now;
            newTodo.UpdatedDate = DateTime.Now;
            await this.context.Todos.AddAsync(newTodo);
            await this.context.SaveChangesAsync();
        }

        [HttpDelete]
        [Route("DeleteTodo/{Id}")]
        public async Task DeleteTodo(int Id)
        {
            var todoToDel = await this.context.Todos.FindAsync(Id);
            this.context.Todos.Remove(todoToDel);
            await this.context.SaveChangesAsync();
        }

        [HttpGet]
        [Route("GetAllTodos/{id}")]
        public async Task<Todo> GetAllTodos(int id)
        {
            return await context.Todos.FindAsync(id);
        }

        [HttpPut]
        [Route("UpdateTodo")]
        public async Task UpdateTodo(Todo todoToUpdt)
        {
            todoToUpdt.UpdatedDate = DateTime.Now;
            this.context.Todos.Update(todoToUpdt);
            await this.context.SaveChangesAsync();
        }
    }
}
