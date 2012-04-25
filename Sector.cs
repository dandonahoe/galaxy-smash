using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using System.Drawing;


namespace GalaxySmash
{
    public enum SectorName
    {
        TopLeftBack = 0,
        TopRightBack = 1,
        TopLeftFront = 2,
        TopRightFront = 3,
        BottomLeftBack = 4,
        BottomRightBack = 5,
        BottomLeftFront = 6,
        BottomRightFront = 7
    };

    public class Sector
    {
        private readonly Octree _universe;
        private static int LevelCount = 0;
        private Vector3 _aggregateStarPosition = new Vector3();
        private readonly long MaxStarsPerSector;
        public readonly int CurrentLevel;
        private LinkedList<StarBufferIndex> _stars = null;
        private Sector[] _children = null;
        private double _averageX;
        private double _averageY;
        private double _averageZ;
        private static long _numberOfSectors = 0;
        private float _maxX;
        private float _minX;
        private float _maxY;
        private float _minY;
        private float _maxZ;
        private float _minZ;
        private readonly int SectorTint;
        private static Random _rand = new Random();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="universe"></param>
        /// <param name="maxStarsPerSector"></param>
        /// <param name="currentLevel"></param>
        public Sector(Octree universe, long maxStarsPerSector, int currentLevel)
        {
            _universe         = universe;
            CurrentLevel      = currentLevel;
            _stars            = new LinkedList<StarBufferIndex>();
            MaxStarsPerSector = maxStarsPerSector;
            SectorTint        = Color.FromArgb(_rand.Next(0, 255), _rand.Next(0, 255), _rand.Next(0, 255)).ToArgb();
            _numberOfSectors++;

            if (CurrentLevel > LevelCount)
                LevelCount = CurrentLevel;            
        }


        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            // Be really freaking careful not to call this recursively. Free all
            // nodes with stars before clearing structure sectors
            _children = null;

            _aggregateStarPosition.X = 0;
            _aggregateStarPosition.Y = 0;
            _aggregateStarPosition.Z = 0;

            if (_stars != null)
                _stars.Clear();

