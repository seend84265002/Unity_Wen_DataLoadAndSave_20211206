using UnityEngine;

namespace Wen
{
    /// <summary>
    /// 透過資料庫存取資料
    /// 資料透過JSON
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        public override void SaveData()
        {
            base.SaveData();

            //新增玩家資料並儲存金幣與座標
            PlayerData data = new PlayerData(goldManger.goldCount, player.position.x, player.position.y);
            //JSON 字串(JSON儲存的單位都是字串) = JSON 單位.轉 JSON(玩家資料)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON 資料:<color=yellow>" + dataJSON + "</color>");
        }
        public override void LoadData()
        {
            base.LoadData();
        }
    }
}

