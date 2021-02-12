using Calculator.Controllers;
using Presenter.Controllers;
using Rolls.Controllers;
using System;

namespace ConsoleProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorController calculatorService = new CalculatorController();
            PresenterController presenterService = new PresenterController();
            RollsController rollsService = new RollsController();

            int[] rolls = new int[21];
            for (int i = 0; i < 21; i++)
            {
                rolls[i] = 0;
            }
            rollsService.Post(rolls);
            int[] scores = calculatorService.Scores;
            Console.WriteLine("Score: " + scores[9]);
        }
    }
}
