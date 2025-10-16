// Evan Barrett
// Wk05 Eternal Quest Program

// Creativity and Exceeding Requirements -
// To exceed requirements, I have implemented the following:
// 1. A save/load feature that correctly saves and reconstructs the different goal types.
//    The format can be extended for new goal types in the future.
// 2. The program displays a congratulatory message each time an event is recorded,
//    improving the "gamification".
// 3. The user interface is clear and provides continuous feedback, such as showing the updated
//    point total immediately after an action.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}