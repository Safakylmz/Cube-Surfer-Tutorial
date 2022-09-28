using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] HeroInputController heroInputController;

    [SerializeField] private float forwardMovementSpeed;  //ileri gitme hýzý
    [SerializeField] private float horizontalMovementSpeed;  //yana gitme hýzý
    [SerializeField] private float horizontalLimitValue;  //yanlardan düþmesin diye.

    private float newPositionX;

    private void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);  //modellemede karakter ters olduðu için v3.down
    }

    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
