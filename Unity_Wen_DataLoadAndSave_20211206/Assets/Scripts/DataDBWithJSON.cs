using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Wen
{
    /// <summary>
    /// 透過資料庫存取資料
    /// 資料透過JSON
    /// </summary>
    public class DataDBWithJSON : DataLoadAndSaveBase
    {
        private string urlSave = "https://wen-1101208.000webhostapp.com/savejson.php";
        private string urlLoad = "https://wen-1101208.000webhostapp.com/Loadjson.php";
        private WWWForm form;
        /// <summary>
        /// 傳輸結果
        /// </summary>
        private string result;
        public override void SaveData()
        {

            base.SaveData();

            //新增玩家資料並儲存金幣與座標
            PlayerData data = new PlayerData(goldManger.goldCount, player.position.x, player.position.y,
                                player.rotation,Time.timeSinceLevelLoad);
            //JSON 字串(JSON儲存的單位都是字串) = JSON 單位.轉 JSON(玩家資料)
            string dataJSON = JsonUtility.ToJson(data);
            print("JSON 資料:<color=yellow>" + dataJSON + "</color>");

            //將JSON 資料添加到 表單欄位名稱為 [JSON]
            form = new WWWForm();
            form.AddField("json", dataJSON);
            StartCoroutine(StartLinkData(urlSave));
        }
        public override void LoadData()
        {
            base.LoadData();

            form = new WWWForm();
            form.AddField("json", "json");
            StartCoroutine(StartLinkData(urlLoad, true));
        }
        /// <summary>
        /// 開始使用資料庫
        /// </summary>
        /// <param name="url">要溝通的PHP連結</param>
        /// <param name="load">是否為載入模式</param>
        /// <returns></returns>
        private IEnumerator StartLinkData(string url,bool load=false)
        {

            using (UnityWebRequest www = UnityWebRequest.Post(url, form))    //透過網路傳輸傳遞資料到 Save.php
            {
                yield return www.SendWebRequest();      //等待傳輸  
                print("傳輸狀態: " + www.isDone);
                result = www.downloadHandler.text;      //傳輸結果
                print("傳輸結果: " + result);

            }
            if (load)
            {
                //將JSON 轉為玩家資料
                //JSON 單位 . 從JSON 轉資料<型別>(JSON)
                PlayerData data = JsonUtility.FromJson<PlayerData>(result);
                print("取得的金幣 : <color=yellow>" + data.coin + "</color>");

                goldManger.goldCount = data.coin;
                goldManger.UpdataData();

                float x = data.posX;
                float y = data.posY;
                player.position = new Vector3(x, y, 0);
                player.rotation = data.angle;

                print("上次遊玩時間 : <color=red>" + data.time + "</color>");

            }
        }
    }
}

