using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float speed;

    private new Rigidbody rigidbody;

	private void Awake() => rigidbody = GetComponent<Rigidbody>();

	public void Fire(Vector2 direction) => this.direction = direction;

	private void FixedUpdate()
        => rigidbody.MovePosition(rigidbody.position + speed * Time.fixedDeltaTime * new Vector3(direction.x, 0, direction.y));

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out BehaviorChaser enemy))
		{
			Destroy(enemy.gameObject);
		}
	}
}
