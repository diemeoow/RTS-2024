using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanelManager : MonoBehaviour
{
    public TMP_Dropdown enemyCountDropdown; // Ссылка на Dropdown
    public GameObject enemyPanelPrefab; // Префаб панели для противника
    public Transform enemyPanelContainer; // Контейнер для размещения панелей

    private void Start()
    {
        // Убедитесь, что Dropdown и префаб инициализированы
        if (enemyCountDropdown == null || enemyPanelPrefab == null || enemyPanelContainer == null)
        {
            Debug.LogError("Dropdown, Enemy Panel Prefab, or Container not assigned!");
            return;
        }

        // Устанавливаем начальное состояние панелей
        UpdateEnemyPanels();

        // Подписываемся на событие изменения значения в Dropdown
        enemyCountDropdown.onValueChanged.AddListener(delegate { UpdateEnemyPanels(); });
    }

    private void UpdateEnemyPanels()
    {
        // Получаем количество противников из Dropdown
        int enemyCount = enemyCountDropdown.value;

        // Создаем новые панели в зависимости от выбранного количества
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPanelPrefab, enemyPanelContainer);
        }
    }
}
