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
	 $tipo2 =$_POST["tipo2"];
	 $Hz =$_POST["Hz"];
	 $CSensible =$_POST["CSensible"];
	 $CLatente =$_POST["CLatente"];
	 $ESensible =$_POST["ESensible"];
	 $ELatente =$_POST["ELatente"];
	 $caudal =$_POST["caudal"];
	 
	$sql ="INSERT INTO equipov (idProyecto,codigo,tipo,velocidadIny,velocidadExt,porcentajeIny,porcentajeExt,calculo,vinculo,nivel,idAmbiente,ccx,ccy,ccz)
	VALUES ('".$idProyecto."','".$codigo."','".$tipo."','".$velocidadIny."','".$velocidadExt."','".$porcentajeIny."','".$porcentajeExt."','".$calculo."','".$vinculo."','".$nivel."','".$idAmbiente."','".$ccx."','".$ccy."','".$ccz."')";
	
	if($conn->query($sql)===TRUE){
		echo "Registro exitoso EQUIPOV";
		
	}else{
		echo "Error:".$sql."<br>".$conn->error;
	}
	
	//$query = connect()->query('SELECT id FROM equipov ORDER BY id DESC LIMIT 1');

	
	$sql_2 ="INSERT INTO equipoesp (idEquipoV,potencia,voltaje,sistema,enfEntrada1,enfEntrada2,enfSalida1,enfSalida2,tipo,Hz,CSensible,CLatente,ESensible,ELatente,caudal)
	VALUES ('".$id."','".$potencia."','".$voltaje."','".$calculo ."','".$enfEntrada1."','".$enfEntrada2."','".$enfSalida1."','".$enfSalida2."','".$tipo2."','".$Hz."','".$CSensible."','".$CLatente."','".$ESensible."','".$ELatente."','".$caudal."')";
	
	if($conn->query($sql_2)===TRUE){
		echo "Registro exitoso EQUIPOESP";
	}else{
		echo "Error:".$sql_2."<br>".$conn->error;
	}
	
	$conn->close();
?>