            _stars = null;
            _averageX = 0;
            _averageY = 0;
            _averageZ = 0;
            _numberOfSectors = 0;
            _maxX = 0;
            _minX = 0;
            _maxY = 0;
            _minY = 0;
            _maxZ = 0;
            _minZ = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public Sector[] ChildSectors
        {
            get
            {
                if (_children == null)
                    throw new Exception("Sector has no children");

                return _children; 
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public bool HasSubdivided
        {
            get { return _stars == null; }
        }


        /// <summary>
        /// 
        /// </summary>
        public long NumberOfSectors
        {
            get { return _numberOfSectors; }
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CustomVertex.PositionColored> GetStarGeometry()
        {
            var starGeometry = new List<CustomVertex.PositionColored>();

            foreach (Star star in _stars)
            {
                starGeometry.Add(new CustomVertex.PositionColored((float)star.PosX, (float)star.PosY, (float)star.PosZ, Color.White.ToArgb()));
            }

            return starGeometry;
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CustomVertex.PositionColored> GetGeometry()
        {
            if (_stars != null)
            {
                return new List<CustomVertex.PositionColored>();
            }
            else
            {
                var sector = new List<CustomVertex.PositionColored>(12);

                int shade = 0;

                if (LevelCount != 0)
                    shade = (int)(((float)CurrentLevel / (float)LevelCount) * 255.0f * 0.5f);

                int col = SectorTint;// Color.FromArgb(shade, shade, shade).ToArgb();

                // Bottom Square
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _maxZ, col));

                /*
                sector.Add(new CustomVertex.PositionColored(_minX, (float)_averageY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, (float)_averageY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, (float)_averageY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, (float)_averageY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, (float)_averageY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, (float)_averageY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, (float)_averageY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, (float)_averageY, _maxZ, Color.Green.ToArgb()));
                */

                // Top Square
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _maxZ, col));


                // Vertical lines
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _maxZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, _minZ, col));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, _minZ, col));

                /*
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _minY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _maxY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _minY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _maxY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _minY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _minY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _maxY, _maxZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _maxY, _minZ, Color.Green.ToArgb()));


                sector.Add(new CustomVertex.PositionColored(_minX, _minY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, _maxY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, _maxY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, _minY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_minX, _minY, (float)_averageZ, Color.Green.ToArgb()));
                

                sector.Add(new CustomVertex.PositionColored(_minX, (float)_averageY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored(_maxX, (float)_averageY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _maxY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, _minY, (float)_averageZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, (float)_averageY, _minZ, Color.Green.ToArgb()));
                sector.Add(new CustomVertex.PositionColored((float)_averageX, (float)_averageY, _maxZ, Color.Green.ToArgb()));
                */

                return sector;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="star"></param>
        public void AddStar(StarBufferIndex star)
        {
            if (_stars == null)
                throw new Exception("Cannot add stars to a subdivided sector");

            _stars.AddLast(star);

            if (star.Buffer[star.Index].X > _maxX)
            {
                _maxX = (float)star.Buffer[star.Index].X;
            }
            else if (star.Buffer[star.Index].X < _minX)
            {
                _minX = (float)star.Buffer[star.Index].X;
            }

            if (star.Buffer[star.Index].Y > _maxY)
            {
                _maxY = (float)star.Buffer[star.Index].Y;
            }
            else if (star.Buffer[star.Index].Y < _minY)
            {
                _minY = (float)star.Buffer[star.Index].Y;
            }

            if (star.Buffer[star.Index].Z > _maxZ)
            {
                _maxZ = (float)star.Buffer[star.Index].Z;
            }
            else if (star.Buffer[star.Index].Z < _minZ)
            {
                _minZ = (float)star.Buffer[star.Index].Z;
            }

            _aggregateStarPosition.X += star.Buffer[star.Index].X;
            _aggregateStarPosition.Y += star.Buffer[star.Index].Y;
            _aggregateStarPosition.Z += star.Buffer[star.Index].Z;

            if (_stars.Count > MaxStarsPerSector)
            {
                DivideAndConquer();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="star"></param>
        /// <returns></returns>
        public Sector GetAppropriateChildSector(StarBufferIndex star)
        {
            if (star.Buffer[star.Index].X < _averageX)
            {
                if (star.Buffer[star.Index].Y < _averageY)
                {
                    if (star.Buffer[star.Index].Z < _averageZ)
                    {
                        return _children[(int)SectorName.BottomLeftBack];
                    }
                    else
                    {
                        return _children[(int)SectorName.BottomLeftFront];
                    }
                }
                else
                {
                    if (star.Buffer[star.Index].Z < _averageZ)
                    {
                        return _children[(int)SectorName.TopLeftBack];
                    }
                    else
                    {
                        return _children[(int)SectorName.TopLeftFront];
                    }
                }
            }
            else
            {
                if (star.Buffer[star.Index].Y < _averageY)
                {
                    if (star.Buffer[star.Index].Z < _averageZ)
                    {
                        return _children[(int)SectorName.BottomRightBack];
                    }
                    else
                    {
                        return _children[(int)SectorName.BottomRightFront];
                    }
                }
                else
                {
                    if (star.Buffer[star.Index].Z < _averageZ)
                    {
                        return _children[(int)SectorName.TopRightFront];
                    }
                    else
                    {
                        return _children[(int)SectorName.TopRightBack];
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void DivideAndConquer()
        {
            StarBufferIndex star;

            _children = new Sector[8];

            for (int a = 0; a < 8; a++)
            {
                _children[a] = new Sector(_universe, MaxStarsPerSector, CurrentLevel + 1);
                _universe.RegisterSector(_children[a]);
            }

            _averageX = _aggregateStarPosition.X / MaxStarsPerSector;
            _averageY = _aggregateStarPosition.Y / MaxStarsPerSector;
            _averageZ = _aggregateStarPosition.Z / MaxStarsPerSector;

            while (_stars.Count > 0)
            {
                star = _stars.First.Value;

                GetAppropriateChildSector(star).AddStar(star);

                _stars.RemoveFirst();
            }

            _stars.Clear();
            _stars = null;
        }
    }
}
