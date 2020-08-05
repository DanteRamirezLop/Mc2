<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 
	 $sql ="DELETE FROM proyecto WHERE id= '".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Eliminacion exitosa - Proyecto";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>