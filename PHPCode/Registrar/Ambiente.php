<?php
     include_once 'Conexion.php';

	 $idProyecto = $_POST["idProyecto"];
	 $nAmbiente = $_POST["nAmbiente"];
	 $largo =$_POST["largo"];
	 $ancho =$_POST["ancho"];
	 $altura =$_POST["altura"];
	 $area =$_POST["area"];
	 $recambios =$_POST["recambios"];
	 $flujo =$_POST["flujo"];
	 $cfm =$_POST["cfm"];
	 $coordenada =$_POST["coordenada"];
	 
	//$sql ="INSERT INTO proyecto (nombre) VALUES ('".$nombre ."')";	
	$sql = "INSERT INTO ambiente(idProyecto, nAmbiente, largo, ancho, altura, area,recambios,flujo,cfm,coordenada)
	VALUES ('".$idProyecto."','".$nAmbiente."','".$largo."','".$ancho."','".$altura."','".$area."','".$recambios."','".$flujo."','".$cfm."','".$coordenada."')";
	
	if($conn->query($sql)===TRUE){
		echo "MENSAJE API: Registro exitoso en la BD";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>