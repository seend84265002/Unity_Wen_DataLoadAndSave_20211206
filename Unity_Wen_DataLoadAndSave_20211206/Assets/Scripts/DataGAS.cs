using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Networking;

namespace Wen
{
    /// <summary>
    /// 使用GAS存取資料
    /// Google AppLication Script
    /// </summary>
    public class DataGAS : DataLoadAndSaveBase
    {
        /// <summary>
        /// GAS連結
        /// </summary>
        private string gas = "https://script.google.com/macros/s/AKfycbzwokUKlsehtNIWvUwqpovv3124o-Khxaf4VhqQCWHoYjnUP2Hk4psWI1bss4x_77QL/exec";
        private WWWForm form;
        private string result;
        public override void SaveData()
        {
            base.SaveData();
            #region 儲存資料
            form = new WWWForm();
            form.AddField("coin", goldManger.goldCount);
            form.AddField("posX", player.position.x.ToString());
            form.AddField("posY", player.position.y.ToString());
            
            StartCoroutine(LinKGAS("寫入"));
            #endregion
        }
        public override void LoadData()
        {
            base.LoadData();
            #region 讀取資料
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 1);
            StartCoroutine(LoadGASData("金幣"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 2);
            StartCoroutine(LoadGASData("座標X"));
            form = new WWWForm();
            form.AddField("row", 2);
            form.AddField("col", 3);
            StartCoroutine(LoadGASData("座標Y"));
            #endregion
        }

        private IEnumerator LoadGASData(string updata)
        {
            yield return StartCoroutine(LinKGAS("讀取"));
            #region
            if(updata == "金幣")
            {
                goldManger.goldCount = Convert.ToInt32(result);
                goldManger.UpdataData();
            }else if(updata == "座標X")
            {
                float x = Convert.ToSingle(result);
                player.position = new Vector3(x, player.position.y, 0);
            }
            else if (updata == "座標Y")
            {
                float y = Convert.ToSingle(result);
                player.position = new Vector3(player.position.x, y, 0);
            }

            #endregion
        }

        /// <summary>
        /// 連結到 GAS
        /// </summary>
        /// <param name="loadOrSave">寫入 讀取</param>
        /// <returns></returns>
        private IEnumerator LinKGAS(string loadOrSave)
        {
            
            form.AddField("method", loadOrSave);
            using(UnityWebRequest www = UnityWebRequest.Post(gas, form))
            {
                yield return www.SendWebRequest();
                result = www.downloadHandler.text;
                print(result);
            }
        }

    }

}
