using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawn : MonoBehaviour
{
    public List<Sprite> Planets = new List<Sprite>();

    public float MinX = -8; // Минимальная X позиция
    public float MaxX = 8; // Максимальная X позиция
    public float MinY = -8; // Минимальная Y позиция
    public float MaxY = 8;

    private void Start()
    {
        CreatePlanets();
    }
    void CreatePlanets()
    {
        for (int i = 0; i < Random.Range(1, Planets.Count); i++)
        {
            CreateRandomPlanet(); 
        }
    }
    void CreateRandomPlanet()
    {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);
        Vector3 position = new Vector3(x, y, -2);

        // Генерация случайного размера
        float size = Random.Range(0.01f, 1.0f); // Измените диапазон по необходимости

        // Создание нового объекта планеты
        GameObject planet = new GameObject("Planet"); // Создаем новый GameObject с именем "Planet"
        planet.transform.position = position; // Устанавливаем позицию планеты
        planet.transform.localScale = new Vector3(size, size, size); // Устанавливаем размер планеты

        // Добавление компонента SpriteRenderer
        SpriteRenderer spriteRenderer = planet.AddComponent<SpriteRenderer>();
        if (spriteRenderer != null && Planets.Count > 0)
        {
            spriteRenderer.sprite = Planets[Random.Range(0, Planets.Count)]; // Устанавливаем случайный спрайт
        }
        planet.transform.SetParent(transform,false);
    }
}
