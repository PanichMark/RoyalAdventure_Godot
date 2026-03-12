using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WagonMovementController : MonoBehaviour
{
	private GameObject Wagon; // Поле для хранения объекта вагон
	private NavMeshAgent agent; // Навигационный компонент

	void Start()
	{
		// Поиск объекта по имени
		Wagon = GameObject.Find("Wagon");

		// Получаем компонент NavMeshAgent
		agent = Wagon.GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		// Проверяем нажатие левой кнопки мыши
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;

			// Если луч попал в сцену, устанавливаем точку назначения агента
			if (Physics.Raycast(ray, out hitInfo))
				agent.SetDestination(hitInfo.point);
		}
	}
}