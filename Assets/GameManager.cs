using System.Runtime.ExceptionServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("デバッグ用設定")]
    public GameObject cellPrefab;

    // ロジック用の配列
    private int[,] boardData = new int[16, 16];

    // 表示更新用のオブジェクト配列
    private GameObject[,] cellObjects = new GameObject[16, 16];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeBoard();
    }

    // 盤面の初期化とマス目の自動生成
    void InitializeBoard()
    {
        float offset = 1.1f; // マス目同士の隙間
        // 画面中央に寄せるためのオフセット
        float startX = -8f + (offset / 2);
        float startY = -8f + (offset / 2);

        for (int y = 0; y < 16; y++)
        {
            for (int x = 0; x < 16; x++)
            {
                boardData[x, y] = 0;

                // 画面上の座標を計算してプレハブを生成
                Vector2 pos = new Vector2(startX + (x * offset), startY + (y * offset));
                GameObject newCell = Instantiate(cellPrefab, pos, Quaternion.identity);

                // 管理しやすいように名前を変更し、親オブジェクト(GameManager)の子に入れる
                newCell.name = $"Cell_{x}_{y}";
                newCell.transform.SetParent(this.transform);

                cellObjects[x, y] = newCell;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
