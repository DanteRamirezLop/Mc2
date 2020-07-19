<?php
     include_once 'Conexion.php';	 
	 
	 //$id = $_POST["id"];
	 $longitud =$_POST["longitud"];
	 $paso =$_POST["paso"];
	 $dibujar =$_POST["dibujar"];
	 
	$sql ="INSERT INTO ducto (longitud,paso,dibujar) 
	VALUES ('".$longitud."','".$paso."','".$dibujar."')";	
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>