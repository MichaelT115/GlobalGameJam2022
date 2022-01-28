using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacter iceCharacter;
    [SerializeField]
    private PlayerCharacter fireCharacter;

	public void OnIceCharacterMove(InputValue value)
		=> iceCharacter.MoveDirection = value.Get<Vector2>();
	public void OnFireCharacterMove(InputValue value)
        => fireCharacter.MoveDirection = value.Get<Vector2>();
    public void OnIceCharacterAttack(InputValue value)
         => iceCharacter.IsFiring = value.isPressed;
    public void OnFireCharacterAttack(InputValue value)
         => fireCharacter.IsFiring = value.isPressed;
}
