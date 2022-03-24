// /**
//  * Universidad de La Laguna
//  * Grado en Ingeniería Informática
//  * Diseño y Análisis de Algoritmos
//  * @author Daniel Hernandez de Leon
//  * @class HanoiTower
//  * @brief Clase para algoritmos de HanoiTower
//  */

// using System;
// using DivideConquer.Types;

// namespace DivideConquer.Algorithms {
//   class HanoiTower<TW, T> : Template<TW, int>
//       where TW : Tower<T>
//       where T : IComparable {
//     /// <summary>
//     /// Constructor of HanoiTower.
//     /// </summary>
//     public HanoiTower() {
//       this._subproblems = "2";
//       this._sizeSubproblems = "2";
//       this._additionalComplexity = "n";
//     }

//     /// <summary>
//     /// Determines if a problem is solvable.
//     /// </summary>
//     /// <param name="problem">The problem to solve.</param>
//     /// <returns>True if the problem is solvable, false otherwise.</returns>
//     public override bool Small(TW tower) {
//       return tower.Disks < 2;
//     }

//     /// <summary>
//     /// Solves a problem.
//     /// </summary>
//     /// <param name="problem">The problem to solve.</param>
//     /// <returns>The solution to the problem.</returns>
//     public override int SolveSmall(TW tower) {

//     }

//     /// <summary>
//     /// Divide the problem into n subproblems of size m.
//     /// </summary>
//     /// <param name="problem">The problem to divide.</param>
//     /// <returns>The subproblems.</returns>
//     public override TW[] Divide(TW tower);

//     /// <summary>
//     /// Combine the solutions.
//     /// </summary>
//     /// <param name="solutions">The solutions to combine.</param>
//     /// <returns>The combined solution.</returns>
//     public override int Combine(int[] solutions);
//   }
// }
