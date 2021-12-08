using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace Wen
{    
    public class DataDB : DataLoadAndSaveBase
    {
        private string urlSave = "https://wen-1101208.000webhostapp.com/save.php";
        private WWWForm form;
        public override void SaveData()
        {
            base.SaveData();
            form = new WWWForm();                       //新增表單
            form.AddField("coin",goldManger.goldCount); //表單添加金幣欄位與值
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartSaveData());            //啟動 儲存資料

        }
        public override void LoadData()
        {
            base.LoadData();
        }
        private IEnumerator StartSaveData()
        {
                             
            using(UnityWebRequest www = UnityWebRequest.Post(urlSave, form))    //透過網路傳輸傳遞資料到 Save.php
            {
                yield return www.SendWebRequest();      //等待傳輸  
                print("傳輸狀態" + www.isDone);
            }
        }
    }
}

