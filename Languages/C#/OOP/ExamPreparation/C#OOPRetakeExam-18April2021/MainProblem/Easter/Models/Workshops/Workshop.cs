using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            IDye[] copy = new IDye[bunny.Dyes.Count];
            bunny.Dyes.CopyTo(copy, 0);
            Stack<IDye> dyes = new Stack<IDye>(copy.Where(d => !d.IsFinished()));

            if (bunny.Energy > 0 && dyes.Count > 0)
            {
                var dye = dyes.Pop();

                while (!egg.IsDone() && bunny.Energy > 0)
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (dye.IsFinished() && dyes.Count > 0)
                    {
                        dye = dyes.Pop();
                    }
                    else if (dye.IsFinished() && dyes.Count == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}