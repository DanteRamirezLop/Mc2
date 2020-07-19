<?php
     include_once 'Conexion.php';	 
	 
	 $idEquip = $_POST["idEquip"];
	 $idFiltro =$_POST["idFiltro"];
	 
	$sql ="INSERT INTO espfiltro (idEquip,idFiltro) 
	VALUES ('".$idEquip."','".$idFiltro."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>