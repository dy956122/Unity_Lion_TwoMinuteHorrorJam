using UnityEngine;
using System.Collections;

public class HorrorMove : HorrorObject
{
    [Header("移動物件")]
    public Transform move;
    [Header("前往位置")]
    public Transform target;
    [Header("移動速度"), Range(1, 100)]
    public float speed;

    public override void TriggerEvent()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        // 取得距離 (移動,位置)
        float dis = Vector3.Distance(move.position, target.position);

        // 當 距離 >= 0.2
        while (dis >= 0.2f)
        {
            // 移動物件 前往位置
            move.position = Vector3.Lerp(move.position, target.position, Time.deltaTime * 0.5f * speed);
            yield return null;
        }
    }


}
