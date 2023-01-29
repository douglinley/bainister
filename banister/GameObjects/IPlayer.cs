using banister.Core;
using Microsoft.Xna.Framework;

namespace banister.GameObjects;

public interface IPlayer : IEntity, IDamageable
{
    Vector2 Position { get; }
}
