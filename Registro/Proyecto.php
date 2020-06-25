<?php
     $host     = "127.0.0.1";
     $db       = "bd_mc2";
     $user     = "root";
     $password = "";
     //$charset  = 'utf8mb4';

	 //$id = $_POST["id"];
	 $nombre =$_POST["nombre"];
	 
	 $conn = new mysqli($host,$user,$password,$db);
	 
	 if($conn->connect_error){
		 die("Connection failed: ". $con->connect_error);
	 }
		
	$sql ="INSERT INTO proyecto (nombre) VALUES ('".$nombre ."')";	
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>