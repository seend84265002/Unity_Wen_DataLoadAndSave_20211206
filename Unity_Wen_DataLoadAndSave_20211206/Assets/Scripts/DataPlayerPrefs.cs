using UnityEngine;
namespace Wen
{
    /// <summary>
    /// 資料存取
    /// PP 模式 : 使用Unity API Player Prefs
    /// </summary>
    public class DataPlayerPrefs : DataLoadAndSaveBase
    {
        [Header("PP 專用儲存資料 KEY")]
        public string keyGold = "金幣數量";
        public string keyX = "玩家X軸";
        public string KeyY = "玩家Y軸";
        public override void SaveData()
        {
            
            base.SaveData();
            PlayerPrefs.SetInt(keyGold, goldManger.goldCount);
            PlayerPrefs.SetFloat(keyX, player.position.x);
            PlayerPrefs.SetFloat(KeyY, player.position.y);
        }
        public override void LoadData()
        {
            base.LoadData();
            #region 讀取資料
            goldManger.goldCount = PlayerPrefs.GetInt(keyGold);
            Vector3 positionLoad = Vector3.zero;
            positionLoad.x = PlayerPrefs.GetFloat(keyX);
            positionLoad.y = PlayerPrefs.GetFloat(KeyY);
            #endregion


            #region 更新物件
            goldManger.UpdataData();
            player.position = positionLoad;
            #endregion
        }
    }
}


