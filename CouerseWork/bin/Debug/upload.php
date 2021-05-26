<?php 
$DBHost = "localhost";
$DBUser = "root";
$DBPass = "";
$DBName = "coursework";
$Link = mysqli_connect($DBHost, $DBUser, $DBPass);
mysqli_select_db($Link, $DBName);

$ftp_server = "127.0.0.1";
$ftp_user_name = $_POST['Login'];
$ftp_user_pass = $_POST['Password'];
$conn_id = ftp_connect($ftp_server); 
$login_result = ftp_login($conn_id, $ftp_user_name, $ftp_user_pass);
$path = htmlentities(file_get_contents('C:\Users\blessed\source\repos\CouerseWork\CouerseWork\bin\Debug\way.txt'));
$name = htmlentities(file_get_contents('C:\Users\blessed\source\repos\CouerseWork\CouerseWork\bin\Debug\name.txt'));

$Query = "SELECT ID FROM files WHERE Name = '$name'";
$Result = mysqli_query($Link, $Query);
if(mysqli_num_rows($Result) == 0){
	ftp_put($conn_id, $name, $path, FTP_ASCII);
}
else{
	$dot = substr($name, -4);
	if($dot[0] == "."){
		$shr = substr($name, -4);
		$name = substr($name, 0, -4);
		$name = $name . "(1)" . $shr;
	}
	else{
		if($name[0] == ".")
			$name = "(1)" . $name;
		else
			$name = $name . "(1)";
	}
}
ftp_put($conn_id, $name, $path, FTP_ASCII);
ftp_close($conn_id);

 ?>