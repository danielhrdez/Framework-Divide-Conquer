/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="HanoiTower"> Clase para algoritmos de HanoiTower </class>

using DivideConquer.Types;

namespace DivideConquer.Algorithms {
  class HanoiTower : Template<Tower, Step[]> {
    /// <summary>
    /// Constructor of HanoiTower.
    /// </summary>
    public HanoiTower() {
      this._subproblems = "2";
      this._sizeSubproblems = "n - 1";
      this._additionalComplexity = "1";
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(Tower tower) {
      return tower.Disks < 2;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override Step[] SolveSmall(Tower tower) {
      return new Step[1] {
        new Step(tower.Source, tower.Destination)
      };
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Tower[] Divide(Tower tower) {
      Tower[] subproblems = new Tower[3];
      subproblems[0] = new Tower(tower.Disks - 1, tower.Source, tower.Destination, tower.Auxiliary);
      subproblems[1] = new Tower(1, tower.Source, tower.Auxiliary, tower.Destination);
      subproblems[2] = new Tower(tower.Disks - 1, tower.Auxiliary, tower.Source, tower.Destination);
      return subproblems;
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override Step[] Combine(Step[][] solutions) {
      Step[] steps = new Step[solutions[0].Length + solutions[1].Length + solutions[2].Length];
      int index = 0;
      foreach (Step[] solution in solutions) {
        foreach (Step step in solution) {
          steps[index] = step;
          index++;
        }
      }
      return steps;
    }
  }
}
