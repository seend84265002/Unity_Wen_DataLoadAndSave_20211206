using UnityEngine;
namespace Wen
{
    /// <summary>
    /// 玩家資料轉JSON資料
    /// </summary>
    public class PlayerData : MonoBehaviour
    {
        public int coin;
        public float posX;
        public float posY;
        //建構子:無傳回並且名稱與類別一樣的方法
        //會在此類別成為物件時執行一次，處理初始化
        /// <summary>
        /// 建立玩家資料並賦予直
        /// </summary>
        /// <param name="coin">金幣</param>
        /// <param name="posX">座標X</param>
        /// <param name="posY">座標Y</param>
        public PlayerData(int coin ,float posX,float posY)
        {
            this.coin = coin;
            this.posX = posX;
            this.posY = posY;

        }
    }

}
