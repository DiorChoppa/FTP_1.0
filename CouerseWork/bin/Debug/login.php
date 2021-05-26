<?php 

$DBHost = "localhost";
$DBUser = "root";
$DBPass = "";
$DBName = "coursework";
$Link = mysqli_connect($DBHost, $DBUser, $DBPass);
mysqli_select_db($Link, $DBName);

$login = $_POST['Login'];
$passwd = $_POST['Password'];
$Query = "SELECT COUNT('ID') FROM users";
$count = mysqli_query($Link, $Query);

$Query = "SELECT ID FROM users WHERE login = '$login' and password = '$passwd'";
$Result = mysqli_query($Link, $Query);

$ct = false;
if(mysqli_num_rows($Result) != 0){
	echo mysqli_fetch_array($Result)[0];
	$ct = true;
}
else{
	echo "0";
}

//Закрываем соединение

mysqli_close($Link);

 ?>