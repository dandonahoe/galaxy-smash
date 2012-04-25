using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace GalaxySmash
{
    public class Camera
    {
        public Vector3 m_From;
        public Vector3 m_To;
        public Vector3 m_Up;

        private float m_fElapsedTime;

        public Camera()
        {
            m_From.X = 0.0f;
            m_From.Y = 10.0f;
            m_From.Z = -30.0f;

            m_To.X = 0.0f;
            m_To.Y = 0.0f;
            m_To.Z = 0.0f;

            m_Up.X = 0.0f;
            m_Up.Y = 1.0f;
            m_Up.Z = 0.0f;
        }

        //-----------------------------------------------------------------------------
        // Name: FrameMove()
        // Desc:
        //-----------------------------------------------------------------------------
        public Matrix FrameMove(float fElapsedTime, Input input)
        {
	        m_fElapsedTime = fElapsedTime;
            input.Mouse.GetMouseButtons();

            const float DIVIDE = 700.0f;

            byte[] keys = input.Mouse.GetMouseButtons();

            bool leftDown = keys[0] == 128;
            bool rightDown = keys[1] == 128;

            if (leftDown && rightDown)
            {
                Vector3 matTrans = new Vector3();

                matTrans.Y = ( -(float)input.Mouse.Y / DIVIDE ) * fElapsedTime * DIVIDE * 10.0f;
                m_From += matTrans;
                m_To   += matTrans;

                Vector3 vCross;
                Vector3 vViewVector = m_To - m_From;

                vCross.X = ( ( m_Up.Y * vViewVector.Z ) - ( m_Up.Z * vViewVector.Y ) );
                vCross.Y = ( ( m_Up.Z * vViewVector.X ) - ( m_Up.X * vViewVector.Z ) );
                vCross.Z = ( ( m_Up.X * vViewVector.Y ) - ( m_Up.Y * vViewVector.X ) );

                m_From.X += vCross.X * ( (float)input.Mouse.X / DIVIDE ) * fElapsedTime * DIVIDE * 0.15f;
                m_From.Z += vCross.Z * ((float)input.Mouse.X / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;

                m_To.X += vCross.X * ((float)input.Mouse.X / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;
                m_To.Z += vCross.Z * ((float)input.Mouse.X / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;
            }
            else if (rightDown)
            {
                RotateView(0.0f, -((float)input.Mouse.X / DIVIDE) * fElapsedTime * DIVIDE * 0.15f, 0.0f);

                m_To.Y += (-(float)input.Mouse.Y / DIVIDE) * fElapsedTime * (DIVIDE * 2.0f) * 10;
            }
            else if (leftDown)
            {
                Vector3 vVector;

                RotateView(0.0f, -((float)input.Mouse.X / DIVIDE) * fElapsedTime * DIVIDE * 0.15f, 0.0f);

		        vVector = m_To - m_From;

                m_From.X += vVector.X * (-(float)input.Mouse.Y / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;
                m_From.Z += vVector.Z * (-(float)input.Mouse.Y / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;

                m_To.X += vVector.X * (-(float)input.Mouse.Y / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;
                m_To.Z += vVector.Z * (-input.Mouse.Y / DIVIDE) * fElapsedTime * DIVIDE * 0.15f;
            }

            return Matrix.LookAtLH(m_From, m_To, m_Up);
        }


        //-----------------------------------------------------------------------------
        // Name: GetFromVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool GetFromVec( out float x, out float y, out float z )
        {
            x = m_From.X;
            y = m_From.Y;
            z = m_From.Z;

            return true;
        }


        //-----------------------------------------------------------------------------
        // Name: GetToVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool GetToVec(out float x, out float y, out float z )
        {
            x = m_To.X;
            y = m_To.Y;
            z = m_To.Z;

            return true;
        }


        //-----------------------------------------------------------------------------
        // Name: GetUpVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool GetUpVec(out float x, out float y, out float z )
        {
            x = m_Up.X;
            y = m_Up.Y;
            z = m_Up.Z;

            return true;
        }


        //-----------------------------------------------------------------------------
        // Name: SetFromVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool SetFromVec( float x, float y, float z )
        {
            m_From.X = x;
            m_From.Y = y;
            m_From.Z = z;

            return true;
        }


        //-----------------------------------------------------------------------------
        // Name: SetToVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool SetToVec( float x, float y, float z )
        {
            m_To.X = x;
            m_To.Y = y;
            m_To.Z = z;

            return true;
        }


        //-----------------------------------------------------------------------------
        // Name: SetUpVec()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool SetUpVec( float x, float y, float z )
        {
            m_Up.X = x;
            m_Up.Y = y;
            m_Up.Z = z;

            return true;
        }



        //-----------------------------------------------------------------------------
        // Name: RotateView()
        // Desc:
        //-----------------------------------------------------------------------------
        private bool RotateView( float X, float Y, float Z )
        {
            Vector3 vVector;

            // Get our view vector (The direciton we are facing)
            vVector.X = m_To.X - m_From.X;        // This gets the direction of the X    
            vVector.Y = m_To.Y - m_From.Y;        // This gets the direction of the Y
            vVector.Z = m_To.Z - m_From.Z;        // This gets the direction of the Z

            // Rotate the view along the desired axis
            if( X != 0 )
            {
                // Rotate the view vector up or down, then add it to our position
                m_To.Z = (float)( m_From.Z + Math.Sin( X ) * vVector.Y + Math.Cos( X ) * vVector.Z );
                m_To.Y = (float)( m_From.Y + Math.Cos( X ) * vVector.Y - Math.Sin( X ) * vVector.Z );
            }

            if( Y != 0 )
            {
                // Rotate the view vector right or left, then add it to our position
                m_To.Z = (float)( m_From.Z + Math.Sin( Y ) * vVector.X + Math.Cos( Y ) * vVector.Z );
                m_To.X = (float)( m_From.X + Math.Cos( Y ) * vVector.X - Math.Sin( Y ) * vVector.Z );
            }

            if( Z != 0 )
            {
                // Rotate the view vector diagnally right or diagnally down, then add it to our position
                m_To.X = (float)( m_From.X + Math.Sin( Z ) * vVector.Y + Math.Cos( Z ) * vVector.X );        
                m_To.Y = (float)( m_From.Y + Math.Cos( Z ) * vVector.Y - Math.Sin( Z ) * vVector.X );
            }

            return true;
        }


    }
}
