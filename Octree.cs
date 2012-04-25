using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using System.Drawing;


namespace GalaxySmash
{
    public class Octree
    {
        private Sector _root = null;
        private readonly int MaxStarsPerSector;
        private readonly LinkedList<Sector> AllSectors;
        private readonly List<BlackHole> _blackHoles;
        private readonly List<StarBufferIndex> _allStars;
        private readonly List<Mesh> _blackHoleMeshes;

        public Octree(int maxStarsPerSector)
        {
            MaxStarsPerSector = maxStarsPerSector;
            AllSectors        = new LinkedList<Sector>();
            _blackHoles       = new List<BlackHole>();
            _allStars         = new List<StarBufferIndex>();
            _blackHoleMeshes  = new List<Mesh>();

            Clear();
        }

        public void FrameMoveBlackHoles()
        {
            //return;
            double pullDirectionX;
            double pullDirectionY;
            double pullDirectionZ;
            double force;
            double distance;
            double magic = 0.00000005;

            foreach (BlackHole blackHoleOuter in BlackHoles)
            {
                foreach (BlackHole blackHoleInner in BlackHoles)
                {
                    if (blackHoleOuter.ID == blackHoleInner.ID)
                        continue;

                    pullDirectionX = blackHoleInner.PosX - blackHoleOuter.PosX;
                    pullDirectionY = blackHoleInner.PosY - blackHoleOuter.PosY;
                    pullDirectionZ = blackHoleInner.PosZ - blackHoleOuter.PosZ;

                    distance = Math.Sqrt(
                        pullDirectionX * pullDirectionX +
                        pullDirectionY * pullDirectionY +
                        pullDirectionZ * pullDirectionZ);

                    force = 0.0000000000667300 * ((blackHoleInner.Mass * blackHoleOuter.Mass) / (distance * distance));

                    blackHoleOuter.VelX += (float)(force * pullDirectionX);
                    blackHoleOuter.VelY += (float)(force * pullDirectionY);
                    blackHoleOuter.VelZ += (float)(force * pullDirectionZ);
                }

                blackHoleOuter.PosX += blackHoleOuter.VelX * magic;
                blackHoleOuter.PosY += blackHoleOuter.VelY * magic;
                blackHoleOuter.PosZ += blackHoleOuter.VelZ * magic;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sector"></param>
        public void RegisterSector(Sector sector)
        {
            AllSectors.AddLast(sector);
        }


        /// <summary>
        /// Not thread safe. Be sure no threads are accessing data
        /// </summary>
        public void Clear()
        {
            foreach (Sector sector in AllSectors)
            {
                sector.Clear();
            }

            AllSectors.Clear();
            _blackHoles.Clear();
            _allStars.Clear();

            _root = new Sector(this, MaxStarsPerSector, 0);
            RegisterSector(_root);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="star"></param>
        public void AddStar(StarBufferIndex star)
        {
            Sector current = _root;

            while (current.HasSubdivided)
            {
                current = current.GetAppropriateChildSector(star);
            }

            _allStars.Add(star);

            current.AddStar(star);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="star"></param>
        public void AddBlackHole(BlackHole blackHole)
        {
            _blackHoles.Add(blackHole);
           // _blackHoleMeshes.Add(
        }

        /*
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public List<CustomVertex.PositionColored> GetStarGeometry()
       {
           var starGeometry = new List<CustomVertex.PositionColored>();

           foreach (Star star in _allStars)
           {
               starGeometry.Add(new CustomVertex.PositionColored((float)star.PosX, (float)star.PosY, (float)star.PosZ, star.Color.ToArgb()));
           }

           return starGeometry;
           
           var sectorGeometry = new List<CustomVertex.PositionColored>();
           var sectorsLeftToTraverse = new LinkedList<Sector>();

           sectorsLeftToTraverse.AddFirst(_root);

           while (sectorsLeftToTraverse.Count > 0)
           {
               Sector current = sectorsLeftToTraverse.First.Value;
               sectorsLeftToTraverse.RemoveFirst();

               if (current.HasSubdivided)
               {
                   Sector[] children = current.ChildSectors;

                   sectorsLeftToTraverse.AddLast(children[0]);
                   sectorsLeftToTraverse.AddLast(children[1]);
                   sectorsLeftToTraverse.AddLast(children[2]);
                   sectorsLeftToTraverse.AddLast(children[3]);
                   sectorsLeftToTraverse.AddLast(children[4]);
                   sectorsLeftToTraverse.AddLast(children[5]);
                   sectorsLeftToTraverse.AddLast(children[6]);
                   sectorsLeftToTraverse.AddLast(children[7]);
               }
               else
               {
                   sectorGeometry.AddRange(current.GetStarGeometry());
               }
           }

           return sectorGeometry;
             

       }
           * */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CustomVertex.PositionColored> GetVelocityVectors()
        {
            var velocityVectors = new List<CustomVertex.PositionColored>();

            foreach (StarBufferIndex star in _allStars)
            {
                velocityVectors.Add(new CustomVertex.PositionColored(
                    star.Buffer[star.Index].X,
                    star.Buffer[star.Index].Y,
                    star.Buffer[star.Index].Z, 
                    Color.Red.ToArgb()));

                velocityVectors.Add(new CustomVertex.PositionColored(
                    (float)(star.Buffer[star.Index].X + star.VelX),
                    (float)(star.Buffer[star.Index].Y + star.VelY),
                    (float)(star.Buffer[star.Index].Z + star.VelZ),
                    Color.White.ToArgb()));
            }

            return velocityVectors;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CustomVertex.PositionColored> GetSectorGeometry()
        {
            var sectorGeometry = new List<CustomVertex.PositionColored>();
            var sectorsLeftToTraverse = new LinkedList<Sector>();

            sectorsLeftToTraverse.AddFirst(_root);

            while (sectorsLeftToTraverse.Count > 0)
            {
                Sector current = sectorsLeftToTraverse.First.Value;
                sectorsLeftToTraverse.RemoveFirst();

                if (!current.HasSubdivided)
                    continue;

                Sector[] children = current.ChildSectors;

                sectorsLeftToTraverse.AddLast(children[0]);
                sectorsLeftToTraverse.AddLast(children[1]);
                sectorsLeftToTraverse.AddLast(children[2]);
                sectorsLeftToTraverse.AddLast(children[3]);
                sectorsLeftToTraverse.AddLast(children[4]);
                sectorsLeftToTraverse.AddLast(children[5]);
                sectorsLeftToTraverse.AddLast(children[6]);
                sectorsLeftToTraverse.AddLast(children[7]);

                sectorGeometry.AddRange(current.GetGeometry());
            }

            return sectorGeometry;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="calculationMode"></param>
        public void FrameMove(CalculationMode calculationMode)
        {
            switch (calculationMode)
            {
                case CalculationMode.None:
                    FrameMoveNone();
                    break;

                case CalculationMode.SimpleApproximated:
                    FrameMoveSimpleApproximated();
                    break;

                case CalculationMode.SectorApproximated:
                    FrameMoveSectorApproximated();
                    break;

                case CalculationMode.Scientific:
                    FrameMoveScientific();
                    break;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void FrameMoveNone()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        private void FrameMoveSectorApproximated()
        {
        }


        /// <summary>
        /// 
        /// </summary>
        private void FrameMoveScientific()
        {
        }

        public BlackHole[] BlackHoles
        {
            get
            {
                return _blackHoles.ToArray();
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        private void FrameMoveSimpleApproximated()
        {
            double pullDirectionX;
            double pullDirectionY;
            double pullDirectionZ;
            double force;
            double distance;

            /*
            for (int a = 0; a < _blackHoles.Count; a++)
            {
                Star blackHole = new Star();

                for (int b =0; b < _blackHoles.Count; b++)
                {
                    if (a == b)
                        continue;

                    blackHole = _blackHoles[a];

                    pullDirectionX = blackHole.PosX - _blackHoles[b].PosX;
                    pullDirectionY = blackHole.PosY - _blackHoles[b].PosY;
                    pullDirectionZ = blackHole.PosZ - _blackHoles[b].PosZ;

                    distance = Math.Sqrt(
                        pullDirectionX * pullDirectionX +
                        pullDirectionY * pullDirectionY +
                        pullDirectionZ * pullDirectionZ);

                    force = PhysicsConstants.G * ((blackHole.Mass * _blackHoles[b].Mass) / (distance * distance)) * 0.001;

                    blackHole.VelX += force * pullDirectionX;
                    blackHole.VelY += force * pullDirectionY;
                    blackHole.VelZ += force * pullDirectionZ;
                }

                blackHole.PosX += blackHole.VelX;
                blackHole.PosY += blackHole.VelY;
                blackHole.PosZ += blackHole.VelZ;
            }
            */ 

            foreach (StarBufferIndex star in _allStars)
            {
                foreach (BlackHole blackHole in _blackHoles)
                {
                    pullDirectionX = blackHole.PosX - star.Buffer[star.Index].X;
                    pullDirectionY = blackHole.PosY - star.Buffer[star.Index].Y;
                    pullDirectionZ = blackHole.PosZ - star.Buffer[star.Index].Z;

                    distance = Math.Sqrt(
                        pullDirectionX * pullDirectionX +
                        pullDirectionY * pullDirectionY +
                        pullDirectionZ * pullDirectionZ);

                    force = 0.0000000000667300 * ((star.Mass * blackHole.Mass) / (distance * distance));

                    star.VelX += (float)(force * pullDirectionX);
                    star.VelY += (float)(force * pullDirectionY);
                    star.VelZ += (float)(force * pullDirectionZ);
                }

                star.Buffer[star.Index].X += star.VelX;
                star.Buffer[star.Index].Y += star.VelY;
                star.Buffer[star.Index].Z += star.VelZ;
            }
        }
    }
}
