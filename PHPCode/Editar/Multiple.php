<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $giroX =$_POST["giroX"];
	 $giroY =$_POST["giroY"];
	 
	$sql ="UPDATE multiple SET giroX='".$giroX."','giroY=".$giroY."'WHERE id='".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>