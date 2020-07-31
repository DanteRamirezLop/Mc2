<?php
     $host     = "127.0.0.1";
     $db       = "mc2nv";
     $user     = "root";
     $password = "";
     //$charset  = 'utf8mb4';

	 $conn = new mysqli($host,$user,$password,$db);
	 
	 if($conn->connect_error){
		 die("Connection failed: ". $con->connect_error);
	 }
?>