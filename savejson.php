<?php
	// 連線資料 = 連線(伺服器位址，資料庫帳號，資料庫密碼，資料庫名稱)
	$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");
	//金幣變數 =Unit 透過POST 傳輸資料 ，名稱 為 json 的資料
	$json = $_POST["json"];

	//更新 playerdata設定  json =$json 位置 playerdata.id=1
	$sql = "UPDATE `playerjson` SET `json` = '".$json."' WHERE `playerjson`.`id` = 1";

	//執行 SQL (連線資料 ，查詢資料)
	mysqli_query($connrnt, $sql);


?>