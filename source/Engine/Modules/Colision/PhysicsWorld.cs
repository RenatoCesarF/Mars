using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Mars.Collider
{
    public class PhysicsWorld
    {

        private List<Object> m_objects;
        private List<Solver> m_solvers;
        private Vector2 m_gravity = new Vector2(0.0f,0.9f);

        public void addObject(Object Object) {
            this.m_objects.Add(Object);
        }
        public void removeObject(Object Object) {
            this.m_objects.Remove(Object);
        }

        public void AddSolver(Solver solver){
            this.m_solvers.Add(solver);
        }

        public void removeSolver(Solver solver){
            this.m_solvers.Remove(solver);

        }

        public void Update(GameTime dt){

            ResolveCollisions();

            foreach (Object obj in m_objects)
            {
                obj.force += obj.mass * m_gravity;

                obj.velocity +=obj.mass * m_gravity;
                obj.position += obj.velocity; 
            }
        }

        private void ResolveCollisions(){
            List<Collision> colissions = new List<Collision>();

            foreach (Object a in m_objects)
            {
                foreach (Object b in m_objects)
                {
                    if(a == b) break;

                    if(a.collider == null || b.collider == null){
                        continue;
                    }

                    CollisionPoints points = a.collider.TestCollision(
                        a.transform,
                        b.collider,
                        b.transform
                    );

                    if(points.HasCollision){
                        colissions.Add(new Collision(a,b,points));
                    }
                    
                }
            }
        
            foreach (Solver solver in m_solvers)
            {
                solver.Solve(colissions);
                
            }
        }
    }

}
