using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

namespace Wen
{    
    public class DataDB : DataLoadAndSaveBase
    {
        private string urlSave = "https://wen-1101208.000webhostapp.com/save.php";
        private string urlLoad = "https://wen-1101208.000webhostapp.com/Load.php";
        private WWWForm form;
        /// <summary>
        /// 傳輸結果
        /// </summary>
        private string result;
        public override void SaveData()
        {
            base.SaveData();
            form = new WWWForm();                       //新增表單
            form.AddField("coin",goldManger.goldCount); //表單添加金幣欄位與值
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            StartCoroutine(StartLinkData(urlSave));            //啟動 儲存資料

        }
        public override void LoadData()
        {
            base.LoadData();
            
            form = new WWWForm();
            form.AddField("search", "coin");
            StartCoroutine(StartLinkData(urlLoad,"金幣"));

            form = new WWWForm();
            form.AddField("search", "posX");
            StartCoroutine(StartLinkData(urlLoad, "座標X"));

            form = new WWWForm();
            form.AddField("search", "posY");
            StartCoroutine(StartLinkData(urlLoad, "座標Y"));
        }
        private IEnumerator StartLinkData(string url,string updataItem=" ")
        {
                             
            using(UnityWebRequest www = UnityWebRequest.Post(url, form))    //透過網路傳輸傳遞資料到 Save.php
            {
                yield return www.SendWebRequest();      //等待傳輸  
                print("傳輸狀態: " + www.isDone);
                result = www.downloadHandler.text;      //傳輸結果
                print("傳輸結果: " + result);
                    
            }
            if(updataItem == "金幣")
            {
                goldManger.goldCount = Convert.ToInt32(result);
                goldManger.UpdataData();
            }

            if (updataItem == "座標X")
            {
                float x = Convert.ToSingle(result);
                player.position=new Vector3(x,player.position.y,0);
            }

            if (updataItem == "座標Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }
        }
    }
}

