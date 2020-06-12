<?php
	namespace ConexionNamespace
	{
		class Conexion
		{
			var $cnx, $usr, $pwd, $svr, $db;
			function __construct()
		
			{
				$this->svr = 'DESKTOP-UD3UPEH\\SQLEXPRESS';
				$this->usr = 'sa';
				$this->pwd = '12345';
				$this->db ='Periodico';

			}
			function Conectar()
			{
				try
				{
					$this->cnx = odbc_connect("Driver={SQL Server};
						Server=$this->svr;Database=$this->db;", $this->usr, $this->pwd)
					;
					if ($this->cnx === null) 
						throw new Exception("Error al establecer la conexion");
				}
					catch (Exception $e)
					{
						return $e->message;
					}
			}
			function Desconectar()
			{
				$this->cnx = null;
			}
			function Seleccion( $sql)
			{
				try
				{
					$resultSet = $this->Execute($sql);
					return $resultSet;
				}
				catch (Exception $e)
				{
					return $e->message;
				}
				
			}
			function Execute ($sql)
				{
					try {
						if (''===$sql) 
						{
							throw new Exception("Consulta vacia");
						}
						$this->Conectar();
						$resultSet = odbc_exec($this->cnx, $sql);
						$this->Desconectar();
						return $resultSet;
						
					} catch (Exception $e) 
					{
						return $e->message;	
					}
				}
			function ConsultaAccion($sql)
			{
				try
				{
					$rs= $this->Execute($sql);
					if(odbc_error($rs))
						return 0;
					else
						return 1;
					//return (odbc_error($rs) ? 0 : 1)

				}
				catch (Exception $e)
				{
					return $e->message;
				}
			}

			}
		}