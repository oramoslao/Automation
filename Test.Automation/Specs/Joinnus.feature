Feature: Joinnus prueba para popular formulario con data
	

@mytag
Scenario: Registro en Joinnus
	Given Abrir la pagina de Joinnus
	And Hacer click en el boton registrarse
	Then Llenar datos en el formulario
	Then Hacer click en el boton cancelar
