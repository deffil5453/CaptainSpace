using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BackroundManager : MonoBehaviour
{
    public GameObject Backround;
    private List<GameObject> Backrounds = new List<GameObject>();
    [SerializeField] private int _backrouneHeigth = 20;
    public float BackroundSpeed = 2f;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            CreateBackround(i);
        }
    }
    private void Update()
    {
        MoveBackround();
        for (int i = 0; i < Backrounds.Count; i++)
        {
            if (Backrounds[i].transform.position.y < Camera.main.transform.position.y - _backrouneHeigth)
            {
                RecycleCreate(i);
            }
        }
    }

    private void MoveBackround()
    {
        foreach (GameObject backround in Backrounds)
        {
            backround.transform.position += Vector3.down * BackroundSpeed * Time.deltaTime;
        }
    }

    private void CreateBackround(int index)
    {
        Vector3 position = new Vector3(0, index * _backrouneHeigth, Backround.transform.position.z); // Устанавливаем позицию фона
        GameObject newBackground = Instantiate(Backround, position, Quaternion.identity);
        Backrounds.Add(newBackground);
    }
    private void RecycleCreate(int index)
    {
        GameObject recycledBackground = Backrounds[index];
        Backrounds.RemoveAt(index);
        Destroy(recycledBackground);

        // Создаем новый фон на позиции, которая будет видна
        CreateBackround(Backrounds.Count);
    }
}
