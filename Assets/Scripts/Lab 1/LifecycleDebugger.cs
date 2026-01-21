using UnityEngine;

public class LifecycleDebugger : MonoBehaviour
{
    [Header("Settings")]
    public bool showUpdateLogs = false;
    void Awake()
    {
        Debug.Log("<color=cyan><b>[Awake]</b></color>: Được gọi. Object đã sẵn sàng.");
    }
    void OnEnable()
    {
        Debug.Log("<color=green><b>[OnEnable]</b></color>: Script/Object đã được Bật.");
    }
    void Start()
    {
        Debug.Log("<color=yellow><b>[Start]</b></color>: Bắt đầu vòng lặp logic.");
    }
    void FixedUpdate()
    {
        if (showUpdateLogs)
            Debug.Log("[FixedUpdate]: Chạy xử lý vật lý.");
    }
    void Update()
    {
        if (showUpdateLogs)
            Debug.Log("[Update]: Chạy mỗi frame.");
    }
    void LateUpdate()
    {
        if (showUpdateLogs)
            Debug.Log("[LateUpdate]: Chạy sau Update.");
    }
    void OnDisable()
    {
        Debug.Log("<color=orange><b>[OnDisable]</b></color>: Script/Object đã bị Tắt.");
    }
    void OnDestroy()
    {
        Debug.Log("<color=red><b>[OnDestroy]</b></color>: Object đã bị Xóa hoàn toàn.");
    }
}