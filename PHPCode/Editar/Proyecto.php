<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $nombre =$_POST["nombre"];
	 
	$sql ="UPDATE proyecto SET nombre='".$nombre ."' WHERE id ='".$id."'";	
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitoso- Proyecto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>