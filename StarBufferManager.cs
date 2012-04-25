using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;


namespace GalaxySmash
{
    public class StarBufferIndex
    {   
        public int Index;
        public CustomVertex.PositionColored[] Buffer;
        public float VelX = 0;
        public float VelY = 0;
        public float VelZ = 0;
        public float Mass = 0;
    }

    public class StarBufferManager
    {
        private readonly int _bufferSize;
        private readonly int _totalStarCount;
        private List<CustomVertex.PositionColored[]> _positionColorBuffer;
        private int _currentBuffer;
        private int _currentIndex;
        private List<StarBufferIndex[]> _starBufferIndexes;

        /// <summary>
        /// 
        /// </summary>
        public List<CustomVertex.PositionColored[]> Buffers
        {
            get { return _positionColorBuffer; }
        }

        public List<StarBufferIndex[]> StarBufferIndexes
        {
            get { return _starBufferIndexes; }
        }

        public void Clear()
        {
            _positionColorBuffer.Clear();
            _positionColorBuffer = null;

            _starBufferIndexes.Clear();
            _starBufferIndexes = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferSize"></param>
        public StarBufferManager(int bufferSize, int totalStarCount)
        {
            _bufferSize     = bufferSize;
            _totalStarCount = totalStarCount;
            _currentBuffer  = 0;
            _currentIndex   = 0;

            int buffersNeeded = totalStarCount / bufferSize;

            int remainingStarCount = totalStarCount % bufferSize;

            if (remainingStarCount != 0)
                buffersNeeded++;

            _positionColorBuffer = new List<CustomVertex.PositionColored[]>();
            _starBufferIndexes = new List<StarBufferIndex[]>();

            for (int a = 0; a < buffersNeeded; a++)
            {
                _positionColorBuffer.Add(new CustomVertex.PositionColored[_bufferSize]);
                _starBufferIndexes.Add(new StarBufferIndex[_bufferSize]);

                // The last buffer may have less than the maximum allowed
                if (remainingStarCount != 0 && a == buffersNeeded - 2)
                {
                    _positionColorBuffer.Add(new CustomVertex.PositionColored[remainingStarCount]);
                    _starBufferIndexes.Add(new StarBufferIndex[remainingStarCount]);
                    break;
                }
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public StarBufferIndex AddStar()
        {
            var starBufferIndex = new StarBufferIndex
            {
                Index  = _currentIndex,
                Buffer = _positionColorBuffer[_currentBuffer]
            };

            _starBufferIndexes[_currentBuffer][_currentIndex] = starBufferIndex;

            if (_currentIndex == _bufferSize - 1)
            {
                _currentIndex = 0;
                _currentBuffer++;
            }
            else
            {
                _currentIndex++;
            }

            return starBufferIndex;
        }
    }
}
