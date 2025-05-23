﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace intro3D
{
    public class Cls3DAxis 
    {
        VertexPositionColor[] vertices;
        BasicEffect effect;
        Matrix worldMatrix;

        public Cls3DAxis(GraphicsDevice device)
        {
            // Vamos usar um efeito básico
            effect = new BasicEffect(device);
            // Calcula a aspectRatio, a view matrix e a projeção
            float aspectRatio = (float)device.Viewport.Width /
                    device.Viewport.Height;
            effect.View = Matrix.CreateLookAt(
                    new Vector3(0.5f, 0.5f, 2.0f),    // lugar da camera
                    Vector3.Zero, Vector3.Up);
            effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                    MathHelper.ToRadians(60.0f),
                    aspectRatio, 1.0f, 10.0f);
            effect.LightingEnabled = false;
            effect.VertexColorEnabled = true;
            // Cria os eixos 3D
            CreateGeometry();
            //atz o draw
            worldMatrix = Matrix.Identity;
        }


        private void CreateGeometry()
        {
            float axisLenght = 1f; // Tamanho da linha em cada sinal do eixo
            int vertexCount = 6; // Vamos usar 6 vértices
            vertices = new VertexPositionColor[vertexCount];
            // Linha sobre o eixo X
            vertices[0] = new VertexPositionColor(new Vector3(-axisLenght, 0.0f, 0.0f),
            Color.Black);
            vertices[1] = new VertexPositionColor(new Vector3(axisLenght, 0.0f, 0.0f),
            Color.Black);
            // Linha sobre o eixo Y
            vertices[2] = new VertexPositionColor(new Vector3(0.0f, -axisLenght, 0.0f),
            Color.Green);
            vertices[3] = new VertexPositionColor(new Vector3(0.0f, axisLenght, 0.0f),
            Color.Green);
            // Linha sobre o eixo Z
            vertices[4] = new VertexPositionColor(new Vector3(0.0f, 0.0f, -axisLenght),
            Color.Blue);
            vertices[5] = new VertexPositionColor(new Vector3(0.0f, 0.0f, axisLenght),
            Color.Blue);
        }

        public void Draw(GraphicsDevice device)
        {
            // World Matrix
            effect.World = worldMatrix;
            // Indica o efeito para desenhar os eixos
            effect.CurrentTechnique.Passes[0].Apply();
            device.DrawUserPrimitives<VertexPositionColor>(
            PrimitiveType.LineList, vertices, 0, 3);
        }

    }
}
