using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace intro3D
{
    class ClsPyramid
    {
        VertexPositionColor[] vertices;
        VertexPositionColor[] vertices_lado;
        BasicEffect effect;
        Matrix worldMatrix;

  /*      public float movCamera_x = 0.5f;
        public float movCamera_z = 0.5f;
        public float movCamera_h = 2.0f; */

        public ClsPyramid(GraphicsDevice device, int nSides, float r, float h)
        {
            effect = new BasicEffect(device);

            //  Calcula a aspectRatio, a view matrix e a projeção
            float aspectRatio = (float)device.Viewport.Width /device.Viewport.Height;

            effect.View = Matrix.CreateLookAt(new Vector3(0.5f, 2f, 2.0f),Vector3.Zero, Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60.0f),aspectRatio, 0.1f, 1000.0f);
            effect.LightingEnabled = false;
            effect.VertexColorEnabled = true;
            //  Cria os eixos 3D
            CreateGeometry(nSides,r,h);
            worldMatrix = Matrix.Identity;
        }

        private void CreateGeometry(int nSides, float r,float h)
        {
            Color[] cores;
            cores = new Color[10];
            cores[0] = Color.Red;
            cores[1] = Color.Green;
            cores[2] = Color.Blue;
            cores[3] = Color.Magenta;
            cores[4] = Color.Cyan;
            cores[5] = Color.Yellow;
            cores[6] = Color.Brown;
            cores[7] = Color.Black;
            cores[8] = Color.Gray;
            cores[9] = Color.Lime;

            int vertexCount = (nSides) * 6;
            vertices = new VertexPositionColor[vertexCount];
            vertices_lado = new VertexPositionColor[vertexCount];

            for (int i = 0; i < nSides; i++)
            {
                float angulo = MathHelper.ToRadians(i * (360.0f / nSides));
                float angulo_seguinte = MathHelper.ToRadians((i + 1) * (360.0f / nSides));

                float x = r * (float)System.Math.Cos((double)angulo);
                float z = -r * (float)System.Math.Sin((double)angulo);

                float x_seguinte = r * (float)System.Math.Cos((double)angulo_seguinte);
                float z_seguinte = -r * (float)System.Math.Sin((double)angulo_seguinte);

                vertices[3 * i + 0] = new VertexPositionColor(new Vector3(0, h, 0), Color.White);
                vertices[3 * i + 1] = new VertexPositionColor(new Vector3(x_seguinte, h, z_seguinte), Color.White);
                vertices[3 * i + 2] = new VertexPositionColor(new Vector3(x, h, z), Color.White);

                vertices_lado[6 * i + 0] = new VertexPositionColor(new Vector3(x, 0, z), cores[i]);
                vertices_lado[6 * i + 1] = new VertexPositionColor(new Vector3(x, h,z), cores[i]); 
                vertices_lado[6 * i + 2] = new VertexPositionColor(new Vector3(x_seguinte, h, z_seguinte), cores[i]);

                vertices_lado[6 * i + 3] = new VertexPositionColor(new Vector3(x, 0, z), cores[i]);
                vertices_lado[6 * i + 4] = new VertexPositionColor(new Vector3(x_seguinte, h, z_seguinte), cores[i]);
                vertices_lado[6 * i + 5] = new VertexPositionColor(new Vector3(x_seguinte, 0, z_seguinte), cores[i]); 

            }

        }

        public void Draw(GraphicsDevice device)
        {
            // World Matrix
            effect.World = worldMatrix;
            // Indica o efeito para desenhar os eixos
            effect.CurrentTechnique.Passes[0].Apply();
            device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices, 0, vertices.Length /3);
            device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vertices_lado, 0, vertices.Length / 3);

        }
    }
}
