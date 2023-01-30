using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using banister.GameObjects;
using banister.Core;
using Microsoft.Xna.Framework.Audio;

namespace banister;

public class Main : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player _player;
    private SpriteFont _font;

    public static float TimeScale = 1f;

    public Main()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _player = new Player(new Vector2(20, 20), 100, 25, 25);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        string[] soundEffects =
        {
            "shoot"
        };

        foreach(var effect in soundEffects)
        {
            Audio.AddSoundEffect(effect, Content.Load<SoundEffect>($"Sound/{effect}"));
        }

        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D baseTexture = new Texture2D(GraphicsDevice, 1, 1);
        baseTexture.SetData(new[] { Color.White });
        _player.Texture = baseTexture;

        _font = Content.Load<SpriteFont>("Fonts/font");
    }

    protected override void UnloadContent()
    {
        base.UnloadContent();
        _spriteBatch.Dispose();
        if(_player != null)
        {
            _player.Texture.Dispose();
        }
    }

    protected override void Update(GameTime gameTime)
    {
        Input.Update(true);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds * TimeScale;

        _player.Update(deltaTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, $"Shoot Cooldown : {_player.ShootCooldown.ToString()}", new Vector2(20, 20), Color.Yellow);
        _spriteBatch.DrawString(_font, $"Sec Between Shot : {_player.SecondsBetweenShots.ToString()}", new Vector2(20, 35), Color.Yellow);
        _player.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}