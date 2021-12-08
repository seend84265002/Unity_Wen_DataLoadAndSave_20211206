<?php
	// 連線資料 = 連線(伺服器位址，資料庫帳號，資料庫密碼，資料庫名稱)
$connrnt = mysqli_connect("localhost","id18085028_wen20211208","Wen_20211208","id18085028_unitydb");
	//金幣變數 =Unit 透過POST 傳輸資料 ，名稱 為 coin 的資料
	$coin = $_POST["coin"];
	$posX = $_POST["posX"];
	$posY = $_POST["posY"];
	//更新 playerdata編號 1 的金幣為70
	//更新 playerdata設定  coin =70 位置 playerdata.id=1
	//更新 playerdata設定  coin =70 位置 playerdata.id=1
	$sqlCoin = "UPDATE `playerdata` SET `coin` = '" .$coin. "' WHERE `playerdata`.`id` = 1";
	$sqlX = "UPDATE `playerdata` SET `posX` = '" .$posX. "' WHERE `playerdata`.`id` = 1";
	$sqlY = "UPDATE `playerdata` SET `posY` = '" .$posY. "' WHERE `playerdata`.`id` = 1";
	//執行 SQL (連線資料 ，查詢資料)
	mysqli_query($connrnt, $sqlCoin);
	mysqli_query($connrnt, $sqlX);
	mysqli_query($connrnt, $sqlY);

?>