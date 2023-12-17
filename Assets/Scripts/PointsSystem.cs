using System;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour {

    public static event EventHandler<PointCollectedEventArguments> PointCollected;
    public static void OnPointsCollected(object sender, PointCollectedEventArguments pointCollected) => PointCollected?.Invoke(sender, EventArgs.Empty);

    [SerializeField] private int currentPoints = 0;
    public TextMeshProUGUI currentPointsText;

    private void OnEnable() {
        PointCollected += AddPoints;
    }

    private void OnDisable() {
        PointCollected -= AddPoints;
    }

    public void AddPoints(int value) {
        currentPoints += value;
        currentPointsText.text = $"{currentPoints}";
    }

    public void RemovePoints(int value) {
        currentPoints -= value;
        currentPointsText.text = $"Points: {currentPoints}";
    }
}

public class PointCollectedEventArguments