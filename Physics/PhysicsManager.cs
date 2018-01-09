using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class PhysicsManager
    {
        private static bool isTriggerComplete;

        public static bool Intersect(BoxCollider a, BoxCollider b)
        {
            if (a != null && b != null)
            {
                if (
                    a.Position.X - a.Width * 0.5f < b.Position.X + b.Width * 0.5f &&
                    a.Position.X + a.Width * 0.5f > b.Position.X - b.Width * 0.5f &&
                    a.Position.Y - a.Height * 0.5f < b.Position.Y + b.Height * 0.5f &&
                    a.Position.Y + a.Height * 0.5f > b.Position.Y - b.Height * 0.5f
                    )
                {
                    return true;
                }
            }
            return false;

        }

        public static HitState OnAABB(BoxCollider a, BoxCollider b)
        {
            HitState hitState = new HitState();

            //Faccio delle valutazioni sull'asse x
            float dx = b.Center.X - a.Center.X;
            //Calcolo della distanza tra le pareti lungo l'asse x
            float px = (b.Half.X + a.Half.X) - Math.Abs(dx);    //differenza tra la somma dei raggi e il valore assoluto di dx
                                                                //Valuto se è avvenuta la collisione tra pareti lungo asse x
            if (px <= 0f)
            {
                //non ho colliso
                return hitState;
            }

            //Faccio delle valutazioni sull'asse y
            float dy = b.Center.Y - a.Center.Y;
            //Calcolo della distanza tra le pareti lungo l'asse y
            float py = (b.Half.Y + a.Half.Y) - Math.Abs(dy);
            //Valuto se è avvenuta la collisione tra pareti lungo asse y
            if (py <= 0f)
            {
                //non ho colliso
                return hitState;
            }

            // se sono verificate entrambe le condizioni di cui sopra, allora siamo certi che è avvenuta una collisione, perciò...
            hitState.hit = true;

            if (px < py)
            {
                //la normale è posta lungo l'asse x
                int sx = Math.Sign(dx);
                hitState.normal = new Vector2(-sx, 0f);
            }
            else
            {
                //la normale è posta lungo l'asse y
                int sy = Math.Sign(dy);
                hitState.normal = new Vector2(0f, -sy);
            }

            return hitState;
        }
    }

    public struct HitState
    {
        public bool hit;
        public Vector2 normal;
    }
}
