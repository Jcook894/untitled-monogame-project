using HelloMonoGame.EventSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite;

namespace HelloMonoGame
{
    public class Player
    {
        private float _playerSpeed;
        private Vector2 _currentPos;
        private AnimatedSprite _playerSprite;
        private UserInput _userInput;

        public Player()
        {            
            _playerSpeed = 50f;
            _currentPos = new Vector2(400, 280);
        }

        public AnimatedSprite LoadPlayerContent(ContentManager content) 
        {
            // Load the .json file
            AnimationDefinition animationDefinition = content.Load<AnimationDefinition>("Sprites/Me_Earthbound-Recovered");
            // Load the sprite sheet
            Texture2D spritesheet = content.Load<Texture2D>("Sprites/Me_Earthbound-Recovered-Sheet");
            // Return sprite sheet.
            return _playerSprite = new AnimatedSprite(spritesheet, animationDefinition);
        }

        public void PlayerMovement(GameTime gameTime)
        {
            // Need to get user input from UserInput class.
  
            KeyboardState keyboardState = Keyboard.GetState();
            float currentGameTimeInSecs = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboardState.IsKeyDown(Keys.W))
            {
                _currentPos.Y -= _playerSpeed * currentGameTimeInSecs;
            }
            else if (keyboardState.IsKeyDown(Keys.S))
            {
                _playerSprite.Update(gameTime);
                _playerSprite.Play("WalkingDown");
                _currentPos.Y += _playerSpeed * currentGameTimeInSecs;
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                _currentPos.X -= _playerSpeed * currentGameTimeInSecs;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                _currentPos.X += _playerSpeed * currentGameTimeInSecs;
            }
        }

        public void RenderPlayerSprite(SpriteBatch spriteBatch)
        {
            // Set current position to animated sprite when updated.
            _playerSprite.Position = _currentPos;
            _playerSprite.Render(spriteBatch);
        }

    }
}
