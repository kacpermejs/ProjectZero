public interface IDamagable
{
    int GetHealth();
    int GetHealthMax();
    void Hit(int damage);
}