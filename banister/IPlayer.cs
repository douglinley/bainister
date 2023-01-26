using Microsoft.Xna.Framework;

namespace banister;

public interface IPlayer : IEntity, IDamageable
{
    Vector2 Position { get; }
}
