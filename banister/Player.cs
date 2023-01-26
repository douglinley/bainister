using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace banister
{
    public class Player : IPlayer
    {
        private Vector2 _position;
        private float _speed;
        private Point _bounds;
        private int _health;

        private static Texture2D _texture;

        public Player(Vector2 position, float speed, int size, int health)
        {
            _position = position;
            _speed = speed;
            _health = health;
            _bounds = new Point(size, size);
            Id = 999;
        }

        public Texture2D Texture
        {
            get => _texture;
            set
            {
                _texture = value;
                // more to come
            }
        }

        public Vector2 Position => _position;

        public int Id { get; private set; }

        public int Health => _health;

        public void Despawn()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, _bounds.X, _bounds.Y), Color.Tomato);
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            var kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up))
            {
                _position.Y -= _speed * deltaTime;
            }
            if (kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down))
            {
                _position.Y += _speed * deltaTime;
            }
            if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left))
            {
                _position.X -= _speed * deltaTime;
            }
            if (kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right))
            {
                _position.X += _speed * deltaTime;
            }
        }
    }
}
