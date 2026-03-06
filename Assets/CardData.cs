using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
   [Header("基本情報")] 
   public string cardName = "新しいカード";
   public int power = 1;

   [Header("特殊効果")]
   public bool isSpecial = false;

   [Header("マスの形状(基準点からの相対座標)")]
   public List<Vector2Int> shapeOffsets = new List<Vector2Int>();

   /// <summary>
   /// 現在のカーソル座標を渡すと、このカードが自裁に塗るべき盤面上の絶対座標のリストを返すメソッド
   /// </summary>
   public List<Vector2Int> GetAbsCoordinates(int cursorX, int cursorY)
    {
        List<Vector2Int> absCoords = new List<Vector2Int>();
        foreach (Vector2Int offset in shapeOffsets)
        {
            absCoords.Add(new Vector2Int(cursorX + offset.x, cursorY + offset.y));
        }
        return absCoords;
    }
}
