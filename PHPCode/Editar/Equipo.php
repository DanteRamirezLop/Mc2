<?php
     include_once 'Conexion.php';	 
	 
	 $id = $_POST["id"];
	 $idProyecto =$_POST["idProyecto"];
	 $codigo =$_POST["codigo"];
	 $tipo =$_POST["tipo"];
	 $velocidadIny =$_POST["velocidadIny"];
	 $velocidadExt =$_POST["velocidadExt"];
	 $porcentajeIny =$_POST["porcentajeIny"];
	 $porcentajeExt =$_POST["porcentajeExt"];
	 $calculo =(int)$_POST["calculo"];
	 $vinculo =$_POST["vinculo"];
	 $nivel =$_POST["nivel"];
	 $idAmbiente =$_POST["idAmbiente"];
	 $ccx =$_POST["ccx"];
	 $ccy =$_POST["ccy"];
	 $ccz =$_POST["ccz"];
	 //-----------------
	 $potencia =$_POST["potencia"];
	 $voltaje =$_POST["voltaje"];
	 $sistema =(int)$_POST["sistema"];
	 $enfEntrada1 =$_POST["enfEntrada1"];
	 $enfEntrada2 =$_POST["enfEntrada2"];
	 $enfSalida1 =$_POST["enfSalida1"];
	 $enfSalida2 =$_POST["enfSalida2"];
	 $tipo2 =$_POST["tipo2"]; //tipo2
	 $Hz =$_POST["Hz"];
	 $CSensible =$_POST["CSensible"];
	 $CLatente =$_POST["CLatente"];
	 $ESensible =$_POST["ESensible"];
	 $ELatente =$_POST["ELatente"];
	 $caudal =$_POST["caudal"];
	 
	 
	$sql ="UPDATE equipov SET idProyecto='".$idProyecto."',codigo='".$codigo."',tipo='".$tipo."',velocidadIny='".$velocidadIny."',velocidadExt='".$velocidadExt."',porcentajeIny='".$porcentajeIny."',porcentajeExt='".$porcentajeExt."',calculo='".$calculo."',vinculo='".$vinculo."',nivel='".$nivel."',idAmbiente='".$idAmbiente."',ccx='".$ccx."',ccy='".$ccy."',ccz='".$ccz.
	"' WHERE id='".$id."'";
	
	if($conn->query($sql)===TRUE){
		echo "Modificacion exitoso equipov";
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
    $sql_2 ="UPDATE equipoesp SET potencia='".$potencia."',voltaje='".$voltaje."',sistema='".$sistema."',enfEntrada1='".$enfEntrada1."',enfEntrada2='".$enfEntrada2."',enfSalida1='".$enfSalida1."',tipo='".$tipo2."',Hz='".$Hz."',CSensible='".$CSensible."',CLatente='".$CLatente."',ESensible='".$ESensible."',ESensible='".$ELatente."',caudal='".$caudal.
	"' WHERE idEquipoV= '".$id ."'";
	
	if($conn->query($sql_2)===TRUE){
		echo "Modificacion exitoso equipoesp";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	$conn->close();
?>