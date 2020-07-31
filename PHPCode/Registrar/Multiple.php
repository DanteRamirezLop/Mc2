<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $giroX =$_POST["giroX"];
	 $giroY =$_POST["giroY"];
	 
	$sql ="INSERT INTO multiple (giroX,giroY) 
	VALUES ('".$giroX."','".$giroY."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>