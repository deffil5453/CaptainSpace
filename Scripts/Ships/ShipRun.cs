using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipRun : MonoBehaviour
{
    public float Speed;
    private Vector3 _targetPosition;
    private Vector3 _currentVelocity;
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition(Input.mousePosition);
            MoveShip();
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                SetTargetPosition(touch.position);
                MoveShip();
            }
        }
    }

    private void SetTargetPosition(Vector3 position)
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(position);
        _targetPosition.z = 0;
    }

    private void MoveShip()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log(screenBounds);
        float modelWidth = 0.56f; // Установите ширину вашей модели
        float modelHeight = 0.68f;
        _targetPosition.x = Mathf.Clamp(_targetPosition.x, -screenBounds.x + modelWidth, screenBounds.x - modelWidth);
        _targetPosition.y = Mathf.Clamp(_targetPosition.y, -screenBounds.y + modelHeight, screenBounds.y - modelHeight);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, 0.1f, Speed);
        //transform.position = new Vector3(Mathf.Clamp(_targetPosition.x, -screenBounds.x+modelWidth, screenBounds.x-modelWidth),
        //                                 Mathf.Clamp(_targetPosition.y, -screenBounds.y+modelHeight, screenBounds.y-modelHeight), _targetPosition.z); // Устанавливаем Z в 0
    }
}