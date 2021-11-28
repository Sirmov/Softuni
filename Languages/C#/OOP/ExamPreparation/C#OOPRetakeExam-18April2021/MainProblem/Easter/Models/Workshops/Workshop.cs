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
            IDye[] dyes = new IDye[bunny.Dyes.Count];
            bunny.Dyes.CopyTo(dyes, 0);
            dyes = dyes.Where(d => !d.IsFinished()).ToArray();
            int count = 0;

            if (bunny.Energy > 0 && dyes.Length > 0)
            {
                var dye = dyes[count];

                while (!egg.IsDone() && bunny.Energy > 0)
                {
                    bunny.Work();
                    dye.Use();
                    egg.GetColored();

                    if (dye.IsFinished() && dyes.Any(d => !d.IsFinished()))
                    {
                        dye = dyes[++count];
                    }
                    else if (dye.IsFinished() && !dyes.Any(d => !d.IsFinished()))
                    {
                        break;
                    }
                }
            }
        }
    }
}