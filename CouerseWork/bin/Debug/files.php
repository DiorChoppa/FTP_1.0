<?php 

$DBHost = "localhost";
$DBUser = "root";
$DBPass = "";
$DBName = "coursework";
$Link = mysqli_connect($DBHost, $DBUser, $DBPass);
mysqli_select_db($Link, $DBName);

//$login = $_POST['Login'];
//$passwd = $_POST['Password'];

$ftp_server = "127.0.0.1";
$ftp_user_name = $_POST['Login'];
$ftp_user_pass = $_POST['Password'];
//$file = "data.txt";//tobe uploaded
//$remote_file = "/1stuploaded.txt";
$conn_id = ftp_connect($ftp_server); 
$login_result = ftp_login($conn_id, $ftp_user_name, $ftp_user_pass);
//$login = "blssd";
//$passwd = "root";

$Query = "TRUNCATE coursework.files";
$Trunc = mysqli_query($Link, $Query);

$array = array();
$list = ftp_rawlist($conn_id, "/");
$cnt = sizeof($list);
foreach ($list as &$item) {
	$clean = preg_replace('/\s+/', ' ', $item);
	$split_string = explode(" ", $clean);
	$name = $split_string[count($split_string) - 1];
	$mass = ftp_size($conn_id, $name);
	$Query = "INSERT INTO files VALUES(0, '$name', '$mass')";
	$Result = mysqli_query($Link, $Query);
	//$array[][0] = $name;
	//$array[][1] = $mass;
	//echo "$mass\n";
}


$Query = "SELECT * FROM `files`";
$Result = mysqli_query($Link, $Query);
$array = array();
$out = 'C:\Users\blessed\source\repos\CouerseWork\CouerseWork\bin\Debug\dab.txt';
$fh = fopen($out, 'w');  
while ($row = mysqli_fetch_array($Result)) {          
    $last = end($row);          
    $num = mysqli_num_fields($Result) ;    
    for($i = 0; $i < $num; $i++) {            
        fwrite($fh, $row[$i]);                      
        if ($row[$i] != $last)
           fwrite($fh, " ");
    }                                                                 
    fwrite($fh, "\n");
}
fclose($fh);

//Закрываем соединение

mysqli_close($Link);
ftp_close($conn_id);

 ?>