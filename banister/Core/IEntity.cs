namespace banister.Core;

public interface IEntity : IDrawable, IUpdateable
{
    int Id { get; }
    void Despawn();
}
