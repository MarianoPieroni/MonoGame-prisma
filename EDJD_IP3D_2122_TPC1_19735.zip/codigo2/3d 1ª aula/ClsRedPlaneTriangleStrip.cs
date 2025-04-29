using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace intro3D
{
    class ClsRedPlaneTriangleStrip
    {
        VertexPositionColor[] vertices;
        BasicEffect effect;
        Matrix worldMatrix;

        public ClsRedPlaneTriangleStrip(GraphicsDevice device)
        {
            //  Vamos usar um efeito básico
            effect = new BasicEffect(device);
            //  Calcula a aspectRatio, a view matrix e a projeção
            float aspectRatio = (float)device.Viewport.Width /
            device.Viewport.Height;
            effect.View = Matrix.CreateLookAt(
            new Vector3(4f, -0.0f, 2.5f),
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
            float axisLenght = 1f; //  Tamanho da linha em cada sinal do eixo 
            int vertexCount = 8;   //  Vamos usar 6 vértices
            vertices = new VertexPositionColor[vertexCount];
            vertices[0] = new VertexPositionColor(new Vector3(-axisLenght, 1f, -axisLenght), Color.Red);
            vertices[1] = new VertexPositionColor(new Vector3(+axisLenght, 1f, -axisLenght), Color.Black);
            vertices[2] = new VertexPositionColor(new Vector3(-axisLenght, 0.0f, +axisLenght), Color.Blue);
            vertices[3] = new VertexPositionColor(new Vector3(+axisLenght, 0.0f, +axisLenght), Color.Brown);
   /*         vertices[4] = new VertexPositionColor(new Vector3(-axisLenght, -1f, -axisLenght), Color.White);
            vertices[5] = new VertexPositionColor(new Vector3(+axisLenght, -1f, -axisLenght), Color.Green); */


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
