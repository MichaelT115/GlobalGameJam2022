using UnityEngine;

public sealed class PlayerCharacter : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Projectile projectilePrefab;

	[Header("Input")]
    [SerializeField]
    private Vector2 moveDirection;
    [SerializeField]
    private Vector2 facingDirection;
    [SerializeField]
    private bool isFiring;
    [SerializeField]
    private bool hasFired;

    private new Rigidbody rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + speed * Time.fixedDeltaTime * new Vector3(moveDirection.x, 0, moveDirection.y));
        facingDirection = moveDirection.sqrMagnitude > 0.9f ? moveDirection : facingDirection;

        if (isFiring && !hasFired)
        {
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.Fire(facingDirection);

            hasFired = true;
        }
        else if (!isFiring)
        {
            hasFired = false;
        }
    }

	public Vector2 MoveDirection { get => moveDirection; set => moveDirection = Vector2.ClampMagnitude(value, 1); }
    public bool IsFiring { get => isFiring; set => isFiring = value; }
}
