<?php
// 連線資料 = 連線(伺服器位址，資料庫帳號，資料庫密碼，資料庫名稱)
$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");

//Unity 要查詢的資料 - search欄位
$json=$_POST["json"];
//測試讀取金幣資料
//$search="coin";

//SQL 查詢
$sql = "SELECT `".$json."` FROM `playerjson` WHERE 1";
//查詢結果 = SQL 查詢(連線資料 ，查詢)
$result = mysqli_query($connrnt , $sql);

//資料陣列 = 查詢結果轉列(查詢結果) - 將查詢結果轉為陣列資料
$data = mysqli_fetch_row($result);

//輸出 查詢結果 到網頁上
echo $data[0];

?>