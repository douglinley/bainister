using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using banister.Core;
using Microsoft.Xna.Framework.Input;
using System;

namespace banister.GameObjects;

public class Player : IPlayer
{
    private static readonly float _secondsBetweenShots = 1;
    private Vector2 _position;
    private float _speed;
    private Point _bounds;
    private int _health;
    private static Texture2D _texture;
    private float _shootCooldown;

    public Texture2D Texture
    {
        get => _texture;
        set
        {
            _texture = value;
            // more to come
        }
    }

    public Player(Vector2 position, float speed, int size, int health)
    {
        _position = position;
        _speed = speed;
        _health = health;
        _bounds = new Point(size, size);
        Id = 999;
    }

    public Vector2 Position => _position;

    public int Id { get; private set; }

    public int Health => _health;

    // TODO - TEMPORARY FOR DEBUG
    public float ShootCooldown => _shootCooldown;
    public float SecondsBetweenShots => _secondsBetweenShots;

    public void Despawn()
    {
        // TODO haven't decided how I will handle this yet
        throw new System.NotImplementedException();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, _bounds.X, _bounds.Y), Color.Tomato);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health < 0) { _health = 0;  }
    }

    public void Update(float deltaTime)
    {
        _shootCooldown = MathF.Max(_shootCooldown - deltaTime, -1);

        // TODO : Switch to using a direction vector
        if (Input.IsKeyDown(Keys.W) || Input.IsKeyDown(Keys.Up))
        {
            _position.Y -= _speed * deltaTime;
        }
        if (Input.IsKeyDown(Keys.S) || Input.IsKeyDown(Keys.Down))
        {
            _position.Y += _speed * deltaTime;
        }
        if (Input.IsKeyDown(Keys.A) || Input.IsKeyDown(Keys.Left))
        {
            _position.X -= _speed * deltaTime;
        }
        if (Input.IsKeyDown(Keys.D) || Input.IsKeyDown(Keys.Right))
        {
            _position.X += _speed * deltaTime;
        }

        if (Input.LeftMousePressed() && _shootCooldown <= 0)
        {
            Audio.PlaySoundEffect("shoot");
            _shootCooldown = _secondsBetweenShots;
        }
    }
}
