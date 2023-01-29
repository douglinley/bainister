namespace banister.Core;

public interface IDamageable
{
    int Health { get; }

    void TakeDamage(int damage);
}
