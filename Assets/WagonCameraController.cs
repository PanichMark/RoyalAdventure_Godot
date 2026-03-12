using UnityEngine;

public class WagonCameraController : MonoBehaviour
{
	public GameObject Wagon; // Объект вагона
	public GameObject WagonCamera; // Камера, следящая за вагоном

	void Start()
	{
		// Автоматический поиск объектов, если ссылки не указаны вручную
		Wagon = GameObject.Find("Wagon");
		WagonCamera = GameObject.Find("Camera"); // Лучше искать камеру именно по имени Main Camera
	}

	void LateUpdate()
	{
		// Устанавливаем позицию камеры относительно вагона,
		// смещение по оси X на 5 единиц вправо
		Vector3 newPos = Wagon.transform.position + new Vector3(15f, 20f, 0f);
		WagonCamera.transform.position = newPos; // Обращаемся к transform.position
	}
}