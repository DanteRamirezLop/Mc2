<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 
	$sql ="DELETE FROM filtro WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitoso -Filtro";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>