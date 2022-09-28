using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] HeroInputController heroInputController;

    [SerializeField] private float forwardMovementSpeed;  //ileri gitme h�z�
    [SerializeField] private float horizontalMovementSpeed;  //yana gitme h�z�
    [SerializeField] private float horizontalLimitValue;  //yanlardan d��mesin diye.

    private float newPositionX;

    private void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);  //modellemede karakter ters oldu�u i�in v3.down
    }

    private void SetHeroHorizontalMovement()
    {
        newPositionX = transform.position.x + heroInputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
