using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;
using System.Threading;


namespace GalaxySmash
{
    public enum CalculationMode
    {
        None,
        SimpleApproximated,
        SectorApproximated,
        Scientific
    };

    public partial class Form1 : Form
    {
        private Octree _universe;
        private readonly Random _rand = new Random();
        private Microsoft.DirectX.Direct3D.Device _device;
        private PresentParameters _presentParams;
        private Input _input;
        private UniversalRemote _universalRemote;
        private CustomVertex.PositionColored[] _grid;
        private readonly Camera _camera = new Camera();
        private StarBufferManager _starBufferManager;
        private Thread[] _threads;
        private float total = 0;

        #region Initalize

        public Form1()
        {
            //this.Size = new System.Drawing.Size(1280, 1024);
            this.Text = "GalaxySmash";
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
            this.WindowState = FormWindowState.Maximized;

            _presentParams = new PresentParameters();
            _presentParams.Windowed = true;
            _presentParams.SwapEffect = SwapEffect.Discard;

            _device = new Microsoft.DirectX.Direct3D.Device(0, Microsoft.DirectX.Direct3D.DeviceType.Hardware, this, CreateFlags.HardwareVertexProcessing, _presentParams);

            _input = new Input();

            _input.Init(this);

           _universalRemote = new UniversalRemote();
           // _universalRemote.Show();
        }


