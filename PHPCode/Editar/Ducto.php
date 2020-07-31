<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $longitud =$_POST["longitud"];
	 $paso =$_POST["paso"];
	 $dibujar =$_POST["dibujar"];
	 
	$sql ="UPDATE ducto SET longitud='".$longitud."','paso=".$paso."','dibujar=".$dibujar."'WHERE id='".$id."'";	
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitosa";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>