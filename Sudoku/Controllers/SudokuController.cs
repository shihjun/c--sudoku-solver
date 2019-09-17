using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sudoku.Models;


namespace Sudoku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public Board Post(Board value)
        {
            Board data = value;
            Board result = new Board { board = Sudoku.Solve(data.board) };
            return result;
        }
    }
}