        /// <summary>
        /// 
        /// </summary>
        private void ReloadSimulation()
        {
            InitGeometry();
            InitUniverse();

            _threads = new Thread[SettingsLocal.GetAsInt("MaxProcessingThreadCount")];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="wind"></param>
        /// <param name="swap"></param>
        /// <param name="BackBuffers"></param>
        /// <param name="BBWidth"></param>
        /// <param name="BBHeight"></param>
        /// <param name="BBFmt"></param>
        /// <returns></returns>
        public PresentParameters SetPParams(bool wind, SwapEffect swap, int BackBuffers, int BBWidth, int BBHeight, Format BBFmt)
        {
            return new PresentParameters
            {
                Windowed = wind,        // Is our device going to be running in a windowed or full screen application?
                SwapEffect = swap,        // How should we handle the refreshing of our application?
                BackBufferCount = BackBuffers,
                BackBufferHeight = BBHeight,
                BackBufferWidth = BBWidth,
                BackBufferFormat = BBFmt
            };
        }

        private int GetTotalStarCount(List<string> galaxies)
        {
            int totalStarCount = 0;

            foreach (string galaxy in galaxies)
            {
                totalStarCount += SettingsLocal.GetAsInt("Galaxy" + galaxy + "NumberOfStars");
            }

            return totalStarCount;
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitUniverse()
        {
            if (_universe != null)
            {
                _universe.Clear();
                _universe = null;
            }

            if (_starBufferManager != null)
            {
                _starBufferManager.Clear();
                _starBufferManager = null;
            }

            _universe = new Octree(SettingsLocal.GetAsInt("MaxStarsPerSector"));

            List<string> galaxies = SettingsLocal.AllValuesAsString("Universe" + CurrentUniverseID() +"GalaxyID");

            _starBufferManager = new StarBufferManager(
                SettingsLocal.GetAsInt("StarBufferSize"), 
                GetTotalStarCount(galaxies));
            
            var galaxyStars = new List<LinkedList<StarBufferIndex>>(galaxies.Count);
            
            
            foreach (string galaxyID in galaxies)
            {
                long  numberfStars           = SettingsLocal.GetAsLong( "Galaxy" + galaxyID + "NumberOfStars");
                int   distributionIterations = SettingsLocal.GetAsInt(  "Galaxy" + galaxyID + "DistributionIterations");
                float starVelocity           = SettingsLocal.GetAsFloat("Galaxy" + galaxyID + "StarVelocity");

                var stars = new LinkedList<StarBufferIndex>();

                Color col = Color.FromArgb(SettingsLocal.GetAsInt("Galaxy" + galaxyID + "StarColor"));

                for (long a = 0; a < numberfStars; a++)
                {
                    stars.AddLast(GenerateRandomStar(galaxyID, distributionIterations, starVelocity, col));

                }

                galaxyStars.Add(stars);

                var blackHole = new BlackHole
                { 
                    PosX = (float)SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionX"),
                    PosY = (float)SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionY"),
                    PosZ = (float)SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionZ"),
                    Mass = (float)SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "SupermassiveBlackHoleSolarMasses")
                };

                _universe.AddBlackHole(blackHole);
            }

            bool anyStarsLeft = true;

            while (anyStarsLeft)
            {
                anyStarsLeft = false;

                for (int a = 0; a < galaxyStars.Count; a++)
                {
                    if (galaxyStars[a].Count == 0)
                        continue;

                    anyStarsLeft = true;

                    _universe.AddStar(galaxyStars[a].First.Value);

                    galaxyStars[a].RemoveFirst();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="galaxyID"></param>
        /// <param name="distributionIterations"></param>
        /// <returns></returns>
        private StarBufferIndex GenerateRandomStar(string galaxyID, int distributionIterations, float starVelocity, Color col)
        {
            double x, y, z;

            // Place all staring positions within a sphere
            do
            {
                x = -0.5 + _rand.NextDouble();
                y = -0.5 + _rand.NextDouble();
                z = -0.5 + _rand.NextDouble();
            }
            while (Math.Sqrt(x * x + y * y + z * z) > 0.5);

            int chanceSkewX = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewX");
            int chanceSkewY = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewY");
            int chanceSkewZ = SettingsLocal.GetAsInt("Galaxy" + galaxyID + "ChanceSkewZ");

            double skewAmountX = 
                SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowX") + 
                (SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewHighX") - SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowX")) 
                * _rand.NextDouble();

            double skewAmountY = 
                SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowY") + 
                (SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewHighY") - SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowY"))
                * _rand.NextDouble();

            double skewAmountZ = SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowZ") + 
                (SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewHighZ") - SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "ChanceSkewLowZ")) 
                * _rand.NextDouble();

            for (int a = 0; a < distributionIterations; a++)
            {
                if (_rand.Next(0, 100) < chanceSkewX)
                    x *= skewAmountX;

                if (_rand.Next(0, 100) < chanceSkewY)
                    y *= skewAmountY;

                if (_rand.Next(0, 100) < chanceSkewZ)
                    z *= skewAmountZ;
            }
            
            // Continue skewing star placement until it is sufficiently far from the black hole
            double minDistanceToBlackHole = SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "MinDistanceToBlackHole");

            while (Math.Sqrt(x * x + y * y + z * z) < minDistanceToBlackHole)
            {
                if (_rand.Next(0, 100) < chanceSkewX)
                    x *= skewAmountX;

                if (_rand.Next(0, 100) < chanceSkewY)
                    y *= skewAmountY;

                if (_rand.Next(0, 100) < chanceSkewZ)
                    z *= skewAmountZ;
            }

            var centerToStar = new Vector3
            {
                X = (float)x,
                Z = (float)z
            };

            var upVector = new Vector3
            {
                Y = 1
            };

            Vector3 vel = Vector3.Cross(centerToStar, upVector);
            vel.Normalize();

            vel *= starVelocity;

            x += SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionX");
            y += SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionY");
            z += SettingsLocal.GetAsDouble("Galaxy" + galaxyID + "PositionZ");

            StarBufferIndex star = _starBufferManager.AddStar();

            star.Buffer[star.Index].X = (float)x;
            star.Buffer[star.Index].Y = (float)y;
            star.Buffer[star.Index].Z = (float)z;

            star.Buffer[star.Index].Color = col.ToArgb();

            star.VelX = vel.X;
            star.VelY = vel.Y;
            star.VelZ = vel.Z;

            star.Mass = 1;

            return star;
        }


        /// <summary>
        /// 
        /// </summary>
        private void InitGeometry()
        {
            var lines = new List<CustomVertex.PositionColored>();
            int gridSize = SettingsLocal.GetAsInt("GridSizeUniverse" + CurrentUniverseID());

            int half = (gridSize / 2);

            for (int x = 0; x < gridSize + 1; x++)
            {
                var paleWhite = Color.DarkBlue;

                // X
                lines.Add(new CustomVertex.PositionColored(-half + x, 0, -half, paleWhite.ToArgb()));
                lines.Add(new CustomVertex.PositionColored(-half + x, 0, half, paleWhite.ToArgb()));

                // Z
                lines.Add(new CustomVertex.PositionColored(-half, 0, -half + x, paleWhite.ToArgb()));
                lines.Add(new CustomVertex.PositionColored(half, 0, -half + x, paleWhite.ToArgb()));
            }

            int red = Color.FromArgb(128, 0, 0).ToArgb();

            // Bottom Square
            lines.Add(new CustomVertex.PositionColored(0, -half, 0, red));
            lines.Add(new CustomVertex.PositionColored(0, half, 0, red));

            lines.Add(new CustomVertex.PositionColored(-half, -half, half, red));
            lines.Add(new CustomVertex.PositionColored(half, -half, half, red));

            lines.Add(new CustomVertex.PositionColored(-half, -half, -half, red));
            lines.Add(new CustomVertex.PositionColored(half, -half, -half, red));

            lines.Add(new CustomVertex.PositionColored(-half, -half, -half, red));
            lines.Add(new CustomVertex.PositionColored(-half, -half, half, red));

            lines.Add(new CustomVertex.PositionColored(half, -half, -half, red));
            lines.Add(new CustomVertex.PositionColored(half, -half, half, red));


            // Top Square
            lines.Add(new CustomVertex.PositionColored(-half, half, half, red));
            lines.Add(new CustomVertex.PositionColored(half, half, half, red));

            lines.Add(new CustomVertex.PositionColored(-half, half, -half, red));
            lines.Add(new CustomVertex.PositionColored(half, half, -half, red));

            lines.Add(new CustomVertex.PositionColored(-half, half, -half, red));
            lines.Add(new CustomVertex.PositionColored(-half, half, half, red));

            lines.Add(new CustomVertex.PositionColored(half, half, -half, red));
            lines.Add(new CustomVertex.PositionColored(half, half, half, red));


            // Size verticals
            lines.Add(new CustomVertex.PositionColored(-half, -(gridSize / 2), half, red));
            lines.Add(new CustomVertex.PositionColored(-half, (gridSize / 2), half, red));

            lines.Add(new CustomVertex.PositionColored(half, -(gridSize / 2), half, red));
            lines.Add(new CustomVertex.PositionColored(half, (gridSize / 2), half, red));

            lines.Add(new CustomVertex.PositionColored(-half, -(gridSize / 2), -half, red));
            lines.Add(new CustomVertex.PositionColored(-half, (gridSize / 2), -half, red));

            lines.Add(new CustomVertex.PositionColored(half, -(gridSize / 2), -half, red));
            lines.Add(new CustomVertex.PositionColored(half, (gridSize / 2), -half, red));

            _grid = lines.ToArray();
        }

        #endregion

        private string CurrentUniverseID()
        {
            return SettingsLocal.GetAsString("CurrentUniverseID");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            switch (_universalRemote.GetRequestedAction())
            {
                case UniversalRemoteAction.None:
                    break;

                case UniversalRemoteAction.ReloadSimulation:
                    ReloadSimulation();
                    break;
            }

            FrameMove();
            Render();
        }

        #region Render


        /// <summary>
        /// 
        /// </summary>
        private void Render()
        {
            _device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4, this.Width / this.Height, 0.01f, 1000);

            total += 0.003f;

            float zoom = 100 + (float)Math.Sin(total) * 15;

            _device.Transform.View = _camera.FrameMove(0.003f, _input);
            
            _device.RenderState.Lighting = false;
            _device.RenderState.CullMode = Cull.None;
            _device.Clear(ClearFlags.Target, Color.Black, 1.0f, 0);
            _device.BeginScene();
            
            _device.VertexFormat = CustomVertex.PositionColored.Format;
            _device.DrawUserPrimitives(PrimitiveType.LineList, _grid.Length / 2, _grid);

            if (SettingsLocal.GetAsBool("RenderStars"))
            {
                foreach(CustomVertex.PositionColored[] starBuffer in _starBufferManager.Buffers)
                {
                    
                    _device.DrawUserPrimitives(PrimitiveType.PointList, starBuffer.Length, starBuffer);
                }
                //CustomVertex.PositionColored[] starGeometry = _universe.GetStarGeometry().ToArray();
                //_device.DrawUserPrimitives(PrimitiveType.PointList, starGeometry.Length, starGeometry);
            }

            if (SettingsLocal.GetAsBool("RenderSectorGeometry"))
            {
                CustomVertex.PositionColored[] starSectorGeometry = _universe.GetSectorGeometry().ToArray();
                _device.DrawUserPrimitives(PrimitiveType.LineList, starSectorGeometry.Length / 2, starSectorGeometry);
            }

            if (SettingsLocal.GetAsBool("RenderVelocityVectors"))
            {
                CustomVertex.PositionColored[] velocityVectors = _universe.GetVelocityVectors().ToArray();
                _device.DrawUserPrimitives(PrimitiveType.LineList, velocityVectors.Length / 2, velocityVectors);
            }

            _device.EndScene();

            _device.Present();

            this.Invalidate();
        }

        #endregion

        #region Frame Move

        
        /// <summary>
        /// 
        /// </summary>
        private void FrameMove()
        {
            _input.FrameMove();

            if (_input.Keyboard[Key.F1])
            {
                _universalRemote.ShowDialog();
            }

            CalculationMode calculationMode = (CalculationMode)Enum.Parse(typeof(CalculationMode), SettingsLocal.GetAsString("CalculationMode"));
            
            var bufferAssignments = new List<List<StarBufferIndex[]>>(_threads.Length);

            for (int a = 0; a < _threads.Length; a++)
            {
                bufferAssignments.Add(new List<StarBufferIndex[]>());
                _threads[a] = new Thread(Form1.CalculateStarBuffers);
               
            }

            for (int a = 0; a < _starBufferManager.Buffers.Count; a++)
            {
                bufferAssignments[a %_threads.Length].Add(_starBufferManager.StarBufferIndexes[a]);
            }

            _universe.FrameMoveBlackHoles();

            for (int a = 0; a < _threads.Length; a++)
            {
                _threads[a].Start(new object[] {bufferAssignments[a].ToArray(), _universe.BlackHoles});
            }
            
            bool anyThreadLives = true;

            while(anyThreadLives)
            {
                anyThreadLives = false;

                for (int a = 0; a < _threads.Length; a++)
                {
                    if(_threads[a].IsAlive)
                    {
                        anyThreadLives = true;
                        break;
                    }
                }
            }
            
            //_universe.FrameMove(calculationMode);
        }

        public static void CalculateStarBuffers(object data)
        {
            object[] buffersAndBlackHoles = (object[])data;

            StarBufferIndex[][] buffers = (StarBufferIndex[][])buffersAndBlackHoles[0];
            BlackHole[] blackHoles = (BlackHole[])buffersAndBlackHoles[1];

            double pullDirectionX;
            double pullDirectionY;
            double pullDirectionZ;
            double force;
            double distance;
            int a = 0;

            double magicVelocity = 0.04;

            foreach (StarBufferIndex[] starBufferIndexArray in buffers)
            {
                foreach (StarBufferIndex star in starBufferIndexArray)
                {
                    if (star == null)
                        continue;
                    /*
                    {
                        int ab = 0;
                        ab++;
                    }
                    */
                    foreach (BlackHole blackHole in blackHoles)
                    {
                        a++;
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

                    if (star.VelX > magicVelocity || star.VelX > magicVelocity || star.VelX > magicVelocity)
                    {
                        star.Buffer[star.Index].Color = Color.Black.ToArgb();
                    }

                    star.Buffer[star.Index].X += star.VelX;
                    star.Buffer[star.Index].Y += star.VelY;
                    star.Buffer[star.Index].Z += star.VelZ;
                }
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
