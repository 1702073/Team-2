using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public LayerMask AttackLayer;
    private Vector2 mousePos;

    public Animator animator;

    public float cooldown, distance, radius;
    public bool attackReady = true;

    public static Vector2 GetFromDirection(Vector2 direction)
    {
        Vector2 result = Vector2.zero;

        if (Vector2.Dot(direction, Vector2.up) > .5f)
        {
            result = Vector2.up;
        }
        else if (Vector2.Dot(direction, Vector2.down) > .5f)
        {
            result = Vector2.down;
        }
        else if (Vector2.Dot(direction, Vector2.left) > .5f)
        {
            result = Vector2.left;
        }
        else if (Vector2.Dot(direction, Vector2.right) > .5f)
        {
            result = Vector2.right;
        }
        return result;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && attackReady == true)
        {
            Attack();
        }
    } 

    public void Attack()
    {
        Vector2 Direction = GetFromDirection(GetAttackDirection());

        animator.SetTrigger("Attack");
        animator.SetFloat("Attack Horizontal", Direction.x);
        animator.SetFloat("Attack Vertical", Direction.y);

        // Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(GetAttackSpot(), radius, Vector2.zero, 0, AttackLayer);

        // See if it hit the enemy
        if (hit&&hit.collider.CompareTag("Enemy"))
        {
            // Attacks the enemy
            hit.collider.GetComponent<EnemyGeneral>().EnemyTakeDamage(1);
            hit.rigidbody.AddForce(GetAttackDirection(), ForceMode2D.Impulse);
        }
        attackReady = false;

        // Forces the enemy to wait before it can attack again
        Invoke(nameof(ResetAttack), cooldown);
    }

    public Vector2 GetAttackDirection()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized * distance;

        return direction;
    }

    private Vector2 GetAttackSpot()
    {
        return transform.position + (Vector3)GetAttackDirection();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)GetAttackDirection());
        Gizmos.DrawWireSphere(GetAttackSpot(), radius);
    }

    private void ResetAttack()
    {
        attackReady = true;
    }
}