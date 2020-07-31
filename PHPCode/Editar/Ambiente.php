<?php
     include_once 'Conexion.php';
	 
     $id = $_POST["id"];
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
	 
	$sql = "UPDATE ambiente SET 
	idProyecto='".$idProyecto."','nAmbiente=".$nAmbiente."','largo=".$largo."','ancho=".$ancho."','altura=".$altura."','area=".$area."','recambios=".$recambios."','flujo=".$flujo."','cfm=".$cfm."','coordenada=".$coordenada.
	"' WHERE id= '".$id. "'";
	
	if($conn->query($sql)===TRUE){
		echo "MENSAJE API: Modificacion exitosa";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>