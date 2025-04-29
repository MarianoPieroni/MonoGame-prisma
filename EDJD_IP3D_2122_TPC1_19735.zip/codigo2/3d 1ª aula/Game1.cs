using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace intro3D
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Cls3DAxis eixo;  //como usar uma classe no game1
        ClsRedPlane planoV;
        ClsRedPlaneTriangleStrip planoV4;
        ClsPyramidTriangleStrip pyramid;
        ClsPyramid pyramid_2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            eixo = new Cls3DAxis(_graphics.GraphicsDevice);
            planoV = new ClsRedPlane(_graphics.GraphicsDevice);
            planoV4 = new ClsRedPlaneTriangleStrip(_graphics.GraphicsDevice);
            pyramid = new ClsPyramidTriangleStrip(_graphics.GraphicsDevice);


            pyramid_2 = new ClsPyramid(_graphics.GraphicsDevice, 8, 1.0f, 1.0f);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                
            }

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

   //         eixo.Draw(_graphics.GraphicsDevice);
    //       planoV.Draw(_graphics.GraphicsDevice);
          // planoV4.Draw(_graphics.GraphicsDevice);
     //       pyramid.Draw(_graphics.GraphicsDevice);


            pyramid_2.Draw(_graphics.GraphicsDevice);

            
            base.Draw(gameTime);
        }
    }
}
