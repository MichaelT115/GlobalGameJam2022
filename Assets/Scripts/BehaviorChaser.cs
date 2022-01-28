using UnityEngine;
using UnityEngine.AI;

public sealed class BehaviorChaser : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent navMeshAgent;

	private void Awake() => navMeshAgent = GetComponent<NavMeshAgent>();

	private void Start()
	{
		var playerCharacters = FindObjectsOfType<PlayerCharacter>();

		var targetCharacters = playerCharacters[Random.Range(0, playerCharacters.Length)];

		target = targetCharacters.transform;
	}

	private void Update() => navMeshAgent.SetDestination(target.position);
}
