namespace banister;

public interface IEntity : IDrawable, IUpdateable
{
    int Id { get; }
    void Despawn();
}
