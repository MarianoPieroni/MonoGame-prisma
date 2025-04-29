using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace intro3D
{
    class ClsPyramidTriangleStrip
    {
        VertexPositionColor[] vertices;
        BasicEffect effect;
        Matrix worldMatrix;


        public ClsPyramidTriangleStrip(GraphicsDevice device)
        {
            //  Vamos usar um efeito básico
            effect = new BasicEffect(device);
            //  Calcula a aspectRatio, a view matrix e a projeção
            float aspectRatio = (float)device.Viewport.Width /
            device.Viewport.Height;
            effect.View = Matrix.CreateLookAt(
            new Vector3(1.0f, 0.5f, 2.0f),
            Vector3.Zero, Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.ToRadians(60.0f),
            aspectRatio, 0.1f, 1000.0f);
            effect.LightingEnabled = false;
            effect.VertexColorEnabled = true;
            //  Cria os eixos 3D
            CreateGeometry();
            worldMatrix = Matrix.Identity;
        }

        private void CreateGeometry()
        {

            int numLados = 6;
            float h = 1;
            float baseRadius = 1f; // raio da base
            int vertexCount = 2 * (numLados + 1);
            vertices = new VertexPositionColor[vertexCount];

            for (int i = 0; i <= numLados; i++)
            {
                float angulo = MathHelper.ToRadians(i * (360 / numLados));
                float x = baseRadius * (float)Math.Cos((double)angulo);
                float z = -baseRadius * (float)Math.Sin((double)angulo);
                vertices[2 * i + 0] = new VertexPositionColor(new Vector3(x, 0, z), Color.Yellow);
                vertices[2 * i + 1] = new VertexPositionColor(new Vector3(0.0f, h, 0.0f), Color.Black);  //piramide
                                                                                                         // vertices[2 * i + 1] = new VertexPositionColor(new Vector3(x, h, z), Color.White); //prisma
            }

        }

        public void Draw(GraphicsDevice device)
        {
            // World Matrix
            effect.World = worldMatrix;
            // Indica o efeito para desenhar os eixos
            effect.CurrentTechnique.Passes[0].Apply();
            device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleStrip, vertices, 0, vertices.Length - 2);
        }
    }
}
