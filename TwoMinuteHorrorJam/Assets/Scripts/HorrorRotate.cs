using System.Collections;

using UnityEditor;

using UnityEngine;

public class HorrorRotate : HorrorObject
{
    [Header("旋轉物件")]
    public Transform rota;

    [Header("旋轉角度"), Range(90, 270)]
    public float angle = 120;
    [Header("旋轉速度"), Range(1, 100)]
    public float speed;


    /// <summary>
    /// 旋轉
    /// </summary>
    public override void TriggerEvent()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        GetComponentInChildren<BoxCollider>().enabled = false;

        float y = rota.localEulerAngles.y;       // 旋轉物件原始 Y，例：30
        float targetY = y + angle;               // 目標 Y 軸(原始 Y + 旋轉角度)，例： 30 + 120

        // 當 原始 Y < 目標 Y
        while (y < targetY)
        {
            // 角度遞增
            rota.localEulerAngles += Vector3.up * Time.deltaTime * speed;
            yield return null;
        }
    }
}
