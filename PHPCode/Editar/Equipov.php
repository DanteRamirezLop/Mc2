<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $idProyecto =$_POST["idProyecto"];
	 $codigo =$_POST["codigo"];
	 $tipo =$_POST["tipo"];
	 $velocidadlny =$_POST["velocidadlny"];
	 $velocidadExt =$_POST["velocidadExt"];
	 $porcentajelny =$_POST["porcentajelny"];
	 $porcentajeExt =$_POST["porcentajeExt"];
	 $calculo =$_POST["calculo"];
	 $vinculo =$_POST["vinculo"];
	 $nivel =$_POST["nivel"];
	 $idAmbiente =$_POST["idAmbiente"];
	 $ccx =$_POST["ccx"];
	 $ccy =$_POST["ccy"];
	 $ccz =$_POST["ccz"];
	 
	$sql ="UPDATE equipov SET idProyecto='".$idProyecto."','codigo=".$codigo."','tipo=".$tipo."','velocidadlny=".$velocidadlny."','velocidadExt=".$velocidadExt."','porcentajelny=".$porcentajelny."','porcentajeExt=".$porcentajeExt."','calculo=".$calculo."','vinculo=".$vinculo."','nivel=".$nivel."','idAmbiente=".$idAmbiente."','ccx=".$ccx."','ccy=".$ccy."','ccz=".$ccz.
	"'WHERE id='".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	$conn->close();
?>