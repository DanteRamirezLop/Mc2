<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $nombre =$_POST["nombre"];
	 
	$sql ="UPDATE filtro SET nombre='".$nombre ."' WHERE id ='".$id."'";	
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitosa -filtro";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>