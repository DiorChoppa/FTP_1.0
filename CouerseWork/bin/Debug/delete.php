<?php 

$ftp_server = "127.0.0.1";
$ftp_user_name = $_POST['Login'];
$ftp_user_pass = $_POST['Password'];
$name = htmlentities(file_get_contents('C:\Users\blessed\source\repos\CouerseWork\CouerseWork\bin\Debug\name.txt'));
$conn_id = ftp_connect($ftp_server); 
$login_result = ftp_login($conn_id, $ftp_user_name, $ftp_user_pass);
ftp_delete($conn_id, $name);
ftp_close($conn_id);

 ?>